'use strict';
angular.module('app.controllers').controller('ClientPanelController',
['$scope', '$rootScope', 'AuthService', '$state', 'ngHistoricoFiltro', 'Api', 'ngSelects', 
function ($scope, $rootScope, AuthService, $state, ngHistoricoFiltro, Api, ngSelects )
{
	$rootScope.loggedIn = true;

	$scope.loading = false;
	$scope.campos = {
		selects: {
			ticketState: ngSelects.obterConfiguracao(Api.TicketState, {}),
		}
	};

	$scope.itensporpagina = 15;

	$scope.search = function () {
		$scope.load(0, $scope.itensporpagina);
		$scope.paginador.reiniciar();
	}

	$scope.load = function (skip, take) {
		$scope.loading = true;

		var opcoes = { skip: skip, take: take };

		var filtro = ngHistoricoFiltro.filtro.filtroGerado;

		if (filtro)
			angular.extend(opcoes, filtro);

		delete opcoes.selects;

		Api.Ticket.listPage(opcoes, function (data) {
			$scope.list = data.results;
			$scope.total = data.count;
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

		AuthService.fillAuthData();

		$scope.authentication = AuthService.authentication;

		if (!AuthService.authentication.isAuth)
			$location.path('/login');
	}

}]);
