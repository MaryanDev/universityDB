(function (angular) {
    angular.module("appModule")
        .directive("loadingAnimation", loadingAnimation);

    function loadingAnimation() {
        var directive = {
            restrict: "EA",
            templateUrl: "/Scripts/pages/dashboard/directives/loadingAnimation.html"
        }

        return directive;
    }
})(angular);