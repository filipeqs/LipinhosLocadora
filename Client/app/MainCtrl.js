(function () {
    "use strict";

    angular
        .module("movieManagement")
        .controller("MainCtrl",
                    ["userAccount",
                    "$state",
                    MainCtrl]);

    function MainCtrl(userAccount, $state) {
        var vm = this;

        vm.userData = {};
        vm.isLoggedIn = false;

        //vm.registerUser = function () {

        //    userAccount.registration.registerUser(vm.userData,
        //        function (data) {
        //            vm.confirmPassword = "";
        //            vm.message = "... Registration successful";
        //            vm.login();
        //        },
        //        function (response) {
        //            vm.isLoggedIn = false;
        //            vm.message = response.statusText + "\r\n";
        //            if (response.data.exceptionMessage)
        //                vm.message += response.data.exceptionMessage;

        //            // Validation errors
        //            if (response.data.modelState) {
        //                for (var key in response.data.modelState) {
        //                    vm.message += response.data.modelState[key] + "\r\n";
        //                }
        //            }
        //        });
        //};

        vm.login = function () {
            userAccount.login.loginUser(vm.userData, function (data) {
                    vm.isLoggedIn = true;
                $state.go('movieList');
                });
                //function (response) {
                //    vm.password = "";
                //    vm.message = response.statusText + "\r\n";
                //    if (response.data.exceptionMessage)
                //        vm.message += response.data.exceptionMessage;

                //    if (response.data.error) {
                //        vm.message += response.data.error;
                //    }
                //}
        };
    }
})();
