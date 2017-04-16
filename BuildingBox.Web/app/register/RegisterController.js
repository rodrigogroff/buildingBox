'use strict';
angular.module('app.controllers').controller('RegisterController',
['$scope', '$rootScope', '$location', 'AuthService', 'ngSelects', 'Api',
function ($scope, $rootScope, $location, AuthService, ngSelects, Api)
{
	$rootScope.loggedIn = undefined;
	$rootScope.showLogo = false;

	$rootScope.btnHomeStyle = '';
	$rootScope.btnFeatureStyle = '';
	$rootScope.btnCustomStyle = '';
	$rootScope.btnVideoStyle = '';
	$rootScope.btnSimStyle = '';
	$rootScope.btnAboutStyle = '';

	$scope.registered = false;

	$scope.selectCountry = ngSelects.obterConfiguracao(Api.Country, {});
	$scope.selectGMT = ngSelects.obterConfiguracao(Api.GMT, {});

	$scope.viewModel = {};

	var invalidCheck = function (element) {
		if (element == undefined)
			return true;
		else
			if (element.length == 0)
				return true;

		return false;
	}

	var invalidEmail = function (element)
	{
		if (element == undefined)
			return true;
		else
		{
			if (element.length == 0)
				return true;

			if (element.indexOf('@') == -1)
				return true;
			else
				return false;
		}
	}

	$scope.proceedToLogin = function ()
	{
		$location.path('/login');
	}

	$scope.register = function () 
	{
		$scope.stCompanyName_fail = invalidCheck($scope.viewModel.stClientName);
		$scope.stCity_fail = invalidCheck($scope.viewModel.stCityName);
		$scope.stEmail_fail = invalidEmail($scope.viewModel.stContactEmail);
		$scope.stPassword_fail = invalidCheck($scope.viewModel.stPassword);
		$scope.fkCountry_fail = $scope.viewModel.fkCountry == undefined;
		$scope.fkGMT_fail = $scope.viewModel.fkDesiredGMT == undefined;

		if ($scope.viewModel.stPassword == undefined)
			$scope.stConfirmationFail = true;
		else
			$scope.stConfirmationFail = $scope.viewModel.stPassword != $scope.viewModel.stPasswordConf || $scope.viewModel.stPassword.length == 0

		if (!$scope.stCompanyName_fail &&
			!$scope.stCity_fail &&
			!$scope.stEmail_fail &&
			!$scope.stPassword_fail &&
			!$scope.stConfirmationFail &&
			!$scope.fkCountry_fail &&
			!$scope.fkGMT_fail)
		{
			Api.Register.add($scope.viewModel, function (data)
			{
				$scope.registered = true;
			},
			function (response) {
				$scope.message = response;
			});
		}	
	};
		
}]);
