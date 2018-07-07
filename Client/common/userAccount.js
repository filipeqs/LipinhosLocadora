(function () {
    "use strict";

    angular
        .module("common.services")
        .factory("userAccount",
                ["$resource",
                "appSettings",
                userAccount]);

    function userAccount($resource, appSettings) {
        return {
            login: $resource("http://localhost:59502/api/Auth", {},
                {
                    'loginUser': {
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application / json'
                        }
                    }
                })
            //registration: $resource(appSettings.serverPath + "api/Auth/Register", null,
            //    {
            //        'registerUser': { method: 'POST' }
            //    }),
        };
    }
})();
