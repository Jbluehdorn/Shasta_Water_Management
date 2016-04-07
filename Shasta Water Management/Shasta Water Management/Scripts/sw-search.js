angular.module('search', [])
    .factory('customerFactory', ['$http', function ($http) {
        var customers;
        return {
            get: function () {
                return $http.get(getCustomersUrl);
            }
        };
    }])
    .controller('searchCtrl', ['customerFactory', '$scope', '$filter', function (customerFactory, $scope, $filter) {
        $scope.customers = [];
        $scope.selectedCustomer = undefined;

        $scope.orderTerm = 'Name';
        $scope.reverse = false;

        //Orders the table by the predicate
        $scope.order = function (predicate) {
            $scope.reverse = $scope.orderTerm === predicate ? !$scope.reverse : false;
            $scope.orderTerm = predicate;
        }

        $scope.customersPerPage = 5;
        $scope.currentPage = 0;
        $scope.pagedCustomers = [];
        $scope.totalPages = function () {
            return $scope.pagedCustomers.length;
        }

        //Moves the current page forward
        $scope.next = function () {
            if ($scope.currentPage < $scope.pagedCustomers.length - 1)
                $scope.currentPage++;
        }

        //Moves the current page backwards
        $scope.prev = function () {
            if ($scope.currentPage > 0)
                $scope.currentPage--;
        }

        //Gives the page numbers for the pagination
        $scope.range = function () {
            var rangeArr = [];

            for (i = $scope.currentPage - 2; i <= $scope.currentPage + 2; i++) {
                if (i >= 0 && i < $scope.pagedCustomers.length)
                    rangeArr.push(i);
            }

            return rangeArr;
        }

        //Filters customers when the search term changes
        $scope.$watch('searchTerm', function (val) {
            $scope.filteredCustomers = $filter('filter')($scope.customers, val);
            $scope.currentPage = 0;
            $scope.updateCustomers($scope.filteredCustomers);
        });

        //Updates paged customers when the per page changes
        $scope.$watch('customersPerPage', function (val) {
            var customers = $scope.filteredCustomers.length ? $scope.filteredCustomers : $scope.customers;
            $scope.currentPage = 0;
            $scope.updateCustomers(customers);
        });

        //Gets all the customers from the server and puts them in the array
        customerFactory.get()
            .success(function (data) {
                console.log(data);
                $scope.customers = $filter('orderBy')(data, 'Name');
                console.log($scope.customers);

                $scope.customers.forEach(function (customer) {
                    customer.CustomerID = parseInt(customer.CustomerID);
                    //customer.LastService = new Date(parseInt(customer.LastService.substr(6)));
                    customer.serviceDateFilteredLong = $filter('date')(customer.LastService, 'longDate');
                    customer.serviceDateFilteredShort = $filter('date')(customer.LastService, 'shortDate');
                    customer.serviceDateFilteredMed = $filter('date')(customer.LastService, 'mediumDate');
                    customer.serviceDateFilteredNormal = $filter('date')(customer.LastService, 'MM/dd/yy');
                });

                $scope.updateCustomers($scope.customers);
            });

        //Updates the paged customers array
        $scope.updateCustomers = function (customers) {
            $scope.pagedCustomers = [];
            for (i = 0; i < Math.ceil(customers.length / $scope.customersPerPage) ; i++) {
                $scope.pagedCustomers[i] = [];
                for (k = 0; k < $scope.customersPerPage; k++) {
                    var index = i * $scope.customersPerPage + k;
                    if (customers[index])
                        $scope.pagedCustomers[i].push(customers[index]);
                }
            }
        }

        $scope.select = function (customer) {
            window.location = window.location + '/' + customer.CustomerID;
        }
    }]);
