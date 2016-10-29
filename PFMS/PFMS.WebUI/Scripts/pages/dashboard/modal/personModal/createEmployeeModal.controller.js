(function (angular) {
    angular.module("appModule")
        .controller("createEmployeeModalController", createEmployeeModalController);

    createEmployeeModalController.$inject = ["$scope", "employeesAjaxService", "$uibModalInstance", "$uibModal"];

    function createEmployeeModalController($scope, employeesAjaxService, $uibModalInstance, $uibModal) {
        $scope.mode = "createMode";
        $scope.postUrl = "/Employee/CreateEmployee";
        $scope.positions;

        activate();

        function activate() {
            employeesAjaxService.getPositions()
                .then(function (response) {
                    $scope.positions = response.data;
                }, function errorCallback(error) {
                    console.error(error);
                });
        }

        $scope.closeModal = function () {
            $uibModalInstance.close();
        };
    };
})(angular);