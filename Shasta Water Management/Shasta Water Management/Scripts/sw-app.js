angular.module('shasta-water', [])
    //Holds the navigation information for the page
    .directive('swNavigation', function () {
        return {
            restrict: 'A',
            controller: ['$scope', function ($scope) {
                $scope.categories = ['Home', 'Search', 'Add'];

                $scope.selected = $scope.categories[0];
            }]
        }
    });