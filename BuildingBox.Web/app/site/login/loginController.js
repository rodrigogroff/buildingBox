'use strict';
angular.module('app.controllers').controller('LoginController',
['$scope', '$rootScope', '$location', 'AuthService', '$state',
function ($scope, $rootScope, $location, AuthService, $state)
{
	$rootScope.loggedIn = undefined;
	$rootScope.showLogo = false;

	$rootScope.btnHomeStyle = '';
	$rootScope.btnFeatureStyle = '';
	$rootScope.btnCustomStyle = '';
	$rootScope.btnVideoStyle = '';
	$rootScope.btnSimStyle = '';
	$rootScope.btnAboutStyle = '';

	$scope.loading = false;
	$scope.mensagem = "";

	$scope.loginData =
		{
			userName: "",
			password: ""
		};

	$scope.login = function ()
	{
		$scope.loading = true;

		if ($scope.loginData.userName == '' ||
			$scope.loginData.password == '')
		{
			$scope.loading = false;
			$scope.mensagem = 'Please enter valid credentials';
		}
		else
		{
			AuthService.login($scope.loginData).then(function (response)
			{
				$rootScope.loggedIn = true;
				$state.go('clientPanel');
			},
			function (err) {
				$scope.loading = false;
				$scope.mensagem = err.error_description;
			});
		}
	};

}]);
