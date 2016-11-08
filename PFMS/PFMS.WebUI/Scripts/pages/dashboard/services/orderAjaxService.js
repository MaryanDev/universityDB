(function (angular) {
    angular.module("appModule")
        .factory("orderAjaxService", orderAjaxService);

    orderAjaxService.$inject = ["$http"];

    function orderAjaxService($http) {
        var service = {
            getOrders: getOrdersAjax,
            findCustomersByName: findCustomersByNameAjax,
            findProductsByTitle: findProductsByTitleAjax,
            createOrder: createOrderAjax,
            updateOrder: updateOrderAjax,
            deleteOrder: deleteOrderAjax
        }

        function getOrdersAjax(page, search) {
            var promise = $http({
                method: "POST",
                url: "/Order/GetOrders",
                data: { searchModel: search, page: page }
            });

            return promise;
        }

        function findCustomersByNameAjax(name) {
            var promise = $http({
                method: "GET",
                url: "/Person/GetCustomersByName",
                params: { name: name }
            });

            return promise;
        }

        function findProductsByTitleAjax(title) {
            var promise = $http({
                method: "GET",
                url: "/Product/GetProductsByTitle",
                params: { title: title }
            });

            return promise;
        }

        function createOrderAjax(order) {
            var promise = $http({
                method: "POST",
                url: "/Order/CreateOrder",
                data: { orderToCreate: order }
            });

            return promise;
        }

        function updateOrderAjax(order) {
            var promise = $http({
                method: "POST",
                url: "/Order/UpdateOrder",
                data: { orderToUpdate: order }
            });

            return promise;
        }

        function deleteOrderAjax(order) {
            var promise = $http({
                method: "POST",
                url: "/Order/DeleteOrder",
                data: { orderToDelete: order }
            });

            return promise;
        }

        return service;
    }
})(angular);