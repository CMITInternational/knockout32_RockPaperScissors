(function () {
    function Person(name,isComputer,chosenElement) {
        var self = this;

        self.name = ko.observable(name);
        self.isComputer = ko.observable(isComputer);
        self.chosenElement = ko.observable(chosenElement);
    }

    function Viewmodel() {
        var self = this;

        self.elements = ko.observableArray(["stuff"]);

        self.player1 = ko.observable(new Person("Person", false, "Rock"));
        self.player2 = ko.observable(new Person("Computer", true, "Paper"));

        self.winner = ko.observable(new Person("", false, ""));

        $.ajax({
            type: 'GET',
            url: 'http://localhost:51478/api/Game',
            contentType: 'application/json',
            success: function (data) {
                var elements = [];
                data.forEach(function(element) {
                    elements.push(element);
                });
                self.elements(elements);
            },
            error: function(error) {
                alert('error: ' + error);
            }
        });

        self.play = function () {
            $.ajax({
                type: 'PUT',
                url: 'http://localhost:51478/api/Game',
                data: ko.toJSON({
                    player1: self.player1,
                    player2: self.player2
                }),
                contentType: 'application/json',
                success: function (data) {
                    self.winner(data.GameWinner.Name + ' with ' + data.GameWinner.ChosenElement);
                },
                error: function(error) {
                    alert('error: ' + error);
                }
            });
        };
    };
    
    $(document).ready(function() {
        ko.applyBindings(new Viewmodel());
    });
})();