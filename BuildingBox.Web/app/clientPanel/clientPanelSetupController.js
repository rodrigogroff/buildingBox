'use strict';
angular.module('app.controllers').controller('ClientPanelSetupController',
['$scope', '$rootScope', '$location', 'AuthService',
function ($scope, $rootScope, $location, AuthService)
{
	$rootScope.loggedIn = true;

}]);
