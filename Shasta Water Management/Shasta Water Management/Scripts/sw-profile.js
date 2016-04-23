angular.module('customer-profile', [])
    .controller('profileCtrl', ['$scope', '$http', function ($scope, $http) {
        $scope.customer = customer;
        console.log($scope.customer);
        try {
            $scope.customer.LastService = new Date(parseInt($scope.customer.LastService.substr(6)));

            //Prevents issues with setting the date directly
            $scope.customer.NextServiceDate = new Date($scope.customer.LastService);
            //Adds the service interval dates to the last service date
            $scope.customer.NextServiceDate = new Date($scope.customer.NextServiceDate.setMonth($scope.customer.NextServiceDate.getMonth() + $scope.customer.ServiceInterval));


            //Checks if the service date is before or after today
            $scope.withinServiceDate = function () {
                var today = new Date();

                if ($scope.customer.NextServiceDate > today) {
                    return true;
                }
                return false;
            }
        } catch (ex) {
            console.log(ex);
        }

        $scope.remove = function (equipment) {
            swal({
                title: "Are you sure?",
                text: "This equipment will be deleted",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Delete",
                closeOnConfirm: false
            },
            function (confirmed) {
                if (confirmed) {
                    $scope.customer.Equipment.splice($scope.customer.Equipment.indexOf(equipment), 1);
                    $scope.$apply();
                    swal("Deleted!", "The equipment was been successfully removed", "success");
                }
            });
        }

        //Logs a customer's service
        $scope.logService = function () {
            $http({ url: logSerivceUrl, method: 'POST', data: { customer: $scope.customer } })
                .success(function(data) {
                    swal({
                        title: 'Success!',
                        text: 'Customer service logged successfully',
                        type: 'success'
                    },
                    function () {
                        window.location = window.location;
                    });
                })
                .error(function() {
                    swal({
                        title: 'Error',
                        text: 'Service was not logged',
                        type: 'error'
                    });
                });
        }

        //Delete's the customer
        $scope.deleteCustomer = function () {
            $http({ url: deleteCustomerUrl, method: 'POST', data: { customer: $scope.customer } })
                .success(function(data) {
                    swal({
                        title: 'Success!',
                        text: 'Customer deleted successfully',
                        type: 'success'
                    },
                    function() {
                        window.location = '/Home/Search';
                    });
                })
                .error(function() {
                    swal({
                        title: 'Error',
                        text: 'Customer not deleted',
                        type: 'error'
                    });
                });
        }
    }]);