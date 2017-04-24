'use strict';

angular.module('app.directives').directive('ngLogo', function () {

	return {

		replace: true,
		restrict: 'AE',

		scope: {
			
		},

		controller: ['$scope', 'AuthService', function ($scope, AuthService)
		{
			$scope.logOut = function () {
				AuthService.logOut();
				$location.path('/login');
			};

			AuthService.fillAuthData();

			$scope.authentication = AuthService.authentication;

			if (!AuthService.authentication.isAuth)
				$location.path('/login');

		}],
		templateUrl: 'app/_shared/logo/templateNgLogo.html'
	};
});
