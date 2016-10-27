(function (angular) {
    angular.module("appModule")
        .factory("dashboardAjaxService", dashboardAjaxService);

    dashboardAjaxService.$inject = ["$http"];

    function dashboardAjaxService($http) {
        var service = {
            getEmployees: getEmployeesAjax,
            getFullEmpInfo: getFullEmpInfoAjax,
            getCustomers: getCustomersAjax
        };

        function getEmployeesAjax(page) {
            var promise = $http({
                method: "GET",
                url: "/Dashboard/GetEmployeesInfo",
                params: { page: page }
            });

            return promise;
        };

        function getFullEmpInfoAjax(employeeId) {
            var promise = $http({
                method: "GET",
                url: "/Dashboard/GetFullEmployeeInfo",
                params: { employeeId: employeeId }
            });

            return promise;
        }

        function getCustomersAjax(page) {
            var promise = $http({
                method: "GET",
                url: "/Dashboard/GetCustomers",
                params: { page: page }
            });

            return promise;
        };
        return service;
    }
})(angular);