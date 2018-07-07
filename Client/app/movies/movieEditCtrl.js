(function () {
    "use strict";

    angular
        .module("movieManagement")
        .controller("movieEditCtrl",
                    ["movie",
                    "$state",
                    MovieEditCtrl]);

    function MovieEditCtrl(movie, $state) {
        var vm = this;

        vm.movies = movie;

        vm.title = "Edit: " + vm.movies.Id;

        vm.open = function ($event) {
            $event.preventDefault();
            $event.stopPropagation();

            vm.opened = !vm.opened;
        };

        vm.submit = function (isValid) {
            if (isValid) {
                vm.movies.$update({ movieId: vm.movies.Id }, function (data) {
                    vm.message = "Save Successful";
                });
            } else {
                alert("Please correct the validation errors first.");
            }
        };

        vm.cancel = function () {
            $state.go('movieList');
        };

        vm.delete = function () {
            vm.movies.$delete({ movieId: vm.movies.Id });
            $state.go('movieList');
        };
    }

}());
