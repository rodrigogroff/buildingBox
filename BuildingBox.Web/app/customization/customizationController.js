'use strict';
angular.module('app.controllers').controller('CustomizationController',
['$scope', '$rootScope', '$location', 'AuthService', '$stateParams', '$state', 'Api', 'ngSelects',
function ($scope, $rootScope, $location, AuthService, $stateParams, $state, Api, ngSelects)
{
	$rootScope.loggedIn = true;
	
	$scope.selectUserContract = ngSelects.obterConfiguracao(Api.UserContract, { });
	$scope.selectCustomizationState = ngSelects.obterConfiguracao(Api.CustomizationState, {});

	$scope.viewModel = {};

	var id = ($stateParams.id) ? parseInt($stateParams.id) : 0;

	init();

	function init()
	{
		AuthService.fillAuthData();

		$scope.authentication = AuthService.authentication;

		if (id > 0)
		{
			$scope.loading = true;
			
			Api.UserCustomization.get({ id: id }, function (data)
			{
				$scope.viewModel = data;
				$scope.loading = false;
			},
			function (response) {
				if (response.status === 404) { toastr.error('Invalid ID', 'Error'); }
				$scope.list();
			});
		}
		else 			
			$scope.viewModel = { };
	}

	var invalidCheck = function (element) {
		if (element == undefined)
			return true;
		else
			if (element.length == 0)
				return true;

		return false;
	}
	
	$scope.save = function ()
	{
		$scope.stVersion_fail = invalidCheck($scope.viewModel.stVersion);
		$scope.stObjective_fail = invalidCheck($scope.viewModel.stObjective);
		$scope.fkContract_fail = $scope.viewModel.fkContract == undefined;
		
		if (!$scope.stVersion_fail &&
			!$scope.stObjective_fail &&
			!$scope.fkContract_fail)
		{
			if (id > 0) {
				$scope.viewModel.updateCommand = "entity";

				Api.UserCustomization.update({ id: id }, $scope.viewModel, function (data) {
					toastr.success('Customization saved!', 'Success');

					$scope.viewModel = data;
				},
				function (response) {
					toastr.error(response.data.message, 'Error');
				});
			}
			else {
				Api.UserCustomization.add($scope.viewModel, function (data) {
					toastr.success('Customization added!', 'Success');
					$state.go('clientPanel');
				},
				function (response) {
					toastr.error(response.data.message, 'Error');
				});
			}
		}
	};

	$scope.list = function () {
		$state.go('clientPanel');
	}

}]);
