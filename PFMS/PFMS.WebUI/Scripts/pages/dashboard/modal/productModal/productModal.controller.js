(function (angular) {
    angular.module("appModule")
        .controller("productModalController", productModalController);

    productModalController.$inject = ["$scope", "$uibModalInstance", "product", "mode"]

    function productModalController($scope, $uibModalInstance, product, mode) {
        $scope.mode = mode;
        $scope.product = product;

        $scope.closeModal = function () {
            $uibModalInstance.close(false);
        }
    };

})(angular);