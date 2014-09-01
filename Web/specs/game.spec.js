/*
Run this tes using
==================
jasmine-node --captureExceptions --runWithRequireJs --requireJsSetup ./requirejs-setup.js ./ --verbose
*/

require.config({
    paths: {
        'services/http': 'http-mock'
    }
});

require(['services/http','../App/services/game'], function(http, game) {
    describe('game', function() {
        it('index should perform http get', function () {
            game.index();
            expect(http.get).toHaveBeenCalled();
        });
        it('play should perform http put', function () {
            game.play();
            expect(http.put).toHaveBeenCalled();
        });
    });
});