'use strict';
angular.module('app.controllers').controller('RegisterController',
['$scope', '$rootScope', '$location', 'AuthService', 
function ($scope, $rootScope, $location, AuthService)
{
	init();

	function init()
	{
		$rootScope.showLogo = true;
	}
		
}]);
