﻿angular.module('customer-form', [])
    .controller('formCtrl', ['$scope', '$http', function($scope, $http) {
        $scope.customer = customer || {};
        $scope.method = method;
        $scope.states = [];

        //Defaults state to Missouri
        if ($scope.customer.State === undefined) {
            $scope.customer.State = "MO";
        }

        //Converts the Last Service to a date object
        if ($scope.customer.LastService !== undefined) {
            $scope.customer.LastService = new Date(parseInt($scope.customer.LastService.substr(6)));
        }

        //Gets all states
        $http({ url: getStatesUrl })
            .success(function(data) {
                console.log(data);
                $scope.states = data;
            })
            .error(function() {
                swal({
                    title: 'Error',
                    text: 'States could not be retrieved',
                    type: 'error'
                });
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