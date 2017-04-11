'use strict';

var app = angular.module('app', ['ui.bootstrap', 'chieffancypants.loadingBar', 'ngAnimate', 'ui.router', 'angularSpinner', 'perfect_scrollbar', 'ngSanitize', 'ng-currency', 'ui.select', 'ui.select2', 'pasvaz.bindonce', 'app.filters', 'app.services', 'app.directives', 'app.controllers', 'ui.sortable', 'ui.keypress', 'ui.tree', 'ui.mask' ])

.config(['$stateProvider', '$locationProvider', function ($stateProvider, $locationProvider)
{
    $stateProvider

	.state('home', { url: '/', templateUrl: 'app/home/home.html', controller: 'HomeController', data: {} })
	.state('videos', { url: '/videos', templateUrl: 'app/videos/videos.html', controller: 'VideosController', data: {} })
	.state('simulation', { url: '/simulation', templateUrl: 'app/simulation/simulation.html', controller: 'SimulationController', data: {} })
	.state('about', { url: '/about', templateUrl: 'app/about/about.html', controller: 'AboutController', data: {} })

	.state('otherwise', { url: '/', templateUrl: 'app/home/home.html', controller: 'HomeController', data: {} })

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
