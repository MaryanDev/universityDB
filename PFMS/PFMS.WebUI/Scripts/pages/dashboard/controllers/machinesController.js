(function (angular) {
    angular.module("appModule")
        .controller("machinesController", machinesController);
    machinesController.$inject = ["$scope", "machinesAjaxService", "popUpModalService"];

    function machinesController($scope, machinesAjaxService, popUpModalService) {
        $scope.search = {};
        $scope.machines = [];
        $scope.pagination = {};
        $scope.types = [];
        $scope.isLoading = true;

        activate();

        function activate() {
            //$scope.search = {id: 1}
            machinesAjaxService.getMachines()
                .success(function (response) {
                    initData(response);
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

        $scope.getMachines = function (page) {
            machinesAjaxService.getMachines($scope.search, page)
                .success(function (response) {
                    initData(response);
                })
                .error(function (error) {
                    console.error(error);
                });
        }

        $scope.showAddDialog = function () {
            popUpModalService.openMachineForm(null, "createMode", $scope.types);
        }

        $scope.showDetailsInModal = function (machine) {
            popUpModalService.openMachineForm(machine.Id, "edit/deleteMode", $scope.types);
        }

        $scope.searchForResults = function (search) {
            machinesAjaxService.getMachines(search)
                .success(function (response) {
                    initData(response);
                })
                .error(function (error) {
                    console.error(error);
                });
        }

        function initData(response) {
            $scope.machines = response.machines;
            $scope.pagination.allPages = new Array(response.allPages);
            $scope.pagination.currentPage = response.currentPage;
            $scope.isLoading = false;
        }
    }
})(angular);