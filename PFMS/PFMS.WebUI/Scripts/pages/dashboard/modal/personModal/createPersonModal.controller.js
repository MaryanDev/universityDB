(function (angular) {
    angular.module("appModule")
        .controller("createEmployeeModalController", createEmployeeModalController);

    createEmployeeModalController.$inject = ["$scope", "personAjaxService", "$uibModalInstance", "$uibModal", "personMode"];

    function createEmployeeModalController($scope, personAjaxService, $uibModalInstance, $uibModal, personMode) {
        $scope.mode = "createMode";
        $scope.personMode = personMode;
        $scope.postUrl;
        $scope.positions;

        activate();

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

        $scope.modifyPerson = function (person) {
            if (personMode == "employeeMode") {
                personAjaxService.createEmployee(person)
                    .success(function (response) {
                        console.info('employee created');
                        location.assign("/Dashboard/Main/employee");
                    })
                    .error(function (error) {
                        console.error(error);
                    })
            }
            else if (personMode == "customerMode") {
                //todo
            }
        }

        $scope.closeModal = function () {
            $uibModalInstance.close();
        };
    };
})(angular);