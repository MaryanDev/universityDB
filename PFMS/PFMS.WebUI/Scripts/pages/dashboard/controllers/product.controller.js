(function (angular) {
    angular.module("appModule")
        .controller("productsController", productsController);

    productsController.$inject = ["$scope", "productAjaxService", "popUpModalService"];

    function productsController($scope, productAjaxService, popUpModalService) {
        $scope.products = [];
        $scope.isLoading = true;
        $scope.pagination = {}
        $scope.search = {};
        activate();

        function activate() {
            productAjaxService.getProducts()
                .then(function (response) {
                    $scope.products = response.data.products;
                    $scope.pagination.allPages = new Array(response.data.allPages);
                    $scope.pagination.currentPage = response.data.currentPage;
                    $scope.isLoading = false;
                }, function errorCalback(error) {
                    console.error(error);
                });
        };

        $scope.getProducts = function (page) {
            productAjaxService.getProducts($scope.search, page)
                .then(function (response) {
                    $scope.products = response.data.products;
                    $scope.pagination.allPages = new Array(response.data.allPages);
                    $scope.pagination.currentPage = response.data.currentPage;
                    $scope.isLoading = false;
                }, function errorCalback(error) {
                    console.error(error);
                });
        }

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