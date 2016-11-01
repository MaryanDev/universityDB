(function (angular) {
    angular.module("appModule")
        .factory("validationService", validationService);

    function validationService() {
        var service = {
            validateName: validateName,
            validateDate: validateDate,
            validatePhone: validatePhone,
            validateAddress: validateAddress,
            validateAccountNumber: validateAccountNumber
        };

        function validateName(name) {
            var regExp = /^[A-Za-zА-Яа-яІі]+$/;
            var withoutNumbers = regExp.test(name);
            if (name === undefined || name === null || name.length < 2 || name.length > 50 || !withoutNumbers)
                return false;
            else {
                return true;
            }
        };

        function validateDate(dateToValidate) {
            var date = new Date(dateToValidate);
            if (date === undefined || date === null || date > Date.now()) {
                return false;
            }
            else {
                return true;
            }
        };

        function validateAccountNumber(account) {
            if (account === undefined || account == null || account.length < 10 || account.length > 100) {
                return false;
            }
            else {
                return true;
            }
        };

        function validatePhone(phone) {
            var regExp = /^[0-9()+' '-]+$/;
            var validPhone = regExp.test(phone);
            if (phone === undefined || phone === null || phone.length < 4 || phone.length > 50 || !validPhone) {
                return false;
            }
            else {
                return true;
            }
        }

        function validateAddress(address) {
            if (address === undefined || address === null || address.length < 5 || address.length > 100) {
                return false;
            }
            else {
                return true;
            }
        };

        return service;
    }
})(angular);