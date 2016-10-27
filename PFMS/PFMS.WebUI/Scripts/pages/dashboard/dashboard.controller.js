/// <reference path="../../angular/angular.js" />
(function (angular) {
    angular.module("appModule")
        .controller("dashboardController", dashboardController);

    dashboardController.$inject = ["$scope", "$uibModal", "dashboardAjaxService"];

    function dashboardController($scope, $uibModal, dashboardAjaxService) {
        $scope.persons;
        $scope.pagination = {};

        activate();

        $scope.getPersons = function (page) {
            dashboardAjaxService.getPersons(page)
                .then(function (response) {
                    initData(response);
                }, function errorCallback(error) {
                    console.log(error);
                });
        };

        $scope.showDetailsInModal = function (person) {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: "/Scripts/pages/dashboard/modal/personModal/personModal.html",
                controller: "personModalController",
                controllerAs: "pmCtrl",
                //size: "lg",
                resolve: {
                    person: function() {
                        return person;
                    }
                }
            });
        };

        function activate() {
            dashboardAjaxService.getPersons()
                .then(function (response) {
                    initData(response);
                }, function errorCallback(error) {
                    console.log(error);
                });
        };

        function initData(response) {
            $scope.persons = response.data.persons;
            $scope.pagination.allPages = new Array(response.data.allPages);
            $scope.pagination.currentPage = response.data.currentPage;
        };
    };
})(angular);