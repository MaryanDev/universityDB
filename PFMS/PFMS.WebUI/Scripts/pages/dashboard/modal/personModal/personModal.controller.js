(function (angular) {
    angular.module("appModule")
        .controller("personModalController", personModalController);

    personModalController.$inject = ["$scope", "$uibModalInstance", "dashboardAjaxService", "person"];

    function personModalController($scope, $uibModalInstance, dashboardAjaxService, person) {

        $scope.person = person;

        $scope.closeModal = function () {
            $uibModalInstance.close();
        };
    };
})(angular);