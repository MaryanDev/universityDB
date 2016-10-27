(function (angular) {
    angular.module("appModule")
        .factory("dashboardAjaxService", dashboardAjaxService);

    dashboardAjaxService.$inject = ["$http"];

    function dashboardAjaxService($http) {
        var service = {
            getPersons: getPersonsAjax
        };

        function getPersonsAjax(page) {
            var promise = $http({
                method: "GET",
                url: "GetPersons",
                params: { page: page }
            });

            return promise;
        }
        return service;
    }
})(angular);