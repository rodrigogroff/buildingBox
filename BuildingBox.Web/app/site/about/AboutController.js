﻿'use strict';
angular.module('app.controllers').controller('AboutController',
['$scope', '$rootScope', '$location', 'AuthService', 
function ($scope, $rootScope, $location, AuthService)
{
	$rootScope.loggedIn = undefined;

	init();

	function init()
	{
		var absUrl = $location.path();

		$rootScope.btnHomeStyle = '';
		$rootScope.btnFeatureStyle = '';
		$rootScope.btnVideoStyle = '';
		$rootScope.btnSimStyle = '';
		$rootScope.btnAboutStyle = 'btn-warning';
	}
}]);
