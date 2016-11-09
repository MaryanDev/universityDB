(function (angular) {
    angular.module("appModule")
        .controller("machinesController", machinesController);
    machinesController.$inject = ["$scope", "machinesAjaxService", "popUpModalService"];

    function machinesController($scope, machinesAjaxService, popUpModalService) {
        $scope.search = {};
        $scope.machines = [];
        $scope.types = [];
        $scope.isLoading = true;

        activate();

        function activate() {
            //$scope.search = {id: 1}
            machinesAjaxService.getMachines()
                .success(function (response) {
                    $scope.machines = response;
                    $scope.isLoading = false;
                })
                .error(function (error) {
                    console.error(error);
                });
            machinesAjaxService.getMachinesTypes()
                .then(function (response) {
                    $scope.types = response.data;
                }, function errorCallback(error) {
                    console.error(error);
                })
        }

        $scope.showAddDialog = function () {

        }

        $scope.showDetailsInModal = function (machine) {
            popUpModalService.openMachineForm(machine.Id, "edit/deleteMode", $scope.types);
        }

        $scope.searchForResults = function (search) {
            machinesAjaxService.getMachines(search)
                .success(function (response) {
                    $scope.machines = response;
                    //$scope.isLoading = false;
                })
                .error(function (error) {
                    console.error(error);
                });
        }
    }
})(angular);