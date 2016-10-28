(function (angular) {
    angular.module("appModule")
        .factory("employeesAjaxService", employeesAjaxService);

    employeesAjaxService.$inject = ["$http"];

    function employeesAjaxService($http) {
        var service = {
            getEmployees: getEmployeesAjax,
            getFullEmpInfo: getFullEmpInfoAjax,
            getPositions: getPositionsAjax,
            deleteEmployee: deleteEmployeeAjax
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

        function getPositionsAjax() {
            var promise = $http({
                method: "GET",
                url: "/Employee/GetEmployeesPosition"
            });

            return promise;
        };

        function deleteEmployeeAjax(id) {
            var promise = $http({
                method: "POST",
                url: "/Employee/DeleteEmployee",
                data: { id: id }
            });

            return promise;
        };
        return service;
    }
})(angular);