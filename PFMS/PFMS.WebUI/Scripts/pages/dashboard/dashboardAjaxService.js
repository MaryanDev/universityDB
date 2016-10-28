(function (angular) {
    angular.module("appModule")
        .factory("employeesAjaxService", employeesAjaxService);

    employeesAjaxService.$inject = ["$http"];

    function employeesAjaxService($http) {
        var service = {
            getEmployees: getEmployeesAjax,
            getFullEmpInfo: getFullEmpInfoAjax,
            getCustomers: getCustomersAjax
        };

        function getEmployeesAjax(page) {
            var promise = $http({
                method: "GET",
                url: "/Employee/GetEmployeesInfo",
                params: { page: page }
            });

            return promise;
        };

        function getFullEmpInfoAjax(employeeId) {
            var promise = $http({
                method: "GET",
                url: "/Employee/GetFullEmployeeInfo",
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