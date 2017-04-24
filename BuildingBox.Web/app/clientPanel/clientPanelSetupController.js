'use strict';
angular.module('app.controllers').controller('ClientPanelSetupController',
['$scope', '$rootScope', '$location', 'AuthService', 'ngSelects','Api',
function ($scope, $rootScope, $location, AuthService, ngSelects, Api)
{
	$rootScope.loggedIn = true;

	$scope.selectCountry = ngSelects.obterConfiguracao(Api.Country, {});
	$scope.selectGMT = ngSelects.obterConfiguracao(Api.GMT, {});

	init();

	function init()
	{
		Api.User.get({ id: 0 }, function (data) {
			$scope.viewModel = data;
			$scope.loading = false;
		}, function (response) { });
	}

	var invalidCheck = function (element) {
		if (element == undefined)
			return true;
		else
			if (element.length == 0)
				return true;

		return false;
	}

	var invalidEmail = function (element) {
		if (element == undefined)
			return true;
		else {
			if (element.length == 0)
				return true;

			if (element.indexOf('@') == -1)
				return true;
			else
				return false;
		}
	}

	$scope.changePassModel =
		{
			stCurrentPassword: '',
			stNewPassword: '',
			stConfirmation: '',
		};

	$scope.changePass = function () {
		
		$scope.stCurrentPasswordFail = invalidCheck($scope.changePassModel.stCurrentPassword);
		$scope.stNewPasswordFail = invalidCheck($scope.changePassModel.stNewPassword);
		$scope.stConfirmationFail = $scope.changePassModel.stNewPassword != $scope.changePassModel.stConfirmation || $scope.changePassModel.stNewPassword.length == 0

		if (!$scope.stCurrentPasswordFail &&
			!$scope.stCurrentPasswordFail &&
			!$scope.stConfirmationFail) {
			$scope.viewModel.updateCommand = "changePassword";

			$scope.viewModel.anexedEntity = $scope.changePassModel;

			Api.User.update({ id: 0 }, $scope.viewModel, function (data) {
				$scope.viewModel.anexedEntity = undefined;
				toastr.success('Password changed!', 'Success');
			},
			function (response) {
				toastr.error(response.data.message, 'Error');
			});
		}
	}

	$scope.save = function ()
	{
		$scope.stCompanyName_fail = invalidCheck($scope.viewModel.stClientName);
		$scope.stCity_fail = invalidCheck($scope.viewModel.stCityName);
		$scope.stEmail_fail = invalidEmail($scope.viewModel.stContactEmail);
		$scope.fkCountry_fail = $scope.viewModel.fkCountry == undefined;
		$scope.fkGMT_fail = $scope.viewModel.fkDesiredGMT == undefined;

		if (!$scope.stCompanyName_fail &&
			!$scope.stCity_fail &&
			!$scope.stEmail_fail &&
			!$scope.fkCountry_fail &&
			!$scope.fkGMT_fail)
		{
			Api.User.update({ id: 0 }, $scope.viewModel, function (data) {
				$scope.viewModel.anexedEntity = undefined;
				toastr.success('Your setup is saved!', 'Success');
			},
			function (response) {
				toastr.error(response.data.message, 'Error');
			});
		}
	};

}]);
