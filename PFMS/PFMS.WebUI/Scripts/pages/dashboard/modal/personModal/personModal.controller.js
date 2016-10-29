(function (angular) {
    angular.module("appModule")
        .controller("personModalController", personModalController);

    personModalController.$inject = ["$scope", "$uibModalInstance", "$uibModal", "personAjaxService", "personId", "personMode"];

    function personModalController($scope, $uibModalInstance, $uibModal, personAjaxService, personId, personMode) {
        $scope.mode = "edit/deleteMode";
        $scope.personMode = personMode;
        $scope.postUrl;

        $scope.person = {}
        $scope.positions;
        $scope.isEdit = false;

        activate();

        function activate() {
            if ($scope.personMode == "employeeMode") {
                $scope.postUrl = "/Person/UpdateEmployee";

                personAjaxService.getFullEmpInfo(personId)
                    .then(function (response) {
                        $scope.person = response.data;
                        $scope.person.DateOfBirth = new Date(response.data.DateOfBirth);
                    }, function errorCallback(error) {
                        console.error(error);
                    });

                personAjaxService.getPositions()
                    .then(function (response) {
                        $scope.positions = response.data;
                    }, function errorCalback(error) {
                        console.error(error);
                    });
            }
            if ($scope.personMode == "customerMode") {
                $scope.postUrl = "/Person/UpdateCustomer";
                //todo
            }
        }

        $scope.closeModal = function () {
            $uibModalInstance.close();
        };

        $scope.deletePerson = function (id) {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: "/Scripts/pages/dashboard/modal/confirmDelete/confirmDelete.html",
                controller: "confirmDeleteController",
                controllerAs: "cdCtrl",
                size: "sm",
                resolve: {
                    personName: function () {
                        return $scope.person.FirstName + " " + $scope.person.LastName;
                    }
                }
            });

            modalInstance.result
                .then(function () {
                    if ($scope.personMode == "employeeMode") {
                        personAjaxService.deleteEmployee(id)
                            .success(function (response) {
                                console.log('success');
                                location.assign("/Dashboard/Main");
                            })
                            .error(function (error) {
                                console.error(error);
                            });
                    }
                    if ($scope.personMode == "customerMode") {
                        //todo
                    }
                }, function () {
                    return;
                });
            
        };
    };
})(angular);