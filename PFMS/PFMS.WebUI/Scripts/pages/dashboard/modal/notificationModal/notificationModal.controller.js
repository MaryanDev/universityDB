(function (angular) {
    angular.module("appModule")
        .controller("notificationModalController", notificationModalController)

    notificationModalController.$inject = ["$scope", "$uibModalInstance", "personName", "mode"];

    function notificationModalController($scope, $uibModalInstance, personName, mode) {
        $scope.personName = personName;
        $scope.mode = mode;

        $scope.ok = function () {
            $uibModalInstance.close(true);
        };
    };
})(angular);