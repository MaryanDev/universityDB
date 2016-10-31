(function (angular) {
    angular.module("appModule")
        .controller("personController", personController);

    personController.$inject = ["$scope","$routeParams", "$uibModal", "popUpModalService", "personAjaxService", "mode"];

    function personController($scope, $routeParams, $uibModal, popUpModalService, personAjaxService, mode) {
        $scope.isLoading = true;
        $scope.mode = mode;
        $scope.personId;
        console.log(mode);

        $scope.persons;
        $scope.pagination = {};

        activate();

        $scope.getPersons = function (page) {
            $scope.isLoading = true;
            if ($scope.mode == "employeeMode") {
                personAjaxService.getEmployees(page)
                    .then(function (response) {
                        initData(response);
                    }, function errorCallback(error) {
                        console.log(error);
                    });
            }
            if ($scope.mode == "customerMode") {
                personAjaxService.getCustomers(page)
                    .then(function (response) {
                        initData(response);
                    }, function errorCallback(error) {
                        console.log(error);
                    });
                //todo
            }
        };

        $scope.showDetailsInModal = function (person) {
            var modalInstance = popUpModalService.openPersonDetails(person.Id, $scope.mode);
        };

        $scope.showAddDialog = function () {
            popUpModalService.openCreatePersonForm($scope.mode);
        }

        function activate() {
            $scope.personId = parseInt($routeParams.id) || null;
            console.log($routeParams.id + " " + $scope.personId);
            if ($routeParams.id !== undefined && $scope.personId === null) {
                location.assign("/");
            }
            else if ((!Number.isInteger($scope.personId) || $scope.personId <= 0) && $scope.personId !== null) {
                location.assign("/");
            }
            if ($scope.mode == "employeeMode") {
                personAjaxService.getEmployees(1, $scope.personId)
                    .then(function (response) {
                        initData(response);
                    }, function errorCallback(error) {
                        console.log(error);
                    });
            }
            if ($scope.mode == "customerMode") {
                //todo calll customers methods
                personAjaxService.getCustomers(1, $scope.personId)
                    .then(function (response) {
                        initData(response);
                    }, function errorCallback(error) {
                        console.log(error);
                    });
            }
        };

        function initData(response) {
            $scope.persons = $scope.mode == "employeeMode" ?  response.data.employees : response.data.customers;
            $scope.pagination.allPages = new Array(response.data.allPages);
            $scope.pagination.currentPage = response.data.currentPage;
            $scope.isLoading = false;
        };
    };
})(angular);