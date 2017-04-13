﻿'use strict';
angular.module('app.controllers').controller('AboutController',
['$scope', '$rootScope', '$location', 'AuthService', 
function ($scope, $rootScope, $location, AuthService)
{
	init();

	function init()
	{
		var absUrl = $location.path();

		if (absUrl == '/home' || absUrl == '/') {
			$rootScope.btnHomeStyle = 'btn-warning';
			$rootScope.btnFeatureStyle = '';
			$rootScope.btnVideoStyle = '';
			$rootScope.btnSimStyle = '';
			$rootScope.btnAboutStyle = '';
		}
		else if (absUrl == '/features') {
			$rootScope.btnHomeStyle = '';
			$rootScope.btnFeatureStyle = 'btn-warning';
			$rootScope.btnVideoStyle = '';
			$rootScope.btnSimStyle = '';
			$rootScope.btnAboutStyle = '';
		}
		else if (absUrl == '/videos') {
			$rootScope.btnHomeStyle = '';
			$rootScope.btnFeatureStyle = '';
			$rootScope.btnVideoStyle = 'btn-warning';
			$rootScope.btnSimStyle = '';
			$rootScope.btnAboutStyle = '';
		}
		else if (absUrl == '/simulation') {
			$rootScope.btnHomeStyle = '';
			$rootScope.btnFeatureStyle = '';
			$rootScope.btnVideoStyle = '';
			$rootScope.btnSimStyle = 'btn-warning';
			$rootScope.btnAboutStyle = '';
		}
		else if (absUrl == '/about') {
			$rootScope.btnHomeStyle = '';
			$rootScope.btnFeatureStyle = '';
			$rootScope.btnVideoStyle = '';
			$rootScope.btnSimStyle = '';
			$rootScope.btnAboutStyle = 'btn-warning';
		}
	}
}]);
