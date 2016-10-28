(function (angular) {
    angular.module("appModule")
        .controller("personModalController", personModalController);

    personModalController.$inject = ["$scope", "$uibModalInstance", "dashboardAjaxService", "personId"];

    function personModalController($scope, $uibModalInstance, dashboardAjaxService, personId) {
        $scope.employee = {}
        $scope.isEdit = false;

        activate();

        function activate() {
            dashboardAjaxService.getFullEmpInfo(personId)
                .then(function (response) {
                    $scope.employee = response.data;
                }, function errorCallback(error) {
                    console.error(error);
                });
        }

        $scope.closeModal = function () {
            $uibModalInstance.close();
        };

        $scope.editEmployee = function () {
            $scope.isEdit = !$scope.isEdit;
        };
    };
})(angular);