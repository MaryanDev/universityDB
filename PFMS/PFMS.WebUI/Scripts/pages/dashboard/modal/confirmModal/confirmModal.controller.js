(function (angular) {
    angular.module("appModule")
        .controller("confirmModalController", confirmModalController);

    confirmModalController.$inject = ["$scope", "$uibModalInstance", "title", "mode"];

    function confirmModalController($scope, $uibModalInstance, title, mode) {
        $scope.title = title;
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