(function (angular) {
    angular.module("appModule")
        .controller("orderModalController", orderModalController);

    orderModalController.$inject = ["$scope", "orderAjaxService", "validationService", "popUpModalService", "$uibModalInstance"];

    function orderModalController($scope, orderAjaxService, validationService, popUpModalService, $uibModalInstance) {
        $scope.matchingCustomers = [];
        $scope.matchingProducts = [];
        $scope.order = {};

        $scope.closeModal = function () {
            $uibModalInstance.close(false);
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

        $scope.assignCustomer = function(customer){
            $scope.order.customer = customer;
            $scope.order.customer.Name = $scope.order.customer.FirstName + ' ' + $scope.order.customer.LastName;
            //console.log($scope.order.customer);
        }

        $scope.assignProduct = function (product) {
            $scope.order.product = product;
            //console.log($scope.order.product);
        }

        $scope.createOrder = function (order) {
            var splitted = $scope.order.customerName.split(' ');
            $scope.order.CustomersFirstName = splitted[0];
            $scope.order.CustomersLastName = splitted[1];
            console.log(order);

            orderAjaxService.createOrder(order)
                .success(function (response) {
                    console.log("order created");
                })
                .error(function (error) {
                    console.error(error);
                });
        }
    }
})(angular);
