angular.module('customer-form', [])
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

        //Push a new piece of equipment
        $scope.newEquip = function () {
            $scope.customer.CustEquip = $scope.customer.CustEquip || [];
            $scope.customer.CustEquip.push({});
        }

        //Remove a piece of equipment
        $scope.removeEquip = function(equipment) {
            $scope.customer.CustEquip.splice($scope.customer.CustEquip.indexOf(equipment), 1);
        }

        $scope.SaveCustomer = function() {
            $scope.method === "Add" ? $scope.AddCustomer() : $scope.EditCustomer();
        }

        $scope.AddCustomer = function () {
            $http({ url: addCustomerUrl, method: 'POST', data: { customer: $scope.customer } })
                .success(function(data) {
                    console.log(data);
                    swal('Success!', 'Customer added successfully', 'success');
                })
                .error(function() {
                    swal('Error', 'Customer was not added', 'error');
                });
        }

        $scope.EditCustomer = function() {
            $http({ url: editCustomerUrl, method: 'POST', data: { customer: $scope.customer } })
                .success(function(data) {
                    console.log(data);
                    swal('Success!', 'Customer edited successfully', 'success');
                })
                .error(function() {
                    swal('Error', 'Customer was not saved', 'error');
                });
        }
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