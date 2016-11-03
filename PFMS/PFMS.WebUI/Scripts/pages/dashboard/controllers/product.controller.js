(function (angular) {
    angular.module("appModule")
        .controller("productsController", productsController);

    productsController.$inject = ["$scope", "productAjaxService"];

    function productsController($scope, productAjaxService) {
        $scope.products = [];
        activate();

        function activate() {
            productAjaxService.getProducts()
                .then(function (response) {
                    $scope.products = response.data;
                }, function errorCalback(error) {
                    console.error(error);
                });
        };
    };
})(angular);