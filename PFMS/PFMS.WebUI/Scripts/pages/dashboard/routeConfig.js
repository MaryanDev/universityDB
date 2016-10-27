
(function (angular) {
    angular.module("appModule")
        .config(function routeConfig($routeProvider) {
            $routeProvider
                .when("/", {
                })
                .when("/employees", {
                    templateUrl: "/Scripts/pages/dashboard/templates/employees.html",
                    controller: "employeesController",
                    controllerAs: "emp"
                });
        });
})(angular);