'use strict';
angular.module('app.controllers').controller('ClientPanelController',
['$scope', '$rootScope', '$location', 'AuthService',
function ($scope, $rootScope, $location, AuthService)
{
	$rootScope.loggedIn = true;

}]);
