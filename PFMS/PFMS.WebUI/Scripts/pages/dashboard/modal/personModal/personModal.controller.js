(function (angular) {
    angular.module("appModule")
        .controller("personModalController", personModalController);

    personModalController.$inject = ["$scope", "$uibModalInstance", "personAjaxService", "popUpModalService", "validationService", "personId", "personMode"];

    function personModalController($scope, $uibModalInstance, personAjaxService, popUpModalService, validationService, personId, personMode) {
        $scope.isLoading = true;
        $scope.mode = "edit/deleteMode";
        $scope.personMode = personMode;
        $scope.postUrl;

        $scope.person = {}
        $scope.positions;
        $scope.isEdit = false;

        $scope.validation = {}

        $scope.validateFirstName = function () {
            $scope.validation.isFirstNameValid = validationService.validateName($scope.person.FirstName);
            validateForm();
        };
        $scope.validateLastName = function () {
            $scope.validation.isLastNameValid = validationService.validateName($scope.person.LastName);
            validateForm();
        }
        $scope.validatePhone = function () {
            $scope.validation.isPhoneValid = validationService.validatePhone($scope.person.Phone);
            validateForm();
        };
        $scope.validateDate = function () {
            $scope.validation.isDateOfBirthValid = validationService.validateDate($scope.person.DateOfBirth);
            validateForm();
        };
        $scope.validateAddress = function () {
            $scope.validation.isAddressValid = validationService.validateAddress($scope.person.Address);
            validateForm();
        };
        $scope.validateAccount = function () {
            $scope.validation.isAccountValid = validationService.validateAccountNumber($scope.person.AccountNumber);
            validateForm();
        };

        function validateForm() {
            var commonValuesValid = $scope.validation.isFirstNameValid &&
                                                $scope.validation.isLastNameValid &&
                                                $scope.validation.isPhoneValid &&
                                                $scope.validation.isDateOfBirthValid &&
                                                $scope.validation.isAddressValid;
            if ($scope.personMode == "employeeMode") {
                $scope.validation.isFormValid = commonValuesValid;
            }
            else if ($scope.personMode == "customerMode") {
                $scope.validation.isFormValid = commonValuesValid && $scope.validation.isAccountValid;
            }
        };

        activate();

        //ACTIVATE
        function activate() {
            
            if ($scope.personMode == "employeeMode") {
                //$scope.postUrl = "/Person/UpdateEmployee";

                personAjaxService.getFullEmpInfo(personId)
                    .then(function (response) {
                        $scope.person = response.data;
                        $scope.person.DateOfBirth = new Date(response.data.DateOfBirth);
                        $scope.isLoading = false;

                        initialValidation();

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
            else if ($scope.personMode == "customerMode") {
                //$scope.postUrl = "/Person/UpdateCustomer";
                personAjaxService.getFullCustomerInfo(personId)
                    .then(function (response) {
                        $scope.person = response.data;
                        $scope.person.DateOfBirth = new Date(response.data.DateOfBirth);
                        $scope.isLoading = false;

                        initialValidation();
                    }, function errorCallback(error) {
                        console.error(error);
                    });
                //todo
            }
        }

        //INITIAL VALIDATION
        function initialValidation() {

            $scope.validateFirstName();
            $scope.validateLastName();
            $scope.validateAddress();
            $scope.validateDate();
            $scope.validatePhone();

            if ($scope.personMode == "customerMode") {
                $scope.validateAccount();
            }
        };
        //CLOSE MODAL
        $scope.closeModal = function () {
            $uibModalInstance.close();
        };

        //UPDATE PERSON
        $scope.modifyPerson = function (person) {
            var modalInstance
                = popUpModalService.openConfirm(person.FirstName + " " + person.LastName, "updateMode");

            modalInstance.result
                .then(function () {
                    if (personMode == "employeeMode") {
                        personAjaxService.updateEmployee(person)
                            .success(function (response) {
                                console.log('emplyee updated');

                                var notificationModalInstance =
                                    popUpModalService.openNotification(person.FirstName + " " + person.LastName, "updateMode");
                                notificationModalInstance
                                    .result
                                    .then(function () {
                                    location.assign("/Dashboard/Main");
                                });

                            })
                            .error(function (error) {
                                console.error(error);
                            });
                    }
                    else if (personMode == "customerMode") {
                        personAjaxService.updateCustomer(person)
                            .success(function (response) {
                                console.log('customer updated');

                                var notificationModalInstance =
                                    popUpModalService.openNotification(person.FirstName + " " + person.LastName, "updateMode");
                                notificationModalInstance
                                    .result
                                    .then(function () {
                                        $scope.closeModal();
                                        location.assign("/Dashboard/Main/#customers");
                                    });

                            })
                            .error(function (error) {
                                console.error(error);
                            });

                        //todo
                    }
                }, function () {
                    return;
                });
        }

        //DELETE PERSON
        $scope.deletePerson = function (id) {
            var modalInstance =
                popUpModalService.openConfirm($scope.person.FirstName + " " + $scope.person.LastName, "deleteMode");

            modalInstance.result
                .then(function () {
                    if ($scope.personMode == "employeeMode") {
                        personAjaxService.deleteEmployee(id)
                            .success(function (response) {
                                console.log('success');

                                var notificationModalInstance =
                                    popUpModalService.openNotification($scope.person.FirstName + " " + $scope.person.LastName, "deleteMode");
                                notificationModalInstance
                                    .result
                                    .then(function () {
                                    location.assign("/Dashboard/Main");
                                });

                            })
                            .error(function (error) {
                                console.error(error);
                            });
                    }
                    else if ($scope.personMode == "customerMode") {
                        personAjaxService.deleteCustomer(id)
                            .success(function (response) {
                                console.log('success');

                                var notificationModalInstance =
                                    popUpModalService.openNotification($scope.person.FirstName + " " + $scope.person.LastName, "deleteMode");
                                notificationModalInstance
                                    .result
                                    .then(function () {
                                        $scope.closeModal();
                                        location.assign("/Dashboard/Main/#customers");
                                    });

                            })
                            .error(function (error) {
                                //todo show notification that deleting was not successfull
                                console.error(error);
                            });
                        //todo
                    }
                }, function () {
                    return;
                });
        };
    };
})(angular);