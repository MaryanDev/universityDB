(function (angular) {
    angular.module("appModule")
        .factory("machinesAjaxService", machinesAjaxService);

    machinesAjaxService.$inject = ["$http"];

    function machinesAjaxService($http) {
        var service = {

        }

        return service;
    }
})(angular);