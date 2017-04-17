'use strict';
angular.module('app.controllers').controller('SimulationController',
['$scope', '$rootScope', '$location', 'AuthService', 
function ($scope, $rootScope, $location, AuthService)
{
	$rootScope.loggedIn = undefined;
	$rootScope.showLogo = true;
	
	$rootScope.btnHomeStyle = '';
	$rootScope.btnFeatureStyle = '';
	$rootScope.btnCustomStyle = '';
	$rootScope.btnVideoStyle = '';
	$rootScope.btnSimStyle = 'btn-warning';
	$rootScope.btnAboutStyle = '';

}]);
