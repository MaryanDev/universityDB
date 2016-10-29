(function (angular) {
    angular.module("appModule")
        .controller("personModalController", personModalController);

    personModalController.$inject = ["$scope", "$uibModalInstance", "$uibModal", "employeesAjaxService", "personId"];

    function personModalController($scope, $uibModalInstance, $uibModal, employeesAjaxService, personId) {
        $scope.mode = "edit/deleteMode";
        $scope.postUrl = "/Employee/UpdateEmployee";

        $scope.employee = {}
        $scope.positions;
        $scope.isEdit = false;

        activate();

        function activate() {
            employeesAjaxService.getFullEmpInfo(personId)
                .then(function (response) {
                    $scope.employee = response.data;
                    $scope.employee.DateOfBirth = new Date(response.data.DateOfBirth);
                }, function errorCallback(error) {
                    console.error(error);
                });
            employeesAjaxService.getPositions()
                .then(function (response) {
                    $scope.positions = response.data;
                }, function errorCalback(error) {
                    console.error(error);
                });
        }

        $scope.closeModal = function () {
            $uibModalInstance.close();
        };

        $scope.editEmployee = function () {
            $scope.isEdit = !$scope.isEdit;
        };

        $scope.deleteEmployee = function (id) {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: "/Scripts/pages/dashboard/modal/confirmDelete/confirmDelete.html",
                controller: "confirmDeleteController",
                controllerAs: "cdCtrl",
                size: "sm",
                resolve: {
                    empName: function () {
                        return $scope.employee.FirstName + " " + $scope.employee.LastName;
                    }
                }
            });

            modalInstance.result
                .then(function () {
                    employeesAjaxService.deleteEmployee(id)
                        .success(function (response) {
                            console.log('success');
                            location.assign("/Dashboard/Main");
                        })
                        .error(function (error) {
                            console.error(error);
                        });
                }, function () {
                    return;
                });
            
        };
    };
})(angular);