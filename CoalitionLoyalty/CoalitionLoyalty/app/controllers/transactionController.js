
var appControllers = angular.module('appControllers', []);

appControllers.controller('TransactionController', ['$scope', '$http', '$location',
  function ($scope, $http, $location) {

      $scope.addPoint = function () {
          $location.path("/Transaction/Add");
      }
  }]);

appControllers.controller('AddTransactionController', ['$scope', '$http', '$location', '$q',
  function ($scope, $http, $location, $q) {

      //Get Cards
      var qdefer = $q.defer();
      $http({
          method: 'GET',
          url: '/Transaction/GetCards',
          async: false,
      }).success(function (data, status, headers, config) {
          qdefer.resolve(data);
      });

      $scope.cards = qdefer.promise;
      //ENd

      $scope.GO = function () {
          $location.path("/Transaction/Add");
      }
  }]);

