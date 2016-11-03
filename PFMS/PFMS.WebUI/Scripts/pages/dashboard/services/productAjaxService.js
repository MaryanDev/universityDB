(function (angular) {
    angular.module("appModule")
        .factory("productAjaxService", productAjaxService);

    productAjaxService.$inject = ["$http"];

    function productAjaxService($http) {
        var service = {
            getProducts: getProductsAjax,
            updateProduct: updateProductAjax,
            createProduct: createProductAjax
        }

        function getProductsAjax() {
            var promise = $http({
                method: "GET",
                url: "/Product/GetProducts"
            });

            return promise;
        }

        function updateProductAjax(product) {
            var promise = $http({
                method: "POST",
                url: "/Product/UpdateProduct",
                data: { productToUpdate: product }
            });

            return promise;
        }

        function createProductAjax(product) {
            var promise = $http({
                method: "POST",
                url: "/Product/CreateProduct",
                data: { productToCreate: product }
            });

            return promise;
        }
        return service;
    }
})(angular);