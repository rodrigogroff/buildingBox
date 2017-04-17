'use strict';

angular.module('app.controllers').controller('ClientPanelTicketsController',
['$scope', 'AuthService', '$state', 'ngHistoricoFiltro', 'Api', 'ngSelects','$rootScope',
function ($scope, AuthService, $state, ngHistoricoFiltro, Api, ngSelects, $rootScope)
{
	$rootScope.loggedIn = true;

	$scope.loading = false;
	$scope.campos = { };
	$scope.itensporpagina = 15;

	init();

	function init()
	{
		if (ngHistoricoFiltro.filtro)
			ngHistoricoFiltro.filtro.exibeFiltro = false;
	}

	$scope.search = function ()
	{
		$scope.load(0, $scope.itensporpagina);
		$scope.paginador.reiniciar();
	}

	$scope.load = function (skip, take)
	{
		$scope.loading = true;

		var opcoes = { skip: skip, take: take };

		var filtro = ngHistoricoFiltro.filtro.filtroGerado;

		if (filtro)
			angular.extend(opcoes, filtro);

		Api.Ticket.listPage(opcoes, function (data) {
			$scope.list = data.results;
			$scope.total = data.count;
			$scope.loading = false;
		});
	}

	$scope.show = function (mdl) {
		if (!$scope.permModel.visualizar)
			toastr.error('Access denied!', 'Permission');
		else
			$state.go('ticket', { id: mdl.id });
	}

	$scope.new = function () {
		if (!$scope.permModel.novo)
			toastr.error('Access denied!', 'Permission');
		else
			$state.go('ticket-new');
	}

}]);
