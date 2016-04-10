angular.module('upcomingServices', [])
    .controller('upcomingServicesCtrl', ['$scope', function($scope) {
        $scope.customers = customers;

        //Converts datetime strings to a date object
        $scope.customers.forEach(function (customer) {
            try {
                customer.LastService = new Date(parseInt(customer.LastService.substr(6)));
            } catch(ex) {
                
            }
        });
    }])
    .filter('phone', function () {
        return function (phone) {
            var phoneArr = phone.split('');
            var formattedPhone = '';

            if (phoneArr.length === 10) {
                formattedPhone += '(';
                for (var i = 0; i < 3; i++) {
                    formattedPhone += phoneArr[i];
                }
                formattedPhone += ') ';
                for (var i = 3; i < 6; i++) {
                    formattedPhone += phoneArr[i];
                }
                formattedPhone += '-';
                for (var i = 6; i < phoneArr.length; i++) {
                    formattedPhone += phoneArr[i];
                }
            } else if (phoneArr.length === 7) {
                for (var i = 0; i < 3; i++) {
                    formattedPhone += phoneArr[i];
                }
                formattedPhone += '-';
                for (var i = 3; i < phoneArr.length; i++) {
                    formattedPhone += phoneArr[i];
                }
            } else {
                formattedPhone = phone;
            }

            return formattedPhone;
        }
    });