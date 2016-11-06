(function (angular) {
    angular.module("appModule")
        .factory("orderAjaxService", orderAjaxService);

    orderAjaxService.$inject = ["$http"];

    function orderAjaxService($http) {
        var service = {
            getOrders: getOrdersAjax
        }

        function getOrdersAjax(page) {
            var promise = $http({
                method: "GET",
                url: "/Order/GetOrders",
                params: { page: page }
            });

            return promise;
        }

        return service;
    }
})(angular);