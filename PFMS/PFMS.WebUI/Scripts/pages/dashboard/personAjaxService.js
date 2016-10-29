(function (angular) {
    angular.module("appModule")
        .factory("personAjaxService", personAjaxService);

    personAjaxService.$inject = ["$http"];

    function personAjaxService($http) {
        var service = {
            getEmployees: getEmployeesAjax,
            getFullEmpInfo: getFullEmpInfoAjax,
            getPositions: getPositionsAjax,
            deleteEmployee: deleteEmployeeAjax
        };

        function getEmployeesAjax(page) {
            var promise = $http({
                method: "GET",
                url: "/Person/GetEmployeesInfo",
                params: { page: page }
            });

            return promise;
        };

        function getFullEmpInfoAjax(employeeId) {
            var promise = $http({
                method: "GET",
                url: "/Person/GetFullEmployeeInfo",
                params: { employeeId: employeeId }
            });

            return promise;
        }

        function getPositionsAjax() {
            var promise = $http({
                method: "GET",
                url: "/Person/GetEmployeesPosition"
            });

            return promise;
        };

        function deleteEmployeeAjax(id) {
            var promise = $http({
                method: "POST",
                url: "/Person/DeleteEmployee",
                data: { id: id }
            });

            return promise;
        };
        return service;
    }
})(angular);