(function (angular) {
    angular.module("appModule")
        .factory("machinesAjaxService", machinesAjaxService);

    machinesAjaxService.$inject = ["$http"];

    function machinesAjaxService($http) {
        var service = {
            getMachines: getMachinesAjax,
            getMachinesTypes: getMachinesTypesAjax
        }

        function getMachinesAjax(search) {
            var promise = $http({
                method: "POST",
                url: "/Machine/GetSimpleMachineInfo",
                data: { searchModel: search }
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
        return service;
    }
})(angular);