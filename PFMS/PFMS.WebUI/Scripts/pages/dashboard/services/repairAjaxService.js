(function (angular) {
    angular.module("appModule")
        .factory("repairAjaxService", repairAjaxService);

    repairAjaxService.$inject = ["$http"];

    function repairAjaxService($http) {
        var service = {
            getMachinesOnRepair: getMachinesOnRepairAjax,
            getFullMachineOnRepairInfo: getFullMachineOnRepairInfoAjax,
            updateMachineOnRepair: updateMachineOnRepairAjax,
            endRepair: endRepairAjax,
            createRepair: createRepairAjax
        };

        function getMachinesOnRepairAjax(search, page) {
            var promise = $http({
                method: "POST",
                url: "/MachineOnRepair/GetMachinesOnRepair",
                data: { searchModel: search, page: page }
            });

            return promise;
        }

        function getFullMachineOnRepairInfoAjax(machineId) {
            var promise = $http({
                method: "GET",
                url: "/MachineOnRepair/GetFullMachineOnRepairInfo",
                params: { machineId: machineId }
            });

            return promise;
        }

        function updateMachineOnRepairAjax(machineOnRepair) {
            var promise = $http({
                method: "POST",
                url: "/MachineOnRepair/UpdateMachineOnRepair",
                data: { machineOnRepairToUpdate: machineOnRepair }
            });

            return promise;
        }

        function endRepairAjax(repairId) {
            var promise = $http({
                method: "POST",
                url: "/MachineOnRepair/EndRepair",
                data: { machineOnRepairId: repairId }
            });

            return promise;
        }

        function createRepairAjax(machineOnRepair) {
            var promise = $http({
                method: "POST",
                url: "/MachineOnRepair/CreateRepair",
                data: { machineOnRepairToCreate: machineOnRepair }
            });

            return promise;
        }

        return service;
    }
})(angular);