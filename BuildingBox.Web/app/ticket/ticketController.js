'use strict';
angular.module('app.controllers').controller('TicketController',
['$scope', '$rootScope', '$location', 'AuthService', '$stateParams', '$state', 'Api', 'ngSelects',
function ($scope, $rootScope, $location, AuthService, $stateParams, $state, Api, ngSelects)
{
	$rootScope.loggedIn = true;

	$scope.selectProject = ngSelects.obterConfiguracao(Api.TicketState, {});
	
	$scope.viewModel = {};

	var id = ($stateParams.id) ? parseInt($stateParams.id) : 0;

	init();

	function init()
	{
		if (id > 0)
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

		if (!$scope.stTitle_fail &&
			!$scope.stDescription_fail)
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

}]);
