(function (angular) {
    angular.module("appModule")
        .controller("machinesController", machinesController);
    machinesController.$inject = ["$scope", "machinesAjaxService"];

    function machinesController($scope, machinesAjaxService) {

    }
})(angular);