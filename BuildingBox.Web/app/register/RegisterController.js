'use strict';
angular.module('app.controllers').controller('RegisterController',
['$scope', '$rootScope', '$location', 'AuthService', 'ngSelects', 'Api',
function ($scope, $rootScope, $location, AuthService, ngSelects, Api)
{
	$scope.selectCountry = ngSelects.obterConfiguracao(Api.Country, {});

	init();

	function init()
	{
		$rootScope.showLogo = false;

		$rootScope.btnHomeStyle = '';
		$rootScope.btnFeatureStyle = '';
		$rootScope.btnCustomStyle = '';
		$rootScope.btnVideoStyle = '';
		$rootScope.btnSimStyle = '';
		$rootScope.btnAboutStyle = '';		
	}

	$scope.viewModel = {};

	var invalidCheck = function (element) {
		if (element == undefined)
			return true;
		else
			if (element.length == 0)
				return true;

		return false;
	}

	$scope.register = function () 
	{
		$scope.stCompanyName_fail = invalidCheck($scope.viewModel.stClientName);
		$scope.fkCountry_fail = $scope.viewModel.fkCountry == undefined;

		if (!$scope.stCompanyName_fail &&
			!$scope.fkCountry_fail)
		{
			Api.User.add($scope.viewModel, function (data)
			{
					
			},
			function (response) {
				toastr.error(response.data.message, 'Error');
			});
		}	
	};
		
}]);
