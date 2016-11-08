(function (angular) {
    angular.module("appModule")
        .controller("orderModalController", orderModalController);

    orderModalController.$inject = ["$scope", "validationService", "popUpModalService", "orderAjaxService", "$uibModalInstance", "order", "mode"];

    function orderModalController($scope, validationService, popUpModalService, orderAjaxService, $uibModalInstance, order, mode) {
        $scope.mode = mode;
        $scope.order = order;
        $scope.matchingCustomers = [];
        $scope.matchingProducts = [];
        $scope.errorMessage;

        activate();

        function activate() {
            console.log($scope.order);
            $scope.order.customerName = $scope.order.CustomersFirstName + " " + $scope.order.CustomersLastName;
        }

        $scope.findMatchingCustomers = function (name) {
            orderAjaxService.findCustomersByName(name)
                .then(function (response) {
                    $scope.matchingCustomers = response.data;
                }, function errorCallback(error) {
                    console.error(error);
                })
        }

        $scope.findMatchingProducts = function (title) {
            orderAjaxService.findProductsByTitle(title)
                .then(function (response) {
                    $scope.matchingProducts = response.data;
                }, function errorCallback(error) {
                    console.error(error);
                });
        }

        $scope.updateOrder = function (order) {
            var splitted = order.customerName.split(' ');
            order.CustomersFirstName = splitted[0];
            order.CustomersLastName = splitted[1]
            var modalInstanse = popUpModalService.openConfirm("Order " + $scope.order.Id, "updateMode");
            modalInstanse.result.then(function () {
                orderAjaxService.updateOrder(order)
                    .then(function (response) {
                        popUpModalService.openNotification("Order " + $scope.order.Id, "updateMode").result.then(function () {
                            $scope.errorMessage = "";
                            $scope.closeModal();
                            location.assign("/Dashboard/Main/#orders");
                        });
                    }, function errorCallback(error) {
                        $scope.errorMessage = "The customer or product was not found";
                        console.error(error);
                    });
            },
            function () {
                return;
            })

        }

        $scope.closeModal = function () {
            $uibModalInstance.close(false);
        }
    };
})(angular);