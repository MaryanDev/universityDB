(function (angular) {
    angular.module("appModule")
        .controller("machineModalController", machineModalController);

    machineModalController.$inject = ["$scope", "validationService", "popUpModalService", "$uibModalInstance", "machinesAjaxService", "machineId", "mode", "types"];

    function machineModalController($scope, validationService, popUpModalService, $uibModalInstance, machinesAjaxService, machineId, mode, types) {
        $scope.machineId = machineId;
        $scope.machine = {};
        $scope.mode = mode;
        $scope.types = types;
        $scope.matchingEmployees = [];
        $scope.errorMessage = "";

        activate();

        function activate() {
            machinesAjaxService.getFullMachineInfo($scope.machineId)
                .then(function (response) {
                    console.log(response);
                    $scope.machine = response.data;
                }, function errorCallback(error) {
                    console.error(error);
                });
        }

        $scope.closeModal = function () {
            $uibModalInstance.close(false);
        }

        $scope.findMatchingEmployees = function (name) {
            machinesAjaxService.findEnployeesByName(name)
                .then(function (response) {
                    console.log(response);
                    $scope.matchingEmployees = response.data;
                },
                function errorCallback(error) {
                    console.error(error);
                })
        }

        $scope.deleteMachine = function (machine) {
            var modalInstance = popUpModalService.openConfirm(machine.Model, "deleteMode");

            modalInstance.result.then(function () {
                machinesAjaxService.deleteMachine(machine.Id)
                                .success(function (response) {
                                    popUpModalService.openNotification(machine.Model, "deleteMode").result.then(function () {
                                        $scope.closeModal();
                                        location.assign("/Dashboard/Main/#machines");
                                    })
                                })
                                .error(function (error) {
                                    console.error(error);
                                })
            }, function () {
                return;
            })
        }

        $scope.updateMachine = function (machine) {
            var modalInstance = popUpModalService.openConfirm(machine.Model, "updateMode");

            modalInstance.result.then(function () {
                machinesAjaxService.updateMachine(machine)
                    .success(function (response) {
                        popUpModalService.openNotification(machine.Model, "updateMode").result.then(function () {
                            $scope.closeModal();
                            $scope.errorMessage = "";
                            location.assign("/Dashboard/Main/#machines");
                        })
                    })
                    .error(function () {
                        $scope.errorMessage = "The employee or type was not found, please select right info";
                    })
            })
        }
    }
})(angular);