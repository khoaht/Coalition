
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
      $scope.cards = [];

      $http({
          method: 'GET',
          url: '/Transaction/GetCards',
          async: false,
      }).success(function (data, status, headers, config) {
          $scope.cards = data;
      });

      //ENd

      $scope.GO = function () {
          var transactionModel = {
              OriginalPoints: $scope.CaculatedPoints,
              RemmainingPoints: $scope.CaculatedPoints,
              SourceCard: null,
              DestinationCard: $scope.CardId
          };
      }
  }]);

