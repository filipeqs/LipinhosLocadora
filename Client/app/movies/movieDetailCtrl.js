(function () {
    "use strict";

    angular
        .module("movieManagement")
        .controller("movieDetailCtrl",
                ["movie",
                MovieDetailCtrl]);

    function MovieDetailCtrl(movie) {
        var vm = this;

        vm.movies = movie;
    }
}());
