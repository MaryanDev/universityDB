(function (angular) {
    angular.module("appModule")
        .controller("confirmDeleteController", confirmDeleteController);

    confirmDeleteController.$inject = ["$scope", "$uibModalInstance", "personName"];

    function confirmDeleteController($scope, $uibModalInstance, personName) {
        $scope.personName = personName;

        $scope.ok = function () {
            $uibModalInstance.close(true);
        };

        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        };
    };
})(angular);