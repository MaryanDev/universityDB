(function (angular) {
    angular.module("appModule")
        .controller("employeesController", employeesController);

    employeesController.$inject = ["$scope", "$uibModal", "employeesAjaxService"];

    function employeesController($scope, $uibModal, employeesAjaxService) {
        $scope.employees;
        $scope.pagination = {};

        activate();

        $scope.getEmployees = function (page) {
            employeesAjaxService.getEmployees(page)
                .then(function (response) {
                    initData(response);
                }, function errorCallback(error) {
                    console.log(error);
                });
        };

        $scope.showDetailsInModal = function (employee) {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: "/Scripts/pages/dashboard/modal/personModal/personModal.html",
                controller: "personModalController",
                controllerAs: "pmCtrl",
                //size: "lg",
                resolve: {
                    personId: function () {
                        return employee.Id;
                    }
                }
            });
        };

        function activate() {
            employeesAjaxService.getEmployees()
                .then(function (response) {
                    initData(response);
                }, function errorCallback(error) {
                    console.log(error);
                });
        };

        function initData(response) {
            $scope.employees = response.data.employees;
            $scope.pagination.allPages = new Array(response.data.allPages);
            $scope.pagination.currentPage = response.data.currentPage;
        };
    };
})(angular);