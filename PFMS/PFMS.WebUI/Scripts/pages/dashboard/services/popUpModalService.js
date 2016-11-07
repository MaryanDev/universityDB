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
            openProductDetails: openProductDetailsModal,
            openCreateProductForm: openCreateProductFormModal,
            openCreateOrderForm: openCreateOrderFormModal
        };

        return service;

        function openConfirmModal(title, mode) {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: "/Scripts/pages/dashboard/modal/confirmModal/confirmModal.html",
                controller: "confirmModalController",
                controllerAs: "cdCtrl",
                size: "sm",
                resolve: {
                    title: function () {
                        return title;
                    },
                    mode: function () {
                        return mode;
                    }
                }
            });

            return modalInstance;
        };

        function openNotificationModal(title, mode) {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: "/Scripts/pages/dashboard/modal/notificationModal/notificationModal.html",
                controller: "notificationModalController",
                controllerAs: "notifyCtrl",
                size: "sm",
                resolve: {
                    title: function () {
                        return title;
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

        function openCreateProductFormModal(mode) {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: "/Scripts/pages/dashboard/modal/productModal/productModal.html",
                controller: "productModalController",
                //size: "sm",
                resolve: {
                    product: function(){
                        return {};
                    },
                    mode: function () {
                        return mode;
                    }
                }
            });
        }

        function openCreateOrderFormModal(mode) {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: "/Scripts/pages/dashboard/modal/orderModal/orderModal.html",
                controller: "orderModalController",
                size: "lg",
                resolve: {
                    mode: function () {
                        return mode;
                    }
                }
            });

            return modalInstance;
        }
    }

})(angular);