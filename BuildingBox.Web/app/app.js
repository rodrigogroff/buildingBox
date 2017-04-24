'use strict';

var app = angular.module('app', ['ui.bootstrap', 'chieffancypants.loadingBar', 'ngAnimate', 'ui.router', 'angularSpinner', 'perfect_scrollbar', 'ngSanitize', 'ng-currency', 'ui.select', 'ui.select2', 'pasvaz.bindonce', 'app.filters', 'app.services', 'app.directives', 'app.controllers', 'ui.sortable', 'ui.keypress', 'ui.tree', 'ui.mask' ])

.config(['$stateProvider', '$locationProvider', function ($stateProvider, $locationProvider)
{
    $stateProvider

	.state('home', { url: '/', templateUrl: 'app/site/home/home.html', controller: 'HomeController', data: {} })
	.state('login', { url: '/login', templateUrl: 'app/site/login/login.html', controller: 'LoginController', data: {} })
	
	.state('site_register', { url: '/register', templateUrl: 'app/site/register/register.html', controller: 'RegisterController', data: {} })
	.state('site_features', { url: '/features', templateUrl: 'app/site/features/features.html', controller: 'FeaturesController', data: {} })
	.state('site_videos', { url: '/videos', templateUrl: 'app/site/videos/videos.html', controller: 'VideosController', data: {} })
	.state('site_customization', { url: '/site_customization', templateUrl: 'app/site/customization/site_customization.html', controller: 'SiteCustomizationController', data: {} })
	.state('site_simulation', { url: '/simulation', templateUrl: 'app/site/simulation/simulation.html', controller: 'SimulationController', data: {} })
		
	.state('clientPanel', { url: '/clientPanel', templateUrl: 'app/clientPanel/clientPanel.html', controller: 'ClientPanelController', data: {} })
	.state('clientPanel.tickets', { url: '/clientPanel_tickets', templateUrl: 'app/clientPanel/tickets.html', controller: 'ClientPanelTicketsController', data: {} })
	.state('clientPanel.contracts', { url: '/clientPanel_contracts', templateUrl: 'app/clientPanel/contracts.html', controller: 'ClientPanelContractsController', data: {} })
	.state('clientPanel.customizations', { url: '/clientPanel_customizations', templateUrl: 'app/clientPanel/customizations.html', controller: 'ClientPanelCustomizationsController', data: {} })
	.state('clientPanel.setup', { url: '/clientPanel_setup', templateUrl: 'app/clientPanel/setup.html', controller: 'ClientPanelSetupController', data: {} })

	.state('ticket', { url: '/ticket/:id', templateUrl: 'app/ticket/ticket.html', controller: 'TicketController' })
	.state('ticket-new', { url: '/ticket/new', templateUrl: 'app/ticket/ticket.html', controller: 'TicketController' })

	.state('contract', { url: '/contract/:id', templateUrl: 'app/contract/contract.html', controller: 'ContractController' })
	.state('contract-new', { url: '/contract/new', templateUrl: 'app/contract/contract.html', controller: 'ContractController' })

	.state('customization', { url: '/customization/:id', templateUrl: 'app/customization/customization.html', controller: 'CustomizationController' })
	.state('customization-new', { url: '/customization/new', templateUrl: 'app/customization/customization.html', controller: 'CustomizationController' })

	.state('about', { url: '/about', templateUrl: 'app/site/about/about.html', controller: 'AboutController', data: {} })
	.state('otherwise', { url: '/', templateUrl: 'app/site/home/home.html', controller: 'HomeController', data: {} })

    $locationProvider.html5Mode(true);

}]);
 
angular.module('app').config(function ($httpProvider) {

	$httpProvider.interceptors.push('AuthInterceptorService');

	if (!$httpProvider.defaults.headers.get) {
		$httpProvider.defaults.headers.get = {};
	}

	$httpProvider.defaults.headers.get['If-Modified-Since'] = 'Mon, 26 Jul 1997 05:00:00 GMT';
	$httpProvider.defaults.headers.get['Cache-Control'] = 'no-cache no-store';
	$httpProvider.defaults.headers.get['Pragma'] = 'no-cache no-store';

});
