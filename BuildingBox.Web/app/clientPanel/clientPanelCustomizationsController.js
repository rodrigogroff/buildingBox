'use strict';

angular.module('app.controllers').controller('ClientPanelCustomizationsController',
['$scope', 'AuthService', '$state', 'ngHistoricoFiltro', 'Api', 'ngSelects', '$rootScope',
function ($scope, AuthService, $state, ngHistoricoFiltro, Api, ngSelects, $rootScope)
{
	$rootScope.loggedIn = true;

	$scope.loading = false;
	$scope.campos = {
		selects: {
			customizationState: ngSelects.obterConfiguracao(Api.CustomizationState, {}),
		}
	};

	$scope.itensporpagina = 15;

	init();

	function init() {
		if (ngHistoricoFiltro.filtro)
			ngHistoricoFiltro.filtro.exibeFiltro = false;
	}

	$scope.search = function () {
		$scope.load(0, $scope.itensporpagina);
		$scope.paginador.reiniciar();
	}

	$scope.load = function (skip, take)
	{
		$scope.loading = true;

		var opcoes = { skip: skip, take: take, fkUser: 0 };

		var filtro = ngHistoricoFiltro.filtro.filtroGerado;

		if (filtro)
			angular.extend(opcoes, filtro);

		delete opcoes.selects;

		Api.UserCustomization.listPage(opcoes, function (data)
		{
			$scope.list = data.results;
			$scope.total = data.count;
			$scope.loading = false;
		});
	}

	$scope.show = function (mdl) {
		$state.go('customization', { id: mdl.id });
	}

	$scope.new = function () {
		$state.go('customization-new');
	}

}]);
