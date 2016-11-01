(function (angular) {
    angular.module("appModule")
        .factory("personAjaxService", personAjaxService);

    personAjaxService.$inject = ["$http"];

    function personAjaxService($http) {
        var service = {
            getEmployees: getEmployeesAjax,
            getFullEmpInfo: getFullEmpInfoAjax,
            getPositions: getPositionsAjax,
            updateEmployee: updateEmployeeAjax,
            createEmployee: createEmployeeAjax,
            deleteEmployee: deleteEmployeeAjax,

            getCustomers: getCustomersAjax,
            getFullCustomerInfo: getFullCustomerInfoAjax,
            createCustomer: createCustomerAjax,
            deleteCustomer: deleteCustomerAjax
        };

        function getEmployeesAjax(page, id) {
            var promise = $http({
                method: "GET",
                url: "/Person/GetEmployeesInfo",
                params: { page: page, personId: id }
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

        function updateEmployeeAjax(employee) {
            var promise = $http({
                method: "POST",
                url: "/Person/UpdateEmployee",
                data: { empToUpdate: employee }
            });

            return promise;
        };

        function createEmployeeAjax(employee) {
            var promise = $http({
                method: "POST",
                url: "/Person/CreateEmployee",
                data: { employeeToCreate: employee }
            });

            return promise;
        }

        function deleteEmployeeAjax(id) {
            var promise = $http({
                method: "POST",
                url: "/Person/DeleteEmployee",
                data: { id: id }
            });

            return promise;
        };

        function getCustomersAjax(page, id) {
            var promise = $http({
                method: "GET",
                url: "/Person/GetCustomersInfo",
                params: { page: page, personId: id }
            });

            return promise;
        }

        function getFullCustomerInfoAjax(customerId) {
            var promise = $http({
                method: "GET",
                url: "/Person/GetFullCustomerInfo",
                params: { customerId: customerId }
            });

            return promise;
        }

        function createCustomerAjax(customer) {
            var promise = $http({
                method: "POST",
                url: "/Person/CreateCustomer",
                data: { customerToCreate: customer }
            });

            return promise;
        }

        function deleteCustomerAjax(id) {
            var promise = $http({
                method: "POST",
                url: "/Person/DeleteCustomer",
                data: { id: id }
            });

            return promise;
        }
        return service;
    }
})(angular);