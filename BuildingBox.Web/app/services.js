﻿'use strict';

// Demonstrate how to register services
// In this case it is a simple value service.
angular.module('app.services', ['ngResource'])

.service('$confirmacao', ['$modal', '$rootScope', '$q', function ($modal, $rootScope, $q) {

	var deferred;
	var scope = $rootScope.$new();

	scope.resposta = function (res) {
		deferred.resolve(res);
		confirmacao.hide();
	}

	var confirmacao = $modal({ template: 'app/_shared/templateConfirmacao.html', scope: scope, show: false });
	var parentShow = confirmacao.show;

	confirmacao.exibir = function (titulo, mensagem) {
		scope.titulo = titulo;
		scope.mensagem = mensagem;
		deferred = $q.defer();
		parentShow();
		return deferred.promise;
	}

	return confirmacao;
}])

.factory('Api', ['$resource', function ($resource)
{
	var opcoes = {
		'add': { method: 'POST' },
		'list': { method: 'GET', isArray: true },
		'listPage': { method: 'GET', isArray: false },
		'get': { method: 'GET', isArray: false },
		'update': { method: 'PUT' },
		'remove': { method: 'DELETE' }
	};

	return {
		
		Register: $resource('api/register/:id', {}, opcoes),
		User: $resource('api/user/:id', {}, opcoes),
		Country: $resource('api/country/:id', {}, opcoes),
		InfraCity: $resource('api/infraCity/:id', {}, opcoes),
		InfraCountry: $resource('api/infraCountry/:id', {}, opcoes),
		InfraContinent: $resource('api/infraContinent/:id', {}, opcoes),		
		GMT: $resource('api/gmt/:id', {}, opcoes),
		Month: $resource('api/month/:id', {}, opcoes),
		Ticket: $resource('api/ticket/:id', {}, opcoes),
		TicketState: $resource('api/ticketState/:id', {}, opcoes),
		MeetingState: $resource('api/meetingState/:id', {}, opcoes),
		MeetingPlace: $resource('api/meetingPlace/:id', {}, opcoes),
		ContractType: $resource('api/contractType/:id', {}, opcoes),
		ContractState: $resource('api/contractState/:id', {}, opcoes),
		CustomizationState: $resource('api/customizationState/:id', {}, opcoes),
		UserContract: $resource('api/userContract/:id', {}, opcoes),
		UserCustomization: $resource('api/userCustomization/:id', {}, opcoes),
		UserMeeting: $resource('api/userMeeting/:id', {}, opcoes)

	};
}]);
