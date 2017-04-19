'use strict';
angular.module('app.controllers').controller('TicketController',
['$scope', '$rootScope', '$location', 'AuthService', '$stateParams', '$state', 'Api', 'ngSelects',
function ($scope, $rootScope, $location, AuthService, $stateParams, $state, Api, ngSelects)
{
	$rootScope.loggedIn = true;

	$scope.selectTicketState = ngSelects.obterConfiguracao(Api.TicketState, {});
	$scope.selectContract = ngSelects.obterConfiguracao(Api.UserContract, {});
	
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
			Api.Ticket.get({ id: id }, function (data)
			{
				$scope.viewModel = data;
				$scope.loading = false;
			},
			function (response) {
				if (response.status === 404) { toastr.error('Invalid ID', 'Error'); }
				$scope.list();
			});
		}
		else {
			$scope.viewModel = { };
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
		$scope.stTitle_fail = invalidCheck($scope.viewModel.stTitle);
		$scope.stDescription_fail = invalidCheck($scope.viewModel.stDescription);
		$scope.fkContract_fail = $scope.viewModel.fkContract == undefined;

		if (!$scope.stTitle_fail &&
			!$scope.stDescription_fail &&
			!$scope.fkContract_fail)
		{
			if (id > 0) {
				$scope.viewModel.updateCommand = "entity";

				Api.Ticket.update({ id: id }, $scope.viewModel, function (data) {
					toastr.success('Ticket saved!', 'Success');
				},
				function (response) {
					toastr.error(response.data.message, 'Error');
				});
			}
			else {
				Api.Ticket.add($scope.viewModel, function (data) {
					toastr.success('Ticket added!', 'Success');
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

	// ============================================
	// messages 
	// ============================================

	$scope.addMessage = false;
	
	$scope.addNewMessage = function ()
	{
		$scope.addMessage = !$scope.addMessage;
	}

	$scope.newMessage = { stMessage: '', fkTicket: undefined, dtLog: undefined };

	$scope.saveNewMessage = function ()
	{
		$scope.stMessage_fail = invalidCheck($scope.newMessage.stMessage);
			
		if (!$scope.stMessage_fail )
		{
			$scope.addMessage = false;

			$scope.viewModel.updateCommand = "newMessage";
			$scope.viewModel.anexedEntity = $scope.newMessage;

			Api.Ticket.update({ id: id }, $scope.viewModel, function (data)
			{
				$scope.newMessage = { stMessage: '', fkTicket: undefined, dtLog: undefined };

				toastr.success('Message saved', 'Success');					
				$scope.viewModel.messages = data.messages;
			},
			function (response) {
				toastr.error(response.data.message, 'Error');
			});
		}		
	}

	// ============================================
	// attendances 
	// ============================================

	$scope.newAttendance = { stMessage: '', fkNewState: undefined };

	$scope.saveNewAttendance = function ()
	{
		$scope.stAtdMsg_fail = invalidCheck($scope.newAttendance.stMessage);
		$scope.fkNewState_fail = $scope.newAttendance.fkNewState == undefined;

		if (!$scope.stAtdMsg_fail &&
			!$scope.fkNewState_fail)
		{
			$scope.viewModel.updateCommand = "newAttendance";
			$scope.viewModel.anexedEntity = $scope.newAttendance;

			Api.Ticket.update({ id: id }, $scope.viewModel, function (data)
			{
				$scope.newAttendance = { stMessage: '', fkNewState: undefined };

				toastr.success('Attendance saved', 'Success');
				$scope.viewModel = data;
			},
			function (response) {
				toastr.error(response.data.message, 'Error');
			});
		}
	}

}]);
