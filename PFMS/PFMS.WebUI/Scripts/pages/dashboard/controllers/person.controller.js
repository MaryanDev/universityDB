(function (angular) {
    angular.module("appModule")
        .controller("personController", personController);

    personController.$inject = ["$scope", "$uibModal", "personAjaxService", "mode"];

    function personController($scope, $uibModal, personAjaxService, mode) {
        $scope.mode = mode;
        console.log(mode);

        $scope.persons;
        $scope.pagination = {};

        activate();

        $scope.getPersons = function (page) {
            if ($scope.mode == "employeeMode") {
                personAjaxService.getEmployees(page)
                    .then(function (response) {
                        initData(response);
                    }, function errorCallback(error) {
                        console.log(error);
                    });
            }
            if ($scope.mode == "customerMode") {
                //todo
            }
        };

        $scope.showDetailsInModal = function (person) {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: "/Scripts/pages/dashboard/modal/personModal/personModal.html",
                controller: "personModalController",
                controllerAs: "pmCtrl",
                //size: "lg",
                resolve: {
                    personId: function () {
                        return person.Id;
                    },
                    personMode: function () {
                        return $scope.mode;
                    }
                }
            });
        };

        $scope.showAddDialog = function () {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: "/Scripts/pages/dashboard/modal/personModal/personModal.html",
                controller: "createEmployeeModalController",
                controllerAs: "createCtrl",
                resolve: {
                    personMode: function () {
                        return $scope.mode;
                    }
                }
                //size: "lg",
            });
        }

        function activate() {
            if ($scope.mode == "employeeMode") {
                personAjaxService.getEmployees()
                    .then(function (response) {
                        initData(response);
                    }, function errorCallback(error) {
                        console.log(error);
                    });
            }
            if ($scope.mode == "customerMode") {
                //todo calll customers methods
            }
        };

        function initData(response) {
            $scope.persons = $scope.mode == "employeeMode" ?  response.data.employees : response.data.customers;
            $scope.pagination.allPages = new Array(response.data.allPages);
            $scope.pagination.currentPage = response.data.currentPage;
        };
    };
})(angular);