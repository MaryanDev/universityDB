(function (angular) {
    angular.module("appModule")
        .factory("popUpModalService", popUpModalService);

    popUpModalService.$inject = ["$uibModal"];

    function popUpModalService($uibModal) {
        var service = {
            openConfirm: openConfirmModal,
            openNotification: openNotificationModal,
            openPersonDetails: openPersonDetailsModal,
            openCreatePersonForm: openCreatePersonFormModal,
            openProductDetails: openProductDetailsModal
        };

        return service;

        function openConfirmModal(name, mode) {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: "/Scripts/pages/dashboard/modal/confirmModal/confirmModal.html",
                controller: "confirmModalController",
                controllerAs: "cdCtrl",
                size: "sm",
                resolve: {
                    personName: function () {
                        return name;
                    },
                    mode: function () {
                        return mode;
                    }
                }
            });

            return modalInstance;
        };

        function openNotificationModal(name, mode) {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: "/Scripts/pages/dashboard/modal/notificationModal/notificationModal.html",
                controller: "notificationModalController",
                controllerAs: "notifyCtrl",
                size: "sm",
                resolve: {
                    personName: function () {
                        return name;
                    },
                    mode: function () {
                        return mode;
                    }
                }
            });

            return modalInstance;
        };

        function openPersonDetailsModal(id, mode) {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: "/Scripts/pages/dashboard/modal/personModal/personModal.html",
                controller: "personModalController",
                controllerAs: "pmCtrl",
                //size: "lg",
                resolve: {
                    personId: function () {
                        return id;
                    },
                    personMode: function () {
                        return mode;
                    }
                }
            });

            return modalInstance;
        };

        function openCreatePersonFormModal(mode) {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: "/Scripts/pages/dashboard/modal/personModal/personModal.html",
                controller: "createEmployeeModalController",
                controllerAs: "createCtrl",
                resolve: {
                    personMode: function () {
                        return mode;
                    }
                }
            });
        };

        function openProductDetailsModal(product, mode) {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: "/Scripts/pages/dashboard/modal/productModal/productModal.html",
                controller: "productModalController",
                //size: "sm",
                resolve: {
                    product: function () {
                        return product;
                    },
                    mode: function () {
                        return mode;
                    }
                }
            });
        };
    }

})(angular);