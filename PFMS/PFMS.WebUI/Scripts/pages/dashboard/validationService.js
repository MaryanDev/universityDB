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
            if (name.length < 2 || name.length > 50 || !withoutNumbers || name === undefined || name === null)
                return false;
            else {
                return true;
            }
        };

        function validateDate(dateToValidate) {
            var date = new Date(dateToValidate);
            if (date > Date.now() || date === undefined || date === null) {
                return false;
            }
            else {
                return true;
            }
        };

        function validateAccountNumber(account) {
            if (account.length < 10 || account.length > 100 || account ===  undefined || account == null) {
                return false;
            }
            else {
                return true;
            }
        };

        function validatePhone(phone) {
            var regExp = /^[0-9()+' '-]+$/;
            var validPhone = regExp.test(phone);
            if (phone.length < 4 || phone.length > 50 || !validPhone || phone === undefined || phone === null) {
                return false;
            }
            else {
                return true;
            }
        }

        function validateAddress(address) {
            if (address.length < 5 || address.length > 100 || address === undefined || address ===  null) {
                return false;
            }
            else {
                return true;
            }
        }

        return service;
    }
})(angular);