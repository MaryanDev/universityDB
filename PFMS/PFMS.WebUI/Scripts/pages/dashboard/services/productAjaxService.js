﻿(function (angular) {
    angular.module("appModule")
        .factory("productAjaxService", productAjaxService);

    productAjaxService.$inject = ["$http"];

    function productAjaxService($http) {
        var service = {
            getProducts: getProductsAjax,
            updateProduct: updateProductAjax,
            createProduct: createProductAjax,
            deleteProduct: deleteProductAjax
        }

        function getProductsAjax(search, page) {
            var promise = $http({
                method: "POST",
                url: "/Product/GetProducts",
                data: { searchModel: search, page: page }
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

        function deleteProductAjax(productToDelete) {
            var promise = $http({
                method: "POST",
                url: "/Product/DeleteProduct",
                data: { productToDelete: productToDelete }
            });

            return promise;
        }

        return service;
    }
})(angular);