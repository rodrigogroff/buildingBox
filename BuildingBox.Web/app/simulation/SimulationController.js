'use strict';
angular.module('app.controllers').controller('SimulationController',
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
			$rootScope.btnCustomStyle = '';
			$rootScope.btnVideoStyle = '';
			$rootScope.btnSimStyle = '';
			$rootScope.btnAboutStyle = '';
		}
		else if (absUrl == '/features') {
			$rootScope.btnHomeStyle = '';
			$rootScope.btnFeatureStyle = 'btn-warning';
			$rootScope.btnCustomStyle = '';
			$rootScope.btnVideoStyle = '';
			$rootScope.btnSimStyle = '';
			$rootScope.btnAboutStyle = '';
		}
		else if (absUrl == '/customization') {
			$rootScope.btnHomeStyle = '';
			$rootScope.btnFeatureStyle = '';
			$rootScope.btnCustomStyle = 'btn-warning';
			$rootScope.btnVideoStyle = '';
			$rootScope.btnSimStyle = '';
			$rootScope.btnAboutStyle = '';
		}
		else if (absUrl == '/videos') {
			$rootScope.btnHomeStyle = '';
			$rootScope.btnFeatureStyle = '';
			$rootScope.btnCustomStyle = '';
			$rootScope.btnVideoStyle = 'btn-warning';
			$rootScope.btnSimStyle = '';
			$rootScope.btnAboutStyle = '';
		}
		else if (absUrl == '/simulation') {
			$rootScope.btnHomeStyle = '';
			$rootScope.btnFeatureStyle = '';
			$rootScope.btnCustomStyle = '';
			$rootScope.btnVideoStyle = '';
			$rootScope.btnSimStyle = 'btn-warning';
			$rootScope.btnAboutStyle = '';
		}
		else if (absUrl == '/about') {
			$rootScope.btnHomeStyle = '';
			$rootScope.btnFeatureStyle = '';
			$rootScope.btnCustomStyle = '';
			$rootScope.btnVideoStyle = '';
			$rootScope.btnSimStyle = '';
			$rootScope.btnAboutStyle = 'btn-warning';
		}
	}
}]);
