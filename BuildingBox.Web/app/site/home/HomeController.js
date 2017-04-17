'use strict';
angular.module('app.controllers').controller('HomeController',
['$scope', '$rootScope', '$location', 'AuthService', 
function ($scope, $rootScope, $location, AuthService)
{
	$rootScope.loggedIn = undefined;
	$rootScope.showLogo = true;

	init();

	function init()
	{
		var absUrl = $location.path();

		$rootScope.btnHomeStyle = 'btn-warning';
		$rootScope.btnFeatureStyle = '';
		$rootScope.btnCustomStyle = '';
		$rootScope.btnVideoStyle = '';
		$rootScope.btnSimStyle = '';
		$rootScope.btnAboutStyle = '';
	}
		
}]);
