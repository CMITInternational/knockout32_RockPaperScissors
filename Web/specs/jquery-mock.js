(function() {
    define("jquery", [], function() {
        return jasmine.createSpyObj('jQuery',['ajax']);
    });
})
();
