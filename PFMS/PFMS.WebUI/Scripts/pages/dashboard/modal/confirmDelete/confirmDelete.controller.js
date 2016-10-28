(function (angular) {
    angular.module("appModule")
        .controller("confirmDeleteController", confirmDeleteController);

    confirmDeleteController.$inject = ["$scope", "$uibModalInstance", "empName"];

    function confirmDeleteController($scope, $uibModalInstance, empName) {
        $scope.employeeName = empName;

        $scope.ok = function () {
            $uibModalInstance.close(true);
        };

        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        };
    };
})(angular);