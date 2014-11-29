var clApp = angular.module('CLApp', ['ngRoute', 'appControllers']);

clApp.config(['$routeProvider',
  function ($routeProvider) {

      $routeProvider.
        when('/Transaction', {
            templateUrl: 'Transaction/List',
            controller: 'TransactionController'
        }).
        when('/Transaction/Add', {
            templateUrl: 'Transaction/Add',
            controller: 'AddTransactionController'
        }).
        otherwise({
            redirectTo: '/Home'
        });
  }]);


clApp.factory('GlobalService', function ($http, $q) {

    this.getCards = function () {
        var qdefer = $q.defer();
        $http({
            method: 'GET',
            url: '/Transaction/GetCards',
            async: false,
        }).success(function (data, status, headers, config) {
            qdefer.resolve(data);
        });
        return qdefer.promise;
    };
});

window.app = clApp;