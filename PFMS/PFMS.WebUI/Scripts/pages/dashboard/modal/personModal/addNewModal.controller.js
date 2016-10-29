(function (angular) {
    angular.module("appModule")
        .controller("addNewModalController", addNewModalController);

    addNewModalController.$inject = ["$scope", "employeesAjaxService", "$uibModalInstance", "$uibModal"];

    function addNewModalController($scope, employeesAjaxService, $uibModalInstance, $uibModal) {
        $scope.mode = "addMode";
        $scope.postUrl = "/Employee/CreateEmplyee";

        $scope.closeModal = function () {
            $uibModalInstance.close();
        };
    };
})(angular);