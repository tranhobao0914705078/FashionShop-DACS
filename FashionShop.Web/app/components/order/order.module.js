/// <reference path="../assets/admin/libs/angular.js" />
(function () {
    angular.module('fashionshop.orders', ['fashionshop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('order', {
                url: "/order",
                parent: 'base',
                templateUrl: "/app/components/order/orderListView.html",
                controller: "orderListController"
            })
            .state('order_edit', {
                url: "/order_edit/:id",
                parent: 'base',
                templateUrl: "/app/components/order/orderEditView.html",
                controller: "orderEditController"
            });
    }
})();