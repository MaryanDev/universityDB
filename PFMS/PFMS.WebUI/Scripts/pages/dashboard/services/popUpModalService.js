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
            openCreateOrderForm: openCreateOrderFormModal,
            openOrderDetails: openOrderDetailsModal,
            openMachineForm: openMachineFormModal,
            openMachineOnRepairForm: openMachineOnRepairFormModal
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
                controller: "createOrderController",
                size: "lg",
                resolve: {
                    mode: function () {
                        return mode;
                    }
                }
            });

            return modalInstance;
        }

        function openOrderDetailsModal(order, mode) {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: "/Scripts/pages/dashboard/modal/orderModal/orderModal.html",
                controller: "orderModalController",
                size: "lg",
                resolve: {
                    order: function () {
                        return order;
                    },
                    mode: function () {
                        return mode;
                    }
                }
            })

            return modalInstance;
        };

        function openMachineFormModal(machineId, mode, types) {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: "/Scripts/pages/dashboard/modal/machineModal/machineModal.html",
                controller: "machineModalController",
                size: "lg",
                resolve: {
                    machineId: function(){
                        return machineId;
                    },
                    mode: function () {
                        return mode;
                    },
                    types: function () {
                        return types;
                    }
                }
            });

            return modalInstance;
        }

        function openMachineOnRepairFormModal(machineId, mode) {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: "/Scripts/pages/dashboard/modal/machineOnRepairModal/machineOnRepairModal.html",
                controller: "machineOnRepairModalController",
                size: "lg",
                resolve: {
                    machineId: function () {
                        return machineId;
                    },
                    mode: function () {
                        return mode;
                    }
                }
            })
        }
    }

})(angular);