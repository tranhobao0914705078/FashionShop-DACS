(function (app) {
    app.filter('statusFilterOrder', function () {
        return function (input) {
            if (input == true) {
                return 'Xác Nhận';
            }
            else
                return 'Khóa'
        }
    });
})(angular.module('fashionshop.common'));