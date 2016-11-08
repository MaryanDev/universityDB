(function (angular) {
    angular.module("appModule")
        .controller("productsController", productsController);

    productsController.$inject = ["$scope", "productAjaxService", "popUpModalService"];

    function productsController($scope, productAjaxService, popUpModalService) {
        $scope.products = [];
        $scope.isLoading = true;
        $scope.search = {};
        activate();

        function activate() {
            productAjaxService.getProducts()
                .then(function (response) {
                    $scope.products = response.data;
                    $scope.isLoading = false;
                }, function errorCalback(error) {
                    console.error(error);
                });
        };

        $scope.searchForResults = function (search) {
            productAjaxService.getProducts(search)
                .then(function (response) {
                    $scope.products = response.data;
                    $scope.isLoading = false;
                }, function errorCalback(error) {
                    console.error(error);
                });
        }

        $scope.showDetailsInModal = function (product) {
            popUpModalService.openProductDetails(product, "edit/deleteMode");
        }

        $scope.showAddDialog = function () {
            popUpModalService.openCreateProductForm("createMode");
        }
    };
})(angular);