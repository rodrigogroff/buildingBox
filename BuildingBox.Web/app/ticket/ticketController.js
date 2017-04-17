'use strict';
angular.module('app.controllers').controller('TicketController',
['$scope', '$rootScope', '$location', 'AuthService', '$stateParams', '$state',
function ($scope, $rootScope, $location, AuthService, $stateParams, $state)
{
	$rootScope.loggedIn = true;
	
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
		if (id > 0)
		{
			$scope.viewModel.updateCommand = "entity";

			Api.Ticket.update({ id: id }, $scope.viewModel, function (data) {
				toastr.success('Ticket saved!', 'Success');
			},
			function (response) {
				toastr.error(response.data.message, 'Error');
			});
		}
		else
		{
			Api.Ticket.add($scope.viewModel, function (data) {
				toastr.success('Ticket added!', 'Success');
			},
			function (response) {
				toastr.error(response.data.message, 'Error');
			});
		}	
	};

	$scope.list = function () {
		$state.go('clientPanel');
	}

}]);
