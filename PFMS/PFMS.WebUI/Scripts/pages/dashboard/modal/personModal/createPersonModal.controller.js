﻿(function (angular) {
    angular.module("appModule")
        .controller("createEmployeeModalController", createEmployeeModalController);

    createEmployeeModalController.$inject = ["$scope", "personAjaxService", "popUpModalService", "validationService", "$uibModalInstance", "personMode"];

    function createEmployeeModalController($scope, personAjaxService, popUpModalService, validationService, $uibModalInstance, personMode) {
        $scope.mode = "createMode";
        $scope.personMode = personMode;
        $scope.postUrl;
        $scope.positions;

        $scope.person = {};

        $scope.validation = {}

        $scope.validateFirstName = function () {
            console.log($scope.person.FirstName);
            $scope.validation.isFirstNameValid = validationService.validateName($scope.person.FirstName);
        };
        $scope.validateLastName = function () {
            $scope.validation.isLastNameValid = validationService.validateName($scope.person.LastName);
        }
        $scope.validatePhone = function () {
            $scope.validation.isPhoneValid = validationService.validatePhone($scope.person.Phone);
        };
        $scope.validateDate = function () {
            $scope.validation.isDateOfBirthValid = validationService.validateDate($scope.person.DateOfBirth);
        };
        $scope.validateAddress = function () {
            $scope.validation.isAddressValid = validationService.validateAddress($scope.person.Address);
        };
        $scope.validateAccount = function () {
            $scope.validation.isAccountValid = validationService.validateAccountNumber($scope.person.AccountNumber);
        };


        activate();

        //ACTIVATE
        function activate() {
            if ($scope.personMode == "employeeMode") {
                //$scope.postUrl = "/Person/CreateEmployee";
                personAjaxService.getPositions()
                    .then(function (response) {
                        $scope.positions = response.data;
                    }, function errorCallback(error) {
                        console.error(error);
                    });
            }
            else if ($scope.personMode == "customerMode") {
                //$scope.postUrl = "/Person/CreateCustomer";
            }
        }

        //CREATE PERSON
        $scope.modifyPerson = function (person) {
            var modalInstance = popUpModalService.openConfirm(person.FirstName + " " + person.LastName, "createMode");

            modalInstance.result
                .then(function () {
                    if (personMode == "employeeMode") {
                        personAjaxService.createEmployee(person)
                            .success(function (response) {
                                console.info('employee created');
                                var notificationInstance = popUpModalService.openNotification(person.FirstName + " " + person.LastName, "createMode");
                                notificationInstance.result.then(function () {
                                    location.assign("/Dashboard/Main");
                                });
                            })
                            .error(function (error) {
                                console.error(error);
                            })
                    }
                    else if (personMode == "customerMode") {
                        personAjaxService.createCustomer(person)
                            .success(function (response) {
                                console.info('customer created');
                                var notificationInstance = popUpModalService.openNotification(person.FirstName + " " + person.LastName, "createMode");
                                notificationInstance.result.then(function () {
                                    location.assign("/Dashboard/Main#/customers");
                                });
                            })
                            .error(function (error) {
                                console.error(error);
                            })
                        //todo
                    }
                }, function () {
                    return;
                });
        }

        //CLOSE MODAL
        $scope.closeModal = function () {
            $uibModalInstance.close();
        };
    };
})(angular);