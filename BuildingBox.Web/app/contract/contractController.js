'use strict';
angular.module('app.controllers').controller('ContractController',
['$scope', '$rootScope', '$location', 'AuthService', '$stateParams', '$state', 'Api', 'ngSelects',
function ($scope, $rootScope, $location, AuthService, $stateParams, $state, Api, ngSelects)
{
	$rootScope.loggedIn = true;

	$scope.selectContractType = ngSelects.obterConfiguracao(Api.ContractType, {});
	$scope.selectGMT = ngSelects.obterConfiguracao(Api.GMT, {});
	$scope.selectContinent = ngSelects.obterConfiguracao(Api.InfraContinent, {});
	$scope.selectCountry = ngSelects.obterConfiguracao(Api.InfraCountry, { scope: $scope, filtro: { campo: 'fkContinent', valor: 'viewModel.fkContinent' } });
	$scope.selectCity = ngSelects.obterConfiguracao(Api.InfraCity, { scope: $scope, filtro: { campo: 'fkCountry', valor: 'viewModel.fkCountry' } });

	$scope.viewModel = {};

	var id = ($stateParams.id) ? parseInt($stateParams.id) : 0;

	init();

	function init()
	{
		if (id > 0)
		{
			$scope.loading = true;
			
			Api.UserContract.get({ id: id }, function (data)
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
			$scope.viewModel = { id: 0};
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
		$scope.stDNS_fail = invalidCheck($scope.viewModel.stDNS);
		$scope.fkContractType_fail = $scope.viewModel.fkContractType == undefined;
		$scope.fkGMT_fail = $scope.viewModel.fkGMT == undefined;
		$scope.fkContinent_fail = $scope.viewModel.fkContinent == undefined;
		$scope.fkCountry_fail = $scope.viewModel.fkCountry == undefined;
		$scope.fkCity_fail = $scope.viewModel.fkCity == undefined;
		
		if (!$scope.stDNS_fail &&
			!$scope.fkContractType_fail &&
			!$scope.fkGMT_fail &&
			!$scope.fkContinent_fail &&
			!$scope.fkCountry_fail &&
			!$scope.fkCity_fail)
		{
			if (id > 0) {
				$scope.viewModel.updateCommand = "entity";

				Api.UserContract.update({ id: id }, $scope.viewModel, function (data) {
					toastr.success('Contract saved!', 'Success');
				},
				function (response) {
					toastr.error(response.data.message, 'Error');
				});
			}
			else {
				Api.UserContract.add($scope.viewModel, function (data) {
					toastr.success('Contract added!', 'Success');
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
