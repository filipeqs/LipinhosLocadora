(function () {
    "use strict";

    angular
        .module("movieManagement")
        .controller("movieListCtrl",
                    ["movieResource",
                    MovieListCtrl]);

    function MovieListCtrl(movieResource) {
        var vm = this;


        movieResource.query(function(data){
            vm.movies = data;
        });

    }
}());
