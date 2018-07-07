(function () {
    "use strict";

    var app = angular.module("movieManagement",
        ["common.services",
            "ui.router",
            "ui.bootstrap"]);

    app.config(["$stateProvider",
                "$urlRouterProvider",
        function ($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise("/");

            $stateProvider
                .state("home", {
                    url: "/",
                    templateUrl: "app/homeView.html"
                })
                // Movies Routes
                .state("movieList", {
                    url: "/api/movies",
                    templateUrl: "app/movies/movieListView.html",
                    controller: "movieListCtrl as vm"
                })
                .state("movieEdit", {
                    url: "/api/movies/edit/:movieId",
                    templateUrl: "app/movies/movieEditView.html",
                    controller: "movieEditCtrl as vm",
                    resolve: {
                        movieResource: "movieResource",

                        movie: function (movieResource, $stateParams) {
                            var movieId = $stateParams.movieId;
                            return movieResource.get({ movieId: movieId }).$promise;
                        }
                    }
                })
                .state("movieCreate", {
                    url: "/api/movies/Create",
                    templateUrl: "app/movies/movieCreateView.html",
                    controller: "movieCreateCtrl as vm"
                })
                .state("movieDetail", {
                    url: "/api/movies/:movieId",
                    templateUrl: "app/movies/movieDetailView.html",
                    controller: "movieDetailCtrl as vm",
                    resolve: {
                        movieResource: "movieResource",

                        movie: function (movieResource, $stateParams) {
                            var movieId = $stateParams.movieId;
                            return movieResource.get({ movieId: movieId }).$promise;
                        }
                    }
                }); 
        }]
    )
    .config(['$qProvider', function ($qProvider) {
        $qProvider.errorOnUnhandledRejections(false);
    }]);

}());