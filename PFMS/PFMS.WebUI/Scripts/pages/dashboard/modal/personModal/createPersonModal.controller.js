(function (angular) {
    angular.module("appModule")
        .controller("createEmployeeModalController", createEmployeeModalController);

    createEmployeeModalController.$inject = ["$scope", "personAjaxService", "popUpModalService", "$uibModalInstance", "personMode"];

    function createEmployeeModalController($scope, personAjaxService, popUpModalService, $uibModalInstance, personMode) {
        $scope.mode = "createMode";
        $scope.personMode = personMode;
        $scope.postUrl;
        $scope.positions;

        activate();

        //ACTIVATE
        function activate() {
            if ($scope.personMode == "employeeMode") {
                //$scope.postUrl = "/Person/CreateEmployee";
                personAjaxService.getPositions()
                    .then(function (response) {
                        $scope.positions = response.data;
                    }, function errorCallback(error) {
                        console.error(error);
                    });
            }
            else if ($scope.personMode == "customerMode") {
                //$scope.postUrl = "/Person/CreateCustomer";
            }
        }

        //CREATE PERSON
        $scope.modifyPerson = function (person) {
            var modalInstance = popUpModalService.openConfirm(person.FirstName + " " + person.LastName, "createMode");

            modalInstance.result
                .then(function () {
                    if (personMode == "employeeMode") {
                        personAjaxService.createEmployee(person)
                            .success(function (response) {
                                console.info('employee created');
                                var notificationInstance = popUpModalService.openNotification(person.FirstName + " " + person.LastName, "createMode");
                                notificationInstance.result.then(function () {
                                    location.assign("/Dashboard/Main");
                                });
                            })
                            .error(function (error) {
                                console.error(error);
                            })
                    }
                    else if (personMode == "customerMode") {
                        //todo
                    }
                }, function () {
                    return;
                });
        }

        //CLOSE MODAL
        $scope.closeModal = function () {
            $uibModalInstance.close();
        };
    };
})(angular);