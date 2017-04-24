﻿'use strict';

angular.module('app.controllers').controller('ClientPanelMeetingsController',
['$scope', 'AuthService', '$state', 'ngHistoricoFiltro', 'Api', 'ngSelects', '$rootScope',
function ($scope, AuthService, $state, ngHistoricoFiltro, Api, ngSelects, $rootScope)
{
	$rootScope.loggedIn = true;

	$scope.loading = false;
	$scope.campos = {};
	$scope.list = [];

	$scope.itensporpagina = 15;
	
	init();

	function init() {
		if (ngHistoricoFiltro.filtro)
			ngHistoricoFiltro.filtro.exibeFiltro = false;
	}

	$scope.load(0, $scope.itensporpagina);

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

		Api.UserMeeting.listPage(opcoes, function (data)
		{
			$scope.list = data.results;
			$scope.total = data.count;
			$scope.loading = false;
		});
	}

	$scope.show = function (mdl) {
		$state.go('meeting', { id: mdl.id });
	}

	$scope.new = function () {
		$state.go('meeting-new');
	}

}]);