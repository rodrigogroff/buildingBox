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

}]);
