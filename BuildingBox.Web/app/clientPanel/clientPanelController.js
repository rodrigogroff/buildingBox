'use strict';
angular.module('app.controllers').controller('ClientPanelController',
['$scope', '$rootScope', 'AuthService', '$state', 'ngHistoricoFiltro', 'Api', 'ngSelects', 
function ($scope, $rootScope, AuthService, $state, ngHistoricoFiltro, Api, ngSelects )
{
	$rootScope.loggedIn = true;

	$scope.bAdmin = false;
	$scope.loading = false;
	$scope.campos = {
		selects: {
			ticketState: ngSelects.obterConfiguracao(Api.TicketState, {}),
		}
	};

	$scope.itensporpagina = 15;
	$scope.list = undefined;

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

		delete opcoes.selects;

		Api.Ticket.listPage(opcoes, function (data)
		{
			$scope.list = data.results;
			$scope.total = data.count;

			if (data.results.length > 0)
				if (data.results[0].fkClientType != 1)
					$scope.bAdmin = true;

			$scope.loading = false;
		});
	}

	$scope.show = function (mdl) {
		$state.go('ticket', { id: mdl.id });
	}

	$scope.new = function () {
		$state.go('ticket-new');
	}

	init();

	function init()
	{
		if (ngHistoricoFiltro.filtro)
			ngHistoricoFiltro.filtro.exibeFiltro = false;

		$scope.load(0, $scope.itensporpagina);
	}

}]);
