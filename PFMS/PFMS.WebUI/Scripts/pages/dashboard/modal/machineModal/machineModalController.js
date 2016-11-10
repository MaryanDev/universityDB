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
        $scope.validation = {};

        $scope.validateModel = function () {
            $scope.validation.isModelValid = validationService.validateModel($scope.machine.Model);
            validateForm();
        }

        $scope.validatePrice = function () {
            $scope.validation.isPriceValid = validationService.validateCost($scope.machine.Price);
            validateForm();
        }

        function validateForm() {
            $scope.validation.isFormValid = $scope.validation.isModelValid && $scope.validation.isPriceValid;
        }

        function initialValidation() {
            $scope.validateModel();
            $scope.validatePrice();
        }

        activate();

        function activate() {
            
            if ($scope.mode == "edit/deleteMode") {
                machinesAjaxService.getFullMachineInfo($scope.machineId)
                    .then(function (response) {
                        console.log(response);
                        $scope.machine = response.data;
                        initialValidation();
                    }, function errorCallback(error) {
                        console.error(error);
                    });
            }
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

        $scope.createMachine = function (machine) {
            var modalInstance = popUpModalService.openConfirm(machine.Model, "createMode");

            modalInstance.result.then(function () {
                machinesAjaxService.createMachine(machine)
                    .success(function (response) {
                        popUpModalService.openNotification(machine.Model, "createMode").result.then(function () {
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