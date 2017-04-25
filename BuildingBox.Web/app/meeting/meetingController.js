'use strict';
angular.module('app.controllers').controller('MeetingController',
['$scope', '$rootScope', '$location', 'AuthService', '$stateParams', '$state', 'Api', 'ngSelects',
function ($scope, $rootScope, $location, AuthService, $stateParams, $state, Api, ngSelects)
{
	$rootScope.loggedIn = true;

	$scope.selectMeetingState = ngSelects.obterConfiguracao(Api.MeetingState, {});
	$scope.selectMeetingPlace = ngSelects.obterConfiguracao(Api.MeetingPlace, {});
	$scope.selectGMT = ngSelects.obterConfiguracao(Api.GMT, {});
	$scope.selectMonth = ngSelects.obterConfiguracao(Api.Month, {});
	
	$scope.viewModel = { id: 0, nuYear: 0 };

	var id = ($stateParams.id) ? parseInt($stateParams.id) : 0;

	init();

	function init()
	{
		if (id > 0)
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
		{
			var currentDate = new Date();

			$scope.viewModel.nuYear = currentDate.getFullYear();
		}
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
		$scope.fkMonth_fail = $scope.viewModel.fkMonth == undefined;
		$scope.fkPlace_fail = $scope.viewModel.fkMeetingPlace == undefined;
		$scope.nuYear_fail = invalidCheck($scope.viewModel.nuYear);
		$scope.stMeetingMotivation_fail = invalidCheck($scope.viewModel.stMeetingMotivation);
		
		$scope.nuDayHourMinute_fail = invalidCheck($scope.viewModel.nuDay) ||
									  invalidCheck($scope.viewModel.nuHour) ||
								      invalidCheck($scope.viewModel.nuMinute);
		
		if (!$scope.fkGMT_fail && 
			!$scope.fkMonth_fail && 
			!$scope.nuYear_fail &&
			!$scope.stMeetingMotivation_fail &&
			!$scope.nuDayHourMinute_fail )
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
					$state.go('meeting', { id: data.id });
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

	// ============================================
	// person 
	// ============================================

	$scope.addPerson = false;

	$scope.removePerson = function (index, lista)
	{
		$scope.viewModel.updateCommand = "removePerson";
		$scope.viewModel.anexedEntity = $scope.viewModel.people[index];

		Api.UserMeeting.update({ id: id }, $scope.viewModel, function (data)
		{
			toastr.success('Person removed', 'Success');
			$scope.viewModel = data;			
		});		
	}

	$scope.addNewPerson = function ()
	{
		$scope.addPerson = !$scope.addPerson;
	}

	$scope.newPerson = { stName: '', stRole: '' };

	$scope.editPerson = function (mdl)
	{
		$scope.addPerson = true;
		$scope.newPerson = mdl;
	}

	$scope.saveNewPerson = function ()
	{
		$scope.stPersonName_fail = invalidCheck($scope.newPerson.stName);
		$scope.stPersonRole_fail = invalidCheck($scope.newPerson.stRole);

		if (!$scope.stPersonName_fail &&
			!$scope.stPersonRole_fail)
		{
			$scope.addPerson = false;

			$scope.viewModel.updateCommand = "newPerson";
			$scope.viewModel.anexedEntity = $scope.newPerson;

			Api.UserMeeting.update({ id: id }, $scope.viewModel, function (data)
			{
				$scope.newPerson = { stName: '', stRole: '' };
				toastr.success('Person saved', 'Success');
				$scope.viewModel = data;				
			},
			function (response) {
				toastr.error(response.data.message, 'Error');
			});
		}		
	}

}]);
