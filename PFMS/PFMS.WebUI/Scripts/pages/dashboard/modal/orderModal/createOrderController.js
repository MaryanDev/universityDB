﻿(function (angular) {
    angular.module("appModule")
        .controller("createOrderController", createOrderController);

    createOrderController.$inject = ["$scope", "orderAjaxService", "validationService", "popUpModalService", "$uibModalInstance", "mode"];

    function createOrderController($scope, orderAjaxService, validationService, popUpModalService, $uibModalInstance, mode) {
        $scope.matchingCustomers = [];
        $scope.matchingProducts = [];
        $scope.order = {};
        $scope.errorMessage;
        $scope.mode = mode;
        $scope.validation = {}

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

        $scope.validateQuantity = function () {
            $scope.validation.isQuantityValid = validationService.validateCost($scope.order.Quantity);
        }

        activate();

        function activate()  {
            $scope.validateQuantity();
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

            var modalInstance = popUpModalService.openConfirm("order", $scope.mode);

            modalInstance.result.then(function () {
                orderAjaxService.createOrder(order)
                .success(function (response) {
                    console.log("order created");
                    $scope.errorMessage = "";
                    popUpModalService.openNotification("order", $scope.mode).result.then(function () {
                        $scope.closeModal();
                        location.assign("/Dashboard/Main/#orders");
                    });
                })
                .error(function (error) {
                    console.log(error);
                    $scope.errorMessage = "The customer or product was not found";
                });
            },
            function () {
                return;
            }) 
        }
    }
})(angular);
