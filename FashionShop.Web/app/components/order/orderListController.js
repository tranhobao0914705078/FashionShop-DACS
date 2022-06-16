/// <reference path="../../../assets/admin/libs/angular.js" />

(function (app) {
    app.controller('orderListController', orderListController);
    orderListController.$inject = ['$scope', 'apiService', '$filter'];

    function orderListController($scope, apiService, $filter) {
        $scope.order = [];

        $scope.getOrder = getOrder;
        $scope.keyword = '';

        $scope.search = search();
        function search() {
            getOrder();
        }

        function getOrder() {
            var config = {
                param: {
                    keyword: $scope.keyword
                }
            }
            apiService.get('/api/order/getall', config, function (result) {
                $scope.order = result.data;
            }, function () {
                console.log('load failed');
            });
        }
        $scope.getOrder();
    }
})(angular.module('fashionshop.orders'))