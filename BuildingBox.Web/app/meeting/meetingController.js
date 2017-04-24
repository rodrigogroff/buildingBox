'use strict';
angular.module('app.controllers').controller('MeetingController',
['$scope', '$rootScope', '$location', 'AuthService', '$stateParams', '$state', 'Api', 'ngSelects',
function ($scope, $rootScope, $location, AuthService, $stateParams, $state, Api, ngSelects)
{
	$rootScope.loggedIn = true;

	$scope.selectMeetingState = ngSelects.obterConfiguracao(Api.MeetingState, {});
	$scope.selectMeetingPlace = ngSelects.obterConfiguracao(Api.MeetingPlace, {});
	$scope.selectGMT = ngSelects.obterConfiguracao(Api.GMT, {});
	
	$scope.viewModel = {};

	var id = ($stateParams.id) ? parseInt($stateParams.id) : 0;

	init();

	function init()
	{
		AuthService.fillAuthData();

		$scope.authentication = AuthService.authentication;

		if (!AuthService.authentication.isAuth) {
			$rootScope.loggedIn = false;
			$location.path('/login');
		}
		else if (id > 0)
		{
			$scope.loading = true;
			
			Api.UserMeeting.get({ id: id }, function (data)
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
		$scope.fkGMT_fail = $scope.viewModel.fkGMT == undefined;
		
		if (!$scope.fkGMT_fail)
		{
			if (id > 0)
			{
				$scope.viewModel.updateCommand = "entity";

				Api.UserMeeting.update({ id: id }, $scope.viewModel, function (data) {
					toastr.success('Meeting saved!', 'Success');

					$scope.viewModel = data;
				},
				function (response) {
					toastr.error(response.data.message, 'Error');
				});
			}
			else
			{
				Api.UserMeeting.add($scope.viewModel, function (data) {
					toastr.success('Meeting added!', 'Success');
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
