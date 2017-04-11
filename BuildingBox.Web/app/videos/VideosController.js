'use strict';
angular.module('app.controllers').controller('VideosController',
['$scope', '$rootScope', '$location', 'AuthService', 
function ($scope, $rootScope, $location, AuthService)
{
	init();

	function init() {
		var absUrl = $location.path();

		console.log(absUrl);

		if (absUrl == '/home' || absUrl == '/') {
			$rootScope.btnHomeStyle = 'btn-warning';
			$rootScope.btnVideoStyle = '';
		}
		else if (absUrl == '/videos') {
			$rootScope.btnHomeStyle = '';
			$rootScope.btnVideoStyle = 'btn-warning';
		}
	}
}]);
