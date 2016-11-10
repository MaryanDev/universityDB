(function (angular) {
    angular.module("appModule")
        .controller("repairController", repairController);

    repairController.$inject = ["$scope", "popUpModalService", "repairAjaxService", "machinesAjaxService"];

    function repairController($scope, popUpModalService, repairAjaxService, machinesAjaxService) {
        $scope.machinesOnRepair = [];
        $scope.pagination = {};
        $scope.types = [];
        $scope.search = {};
        $scope.isLoading = true;

        activate();

        function activate() {
            repairAjaxService.getMachinesOnRepair()
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
                });
        }

        $scope.searchForResults = function (search) {
            repairAjaxService.getMachinesOnRepair(search)
                .success(function (response) {
                    initData(response);
                })
                .error(function (error) {
                    console.error(error);
                });
        }

        $scope.showDetailsInModal = function (machineOnRepair) {
            popUpModalService.openMachineOnRepairForm(machineOnRepair.Id, "edit/deleteMode");
        }

        $scope.getMachinesOnRepair = function (page) {
            repairAjaxService.getMachinesOnRepair(search, page)
                .success(function (response) {
                    initData(response);
                })
                .error(function (error) {
                    console.error(error);
                })
        }

        function initData(response) {
            $scope.machinesOnRepair = response.machinesOnRepair,
            $scope.pagination.allPages = new Array(response.allPages),
            $scope.pagination.currentPage = response.currentPage;
            $scope.isLoading = false;
        }
    }
})(angular);