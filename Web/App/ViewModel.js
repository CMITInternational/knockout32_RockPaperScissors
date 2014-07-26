(function () {
    function Person(name,isComputer,element) {
        var self = this;

        self.name = ko.observable(name);
        self.isComputer = ko.observable(isComputer);
        self.element = ko.observable(element);
    }

    function Viewmodel() {
        var self = this;

        self.player1 = ko.observable(new Person("Person", false, "Rock"));
        self.player2 = ko.observable(new Person("Computer", true, "Paper"));
    };
    
    $(document).ready(function() {
        ko.applyBindings(new Viewmodel());
    });
})();