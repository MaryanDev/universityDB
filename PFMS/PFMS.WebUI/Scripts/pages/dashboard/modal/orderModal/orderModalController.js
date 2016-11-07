(function (angular) {
    angular.module("appModule")
        .controller("orderModalController", orderModalController);

    orderModalController.$inject = ["$scope", "validationService", "popUpModalService", "orderAjaxService", "$uibModalInstance", "order", "mode"];

    function orderModalController($scope, validationService, popUpModalService, orderAjaxService, $uibModalInstance, order, mode) {
        $scope.mode = mode;
        $scope.order = order;

        $scope.closeModal = function () {
            $uibModalInstance.close(false);
        }
    };
})(angular);