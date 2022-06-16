(function (app) {
    app.controller('orderEditController', orderEditController);

    orderEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService', '$stateParams'];

    function orderEditController(apiService, $scope, notificationService, $state, commonService, $stateParams) {
        $scope.Order = {
            Status: false
        }
        $scope.product = [];

        $scope.EditOrder = EditOrder;

        function loadOrderDetail() {
            apiService.get('api/order/getbyid/' + $stateParams.id, null, function (result) {
                $scope.Order = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function EditOrder() {
            apiService.put('api/order/update', $scope.Order,
                function (result) {
                    notificationService.displaySuccess("Xác Nhận Đơn Hàng " + result.data.CustomerName + " Thành Công");
                    $state.go('order')
                }, function (error) {
                    notificationService.displayError("Xác Nhận Đơn Hàng Không Thành Công");
                });
        }
        loadOrderDetail();
    }

})(angular.module('fashionshop.orders'));