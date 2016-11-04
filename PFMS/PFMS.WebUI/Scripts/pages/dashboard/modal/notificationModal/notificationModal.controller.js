(function (angular) {
    angular.module("appModule")
        .controller("notificationModalController", notificationModalController)

    notificationModalController.$inject = ["$scope", "$uibModalInstance", "title", "mode"];

    function notificationModalController($scope, $uibModalInstance, title, mode) {
        $scope.title = title;
        $scope.mode = mode;

        $scope.ok = function () {
            $uibModalInstance.close(true);
        };
    };
})(angular);