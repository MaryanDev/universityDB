(function (angular) {
    angular.module("appModule")
        .controller("machinesController", machinesController);
    machinesController.$inject = ["$scope", "machinesAjaxService"];

    function machinesController($scope, machinesAjaxService) {
        $scope.search = {};
        $scope.machines = [];
        $scope.types = [];
        $scope.isLoading = true;

        activate();

        function activate() {
            //$scope.search = {id: 1}
            machinesAjaxService.getMachines()
                .success(function (response) {
                    $scope.machines = response;
                    $scope.isLoading = false;
                })
                .error(function (error) {
                    console.error(error);
                });
            machinesAjaxService.getMachinesTypes()
                .then(function (response) {
                    $scope.types = response.data;
                }, function errorCallback(error) {
                    console.error(error);
                })
        }

        $scope.showAddDialog = function () {

        }

        $scope.showDetailsInModal = function (machine) {

        }

        $scope.searchForResults = function (search) {
            machinesAjaxService.getMachines(search)
                .success(function (response) {
                    $scope.machines = response;
                    //$scope.isLoading = false;
                })
                .error(function (error) {
                    console.error(error);
                });
        }
    }
})(angular);