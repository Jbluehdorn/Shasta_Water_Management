angular.module('customer-profile', [])
    .controller('profileCtrl', ['$scope', function ($scope) {
        $scope.customer = customer;
        console.log($scope.customer);
        $scope.customer.LastService = new Date(parseInt($scope.customer.LastService.substr(6)));

        //Prevents issues with setting the date directly
        $scope.customer.NextServiceDate = new Date($scope.customer.LastService);
        //Adds the service interval dates to the last service date
        $scope.customer.NextServiceDate = new Date($scope.customer.NextServiceDate.setMonth($scope.customer.NextServiceDate.getMonth()  +  $scope.customer.ServiceInterval));

        //Checks if the service date is before or after today
        $scope.withinServiceDate = function() {
            var today = new Date();

            if ($scope.customer.NextServiceDate > today) {
                return true;
            }
            return false;
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
    }])
    //makes an editable input type=text
    .directive('editableField', function () {
        return {
            restrict: 'E',
            templateUrl: '/Template/EditableTemplate.html',
            scope: {
                field: '=',
                header: '='
            },
            controller: ['$scope', function ($scope) {
                $scope.editable = false;

                $scope.changeEditMode = function () {
                    if (!$scope.editable) {
                        $scope.fieldCopy = angular.copy($scope.field);
                    } else {
                        $scope.field = $scope.fieldCopy;
                    }

                    $scope.editable = !$scope.editable;
                }
            }]
        }
    })
    //makes an editable textarea
    .directive('editableTextarea', function () {
        return {
            restrict: 'E',
            templateUrl: '/Template/EditableTextareaTemplate.html',
            scope: {
                field: '=',
                header: '='
            },
            controller: ['$scope', function ($scope) {
                $scope.editable = false;

                $scope.changeEditMode = function () {
                    if (!$scope.editable) {
                        $scope.fieldCopy = angular.copy($scope.field);
                    } else {
                        $scope.field = $scope.fieldCopy;
                    }

                    $scope.editable = !$scope.editable;
                }
            }]
        }
    });