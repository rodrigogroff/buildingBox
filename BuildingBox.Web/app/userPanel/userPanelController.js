'use strict';
angular.module('app.controllers').controller('UserPanelController',
['$scope', '$rootScope', '$location', 'AuthService',
function ($scope, $rootScope, $location, AuthService)
{
	$rootScope.loggedIn = true;

	init();

	function init()
	{
		AuthService.fillAuthData();

		$scope.authentication = AuthService.authentication;

		if (!AuthService.authentication.isAuth)
		{
			$rootScope.loggedIn = false;
			$location.path('/login');
		}
	}

}]);
