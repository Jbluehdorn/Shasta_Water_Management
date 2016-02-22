angular.module('shasta-water', ['search'])
    //Holds the navigation information for the page
    .directive('swNavigation', function () {
        return {
            restrict: 'A',
            controller: ['$scope', function ($scope) {
              $scope.categories = ['Home', 'Search', 'Add'];

              $scope.selected = $scope.categories[0];
              $scope.selected = 'Search';
            }]
        }
    });
