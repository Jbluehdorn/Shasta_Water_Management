angular.module('directions', ['ngSanitize'])
    .controller('DirectionCtrl', ['$scope', '$http', '$sce', function ($scope, $http, $sce) {
        $scope.customer = customer;
        $scope.CustomerAddress = customer.Address + " " + customer.City + " MO";
        $scope.UserAddress = defaultAddress;

        $scope.GetDirections = function() {
            var request = {
                travelMode: google.maps.TravelMode.DRIVING,
                origin: $scope.UserAddress,
                destination: $scope.CustomerAddress
            }

            directionsService.route(request, function (result, status) {
                if (status == google.maps.DirectionsStatus.OK) {
                    directionsDisplay.setDirections(result);
                    $scope.path = result.routes[0].legs[0].steps;

                    $scope.$digest();
                } else {
                    swal("Error!", "Directions could not be found", "error");
                }
            });
        }
    }]);