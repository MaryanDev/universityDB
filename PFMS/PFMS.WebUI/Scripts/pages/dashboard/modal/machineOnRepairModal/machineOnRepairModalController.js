(function (angular) {
    angular.module("appModule")
        .controller("machineOnRepairModalController", machineOnRepairModalController);

    machineOnRepairModalController.$inject = ["$scope", "validationService", "popUpModalService", "$uibModalInstance", "repairAjaxService", "machineId", "mode"];

    function machineOnRepairModalController($scope, validationService, popUpModalService, $uibModalInstance, repairAjaxService, machineId, mode) {
        $scope.machineId = machineId;
        $scope.machineOnRepair = {};
        $scope.mode = mode;
        $scope.isLoading = true;

        activate();

        function activate() {
            repairAjaxService.getFullMachineOnRepairInfo($scope.machineId)
                .then(function (response) {
                    $scope.machineOnRepair = response.data;
                    $scope.machineOnRepair.RepairStartDate = new Date(response.data.RepairStartDate);
                    $scope.machineOnRepair.RepairFinishDate = response.data.RepairFinishDate === null ? null : new Date(response.data.RepairFinishDate);
                    $scope.isLoading = false;
                }, function errorCallback(error) {
                    console.error(error);
                });
        }

        $scope.closeModal = function(){
            $uibModalInstance.close(false);
        }

        $scope.updateRepair = function (machineOnRepair) {
            var modalInstance = popUpModalService.openConfirm(machineOnRepair.Model, "updateMode");

            modalInstance.result.then(function () {
                repairAjaxService.updateMachineOnRepair(machineOnRepair)
                    .success(function (response) {
                        popUpModalService.openNotification(machineOnRepair.Model, "updateMode").result.then(function () {
                            $scope.closeModal();
                            location.assign("/Dashboard/Main/#repair");
                        })
                    })
            }, function () {
                return;
            })
        }

        $scope.endRepair = function (id) {
            var modalInstance = popUpModalService.openConfirm($scope.machineOnRepair.Model, "deleteMode");

            modalInstance.result.then(function () {
                repairAjaxService.endRepair(id)
                    .success(function (response) {
                        popUpModalService.openNotification($scope.machineOnRepair.Model, "deleteMode").result.then(function () {
                            $scope.closeModal();
                            location.assign("/Dashboard/Main/#repair");
                        })
                    })
            }, function () {
                return;
            })
        }
    }
})(angular);