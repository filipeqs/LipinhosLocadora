(function () {
    "use strict";

    angular
        .module("movieManagement")
        .controller("movieCreateCtrl",
                ["movieResource",
                "$state",
                MovieCreateCtrl]);

    function MovieCreateCtrl(movieResource, $state) {
        var vm = this;

        vm.movies = {};

        vm.open = function ($event) {
            $event.preventDefault();
            $event.stopPropagation();

            vm.opened = !vm.opened;
        };

        vm.submit = function (isValid) {
            if (isValid) {
                movieResource.save(vm.movies, function (data) {
                    vm.message = "Save Successful";
                });
            } else {
                alert("Please correct the validation errors first.");
            }
        };

        vm.cancel = function () {
            $state.go('movieList');
        };
    }

}());