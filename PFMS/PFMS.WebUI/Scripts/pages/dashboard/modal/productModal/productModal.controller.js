(function (angular) {
    angular.module("appModule")
        .controller("productModalController", productModalController);

    productModalController.$inject = ["$scope", "productAjaxService", "validationService", "popUpModalService", "$uibModalInstance", "product", "mode"]

    function productModalController($scope, productAjaxService, validationService, popUpModalService, $uibModalInstance, product, mode) {
        $scope.mode = mode;
        $scope.product = product || {};
        $scope.validation = {}

        $scope.closeModal = function () {
            $uibModalInstance.close(false);
        }

        $scope.validateTitle = function () {
            $scope.validation.isTitleValid = validationService.validateTitle($scope.product.Title);
            validateForm();
        }

        $scope.validateCost = function () {
            $scope.validation.isCostValid = validationService.validateCost($scope.product.Cost);
            validateForm();
        }

        activate();

        function validateForm() {
            $scope.validation.isFormValid = $scope.validation.isCostValid && $scope.validation.isTitleValid;
        }

        function activate() {
            $scope.validateTitle();
            $scope.validateCost();
        }

        $scope.updateProduct = function (product) {
            var modalInstance = popUpModalService.openConfirm(product.Title, "updateMode");

            modalInstance.result.then(function () {
                productAjaxService.updateProduct(product)
                .success(function (response) {
                    console.log("product updated");
                    popUpModalService.openNotification(product.Title, "updateMode").result.then(function () {
                        $scope.closeModal();
                        location.assign("/Dashboard/Main/#products");
                    });
                })
                .error(function (error) {
                    console.error(error);
                })
            }, function () {
                return;
            });
        }

        $scope.createProduct = function (product) {
            var modalInstance = popUpModalService.openConfirm(product.Title, "createMode");

            modalInstance.result.then(function () {
                productAjaxService.createProduct(product)
                .success(function (response) {
                    console.log("product created");
                    popUpModalService.openNotification(product.Title, "createMode").result.then(function () {
                        $scope.closeModal();
                        location.assign("/Dashboard/Main/#products");
                    });
                })
                .error(function (error) {
                    console.error(error);
                })
            }, function () {
                return;
            });
        }

        $scope.deleteProduct = function (id) {
            var modalInstance = popUpModalService.openConfirm(product.Title, "deleteMode");

            modalInstance.result.then(function () {
                productAjaxService.deleteProduct(product.Id)
                .success(function (response) {
                    console.log("product deleted");
                    popUpModalService.openNotification(product.Title, "deleteMode").result.then(function () {
                        $scope.closeModal();
                        location.assign("/Dashboard/Main/#products");
                    });
                })
                .error(function (error) {
                    console.error(error);
                })
            }, function () {
                return;
            });
        }
    };

})(angular);