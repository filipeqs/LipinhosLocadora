(function(){
    "use strict";

    angular
        .module("common.services")
        .factory("movieResource",
                ["$resource",
                "appSettings",
                movieResource]);
    
    function movieResource($resource, appSettings){
        return $resource(appSettings.serverPath + "/api/:dest", {},
            {
                query: { method: 'GET', params: { dest: "movies" }, isArray: true },
                get: { method: 'GET', url: appSettings.serverPath + '/api/movies/:movieId' },
                update: { method: 'PUT', url: appSettings.serverPath + '/api/movies/edit/:movieId' },
                delete: { method: 'DELETE', url: appSettings.serverPath + '/api/movies/delete/:movieId' },
                save: {method: 'POST', url: appSettings.serverPath + '/api/movies/create',
                    headers: {
                        'Content-Type': 'application / json'
                    }
                }
            });
    }
}());   
