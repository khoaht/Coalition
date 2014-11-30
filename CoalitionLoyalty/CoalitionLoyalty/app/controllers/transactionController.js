
var appControllers = angular.module('appControllers', []);

appControllers.controller('TransactionController', ['$scope', '$http', '$location',
  function ($scope, $http, $location) {

      $scope.addPoint = function () {
          $location.path("/Transaction/Add");
      }
  }]);

appControllers.controller('AddTransactionController', ['$scope', '$http', '$location', '$q',
  function ($scope, $http, $location, $q) {
      $scope.cards = [];
      $scope.ClientName = '';
      $scope.$watch("Email", OnSearch);
      $scope.$watch("SaleAmount", CaculatePoints);

      function CaculatePoints() {
          var amount = parseInt($scope.SaleAmount);
          $scope.CaculatedPoints = amount / 10;

      }

      $scope.Save = function (invalid) {
          $scope.IsSubmitted = true;
          if (!invalid) {
              var trans = {
                  OriginalPoints: $scope.CaculatedPoints,
                  RemmainingPoints: $scope.CaculatedPoints,
                  SourceCard: null,
                  DestinationCard: $scope.CardId
              };

              $http({
                  method: 'POST',
                  url: '/Transaction/CreateTransaction',
                  data: { trans: trans },
                  async: false,
              }).success(function (data, status, headers, config) {
                  $location.path("/Transaction/List");
              });
          }
      }

      function LoadClientCards(clientId) {

          $http({
              method: 'POST',
              url: '/Transaction/GetCards',
              data: { clientId: clientId },
              async: false,
          }).success(function (data, status, headers, config) {
              $scope.cards = data;
          });
      }

      function OnSearch() {

          var email = $scope.Email;
          $http({
              method: 'POST',
              url: '/Transaction/GetClient',
              data: { email: email },
              async: false,
          }).success(function (data, status, headers, config) {

              if (data.FirstName != undefined) {
                  $scope.ClientName = data.FirstName + ' ' + data.LastName + ' ' + data.SurName;
                  // Load client's cards
                  LoadClientCards(data.Id);
              }

              else {
                  $scope.cards = [];
                  $scope.ClientName = '';
              }
          });
      }
  }]);

