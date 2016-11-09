(function (angular) {
    angular.module("appModule")
        .factory("machinesAjaxService", machinesAjaxService);

    machinesAjaxService.$inject = ["$http"];

    function machinesAjaxService($http) {
        var service = {
            getMachines: getMachinesAjax,
            getFullMachineInfo: getFulMachineInfoAjax,
            getMachinesTypes: getMachinesTypesAjax,
            findEnployeesByName: findEmplyeesByNameAjax,
            updateMachine: updateMachineAjax,
            deleteMachine: deleteMachineAjax
        }

        function getMachinesAjax(search) {
            var promise = $http({
                method: "POST",
                url: "/Machine/GetSimpleMachineInfo",
                data: { searchModel: search }
            });

            return promise;
        }

        function getFulMachineInfoAjax(id) {
            var promise = $http({
                method: "GET",
                url: "/Machine/GetFullMachineInfo",
                params: { machineId: id }
            });

            return promise;
        }

        function getMachinesTypesAjax() {
            var promise = $http({
                method: "GET",
                url: "/Machine/GetMachinesTypes"
            });

            return promise;
        }

        function findEmplyeesByNameAjax(name) {
            var promise = $http({
                method: "GET",
                url: "/Person/GetEmployeesByName",
                params: { name: name }
            });

            return promise;
        }

        function deleteMachineAjax(machineId) {
            var promise = $http({
                method: "POST",
                url: "/Machine/DeleteMachine",
                data: { machineId: machineId }
            });

            return promise;
        }

        function updateMachineAjax(machine) {
            var promise = $http({
                method: "POST",
                url: "/Machine/UpdateMachine",
                data: { machineToUpdate: machine }
            });

            return promise;
        }
        return service;
    }
})(angular);