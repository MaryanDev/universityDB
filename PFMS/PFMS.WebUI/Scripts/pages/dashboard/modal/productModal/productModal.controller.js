(function (angular) {
    angular.module("appModule")
        .controller("productModalController", productModalController);

    productModalController.$inject = ["$scope", "productAjaxService", "$uibModalInstance", "product", "mode"]

    function productModalController($scope, productAjaxService, $uibModalInstance, product, mode) {
        $scope.mode = mode;
        $scope.product = product;

        $scope.closeModal = function () {
            $uibModalInstance.close(false);
        }

        $scope.updateProduct = function (product) {
            productAjaxService.updateProduct(product)
                .success(function (response) {

                })
                .error(function (error) {
                    console.error(error);
                })
        }
    };

})(angular);