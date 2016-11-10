(function (angular) {
    angular.module("appModule")
        .controller("machineOnRepairModalController", machineOnRepairModalController);

    machineOnRepairModalController.$inject = ["$scope", "validationService", "popUpModalService", "$uibModalInstance", "repairAjaxService", "machineId", "mode", "machine"];

    function machineOnRepairModalController($scope, validationService, popUpModalService, $uibModalInstance, repairAjaxService, machineId, mode, machine) {
        $scope.machineId = machineId;
        $scope.machineOnRepair = machine || {};
        $scope.mode = mode;
        $scope.isLoading = true;
        $scope.validation = {}

        $scope.validateCost = function () {
            $scope.validation.isCostValid = validationService.validateCost($scope.machineOnRepair.RepairCost);
            validateForm();
        }

        $scope.validateDate = function () {
            if ($scope.machineOnRepair.RepairFinishDate !== null && $scope.machineOnRepair.RepairFinishDate !== undefined) {
                $scope.validation.isDateValid = $scope.machineOnRepair.RepairFinishDate < $scope.machineOnRepair.RepairStartDate ? false : true;
            }
            else {
                $scope.validation.isDateValid = true;
            }

            validateForm();
        }

        function initialValidation() {
            $scope.validateCost();
            $scope.validateDate();
        }

        function validateForm() {
            $scope.validation.isFormValid = $scope.validation.isDateValid && $scope.validation.isCostValid;
        }

        activate();

        function activate() {
            if ($scope.mode == "edit/deleteMode") {
                repairAjaxService.getFullMachineOnRepairInfo($scope.machineId)
                    .then(function (response) {
                        $scope.machineOnRepair = response.data;
                        $scope.machineOnRepair.RepairStartDate = new Date(response.data.RepairStartDate);
                        $scope.machineOnRepair.RepairFinishDate = response.data.RepairFinishDate === null ? null : new Date(response.data.RepairFinishDate);
                        $scope.isLoading = false;

                        initialValidation();
                    }, function errorCallback(error) {
                        console.error(error);
                    });
            }
            else if ($scope.mode == "createMode") {
                $scope.isLoading = false;
            }
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

        $scope.createRepair = function (machineOnRepair) {
            var modalInstance = popUpModalService.openConfirm($scope.machineOnRepair.Model, "createMode");

            modalInstance.result.then(function () {
                repairAjaxService.createRepair(machineOnRepair)
                    .success(function (response) {
                        popUpModalService.openNotification($scope.machineOnRepair.Model, "createMode").result.then(function () {
                            location.assign("/Dashboard/Main/#repair");
                            $scope.closeModal();
                        })
                    })
            }, function () {
                return;
            })
        }
    }
})(angular);