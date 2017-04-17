'use strict';
angular.module('app.controllers').controller('FeaturesController',
['$scope', '$rootScope', '$location', 'AuthService', 
function ($scope, $rootScope, $location, AuthService)
{
	$rootScope.loggedIn = undefined;
	init();

	function init()
	{
		var absUrl = $location.path();

		$rootScope.btnHomeStyle = '';
		$rootScope.btnFeatureStyle = 'btn-warning';
		$rootScope.btnCustomStyle = '';
		$rootScope.btnVideoStyle = '';
		$rootScope.btnSimStyle = '';
		$rootScope.btnAboutStyle = '';
	}
		
}]);
