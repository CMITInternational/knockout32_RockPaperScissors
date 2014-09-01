(function() {
    define(['/services/http'], function (http) {
        var _url = "/api/Game";

        return {
            setUrl: function(url) {
                _url = url;
            },
            index: function() {
                return http.get(_url, {});
            },
            play: function(data) {
                return http.put(_url, data);
            }
        };
    });
})();