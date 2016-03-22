angular.module('shasta-water', ['search', 'customer-profile', 'customer-form'])
    //Holds the navigation information for the page
    .directive('swNavigation', ['$location', function ($location) {
        return {
            restrict: 'A',
            controller: ['$scope', function ($scope) {
              $scope.categories = ['Home', 'Search', 'Add'];

              
              $scope.page = page;

              $scope.changePage = function (destination) {
                  if (destination == 'Home')
                      destination = '/';
                  console.log(location.origin + '/' + destination);
                  window.location = '/Home/' + destination;
              };
            }]
        }
    }]);