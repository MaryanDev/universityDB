
(function (angular) {
    angular.module("appModule")
        .config(function routeConfig($routeProvider) {
            $routeProvider
                .when("/employees", {
                    templateUrl: "/Scripts/pages/dashboard/templates/persons.html",
                    controller: "personController",
                    controllerAs: "emp",
                    resolve: {
                        mode: function () {
                            return "employeeMode";
                        }
                    }
                })
                .
                when("/employees/:id", {
                    templateUrl: "/Scripts/pages/dashboard/templates/persons.html",
                    controller: "personController",
                    controllerAs: "emp",
                    resolve: {
                        mode: function () {
                            return "employeeMode";
                        }
                    }
                })
                .when("/customers", {
                    templateUrl: "/Scripts/pages/dashboard/templates/persons.html",
                    controller: "personController",
                    resolve: {
                        mode: function () {
                            return "customerMode";
                        }
                    }
                })
                .when("/customers/:id", {
                    templateUrl: "/Scripts/pages/dashboard/templates/persons.html",
                    controller: "personController",
                    resolve: {
                        mode: function () {
                            return "customerMode";
                        }
                    }
                })
                .when("/products", {
                    templateUrl: "/Scripts/pages/dashboard/templates/products.html",
                    controller: "productsController",
                    resolve: {

                    }
                })
                .when("/orders", {
                    templateUrl: "/Scripts/pages/dashboard/templates/orders.html",
                    controller: "ordersController"
                })
                .when("/machines", {
                    templateUrl: "/Scripts/pages/dashboard/templates/machines.html",
                    controller: "machinesController"
                })
                .otherwise({ redirectTo: "/employees" });
        });
})(angular);