(function (angular) {
    angular.module("appModule")
        .controller("ordersController", ordersController);

    ordersController.$inject = ["$scope", "orderAjaxService"];

    function ordersController($scope, orderAjaxService) {
        $scope.orders = [];
        $scope.pagination = {};
        $scope.isLoading = true;
        activate();

        function activate() {
            orderAjaxService.getOrders(1)
                .then(function (response) {
                    initData(response);
                }, function errorCallback(error) {
                    console.error(error);
                });
        }

        $scope.getOrders = function (page) {
            orderAjaxService.getOrders(page)
                .then(function (response) {
                    initData(response);
                }, function errorCallback(error) {
                    console.error(error);
                });
        }

        function initData(response) {
            $scope.orders = response.data.orders;
            $scope.pagination.allPages = new Array(response.data.allPages);
            $scope.pagination.currentPage = response.data.currentPage;
            $scope.isLoading = false;
        }
    }
})(angular);