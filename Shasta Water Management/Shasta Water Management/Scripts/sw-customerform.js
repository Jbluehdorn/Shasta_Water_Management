angular.module('customer-form', [])
    .controller('formCtrl', ['$scope', function($scope) {
        $scope.customer = customer;
        $scope.method = method;
    }]);