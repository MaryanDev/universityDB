(function (angular) {
    angular.module("appModule")
        .factory("productAjaxService", productAjaxService);

    productAjaxService.$inject = ["$http"];

    function productAjaxService($http) {
        var service = {
            getProducts: getProductsAjax
        }

        function getProductsAjax() {
            var promise = $http({
                method: "GET",
                url: "/Product/GetProducts"
            });

            return promise;
        }
        return service;
    }
})(angular);