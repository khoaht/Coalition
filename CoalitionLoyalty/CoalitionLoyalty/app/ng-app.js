var clApp = angular.module('CLApp', ['ui.bootstrap', 'ngRoute', 'ngResource', 'appControllers']);

clApp.config(['$httpProvider', function ($httpProvider) {
    //$httpProvider.responseInterceptors.push('myHttpInterceptor');
    //convert datetime json to normal datetime to display on form
    //$httpProvider.defaults.transformResponse.push(function (responseData) {
    //    convertDateStringsToDates(responseData);
    //    return responseData;
    //});

}])


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

var regexIso8601 = /\/Date\((.*?)\)\//gi;
function convertDateStringsToDates(input) {
    // Ignore things that aren't objects.
    if (typeof input !== "object") return input;

    for (var key in input) {
        if (!input.hasOwnProperty(key)) continue;

        var value = input[key];
        var match;
        // Check for string properties which look like dates.
        // TODO: Improve this regex to better match ISO 8601 date strings.
        if (typeof value === "string" && (match = value.match(regexIso8601))) {
            // Assume that Date.parse can parse ISO 8601 strings, or has been shimmed in older browsers to do so.
            var parsedDate = new Date(parseInt(value.substr(6)));

            var jsDate = new Date(parsedDate);
            input[key] = pad((jsDate.getMonth() + 1)) + '/' + pad(jsDate.getDate()) + '/' + pad(jsDate.getFullYear());

        } else if (typeof value === "object") {
            // Recurse into object
            convertDateStringsToDates(value);
        }
    }
}

function pad(d) {
    return (d < 10) ? '0' + d.toString() : d.toString();
}


//datetime setting 


window.app = clApp;