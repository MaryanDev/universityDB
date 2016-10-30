(function (angular) {
    angular.module("appModule")
        .controller("confirmModalController", confirmModalController);

    confirmModalController.$inject = ["$scope", "$uibModalInstance", "personName", "mode"];

    function confirmModalController($scope, $uibModalInstance, personName, mode) {
        $scope.personName = personName;
        $scope.mode = mode;
        console.log($scope.mode);

        $scope.ok = function () {
            $uibModalInstance.close(true);
        };

        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        };
    };
})(angular);