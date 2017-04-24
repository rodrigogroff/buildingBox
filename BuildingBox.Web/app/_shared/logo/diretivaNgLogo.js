'use strict';

angular.module('app.directives').directive('ngLogo', function () {

	return {

		replace: true,
		restrict: 'AE',

		scope: {
			
		},

		controller: ['$scope', function ($scope)
		{
			$scope.logOut = function () {
				AuthService.logOut();
				$location.path('/login');
			};

		}],
		templateUrl: 'app/_shared/logo/templateNgLogo.html'
	};
});
