
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
                .when("/customers", {
                    templateUrl: "/Scripts/pages/dashboard/templates/persons.html",
                    controller: "personController",
                    resolve: {
                        mode: function () {
                            return "customerMode";
                        }
                    }
                })
                .otherwise({ redirectTo: "/employees" });
        });
})(angular);