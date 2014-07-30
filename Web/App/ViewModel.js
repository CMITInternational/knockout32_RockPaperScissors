(function () {
    function Person(name,isComputer,chosenElement, elements) {
        var self = this;

        self.name = ko.observable(name);
        self.isComputer = ko.observable(isComputer);
        self.chosenElement = ko.observable(chosenElement);
        self.elements = elements;
    }

    function Viewmodel() {
        var self = this;

        self.elements = ko.observableArray(["stuff"]);

        self.players = ko.observableArray([new Person("Person", false, "Rock", self.elements),new Person("Computer", true, "Paper", self.elements)]);

        self.winner = ko.observable("");

        $.ajax({
            type: 'GET',
            url: 'http://localhost:51478/api/Game',
            cache: false,
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
            var p1 = self.players()[0];
            var p2 = self.players()[1];
            $.ajax({
                type: 'PUT',
                url: 'http://localhost:51478/api/Game',
                cache: false,
                data: ko.toJSON({
                    player1: p1,
                    player2: p2
                }),
                contentType: 'application/json',
                success: function (data) {
                    var player1 = data.GamePlayed.Player1;
                    var player2 = data.GamePlayed.Player2;
                    
                    var p1 = self.elements()[player1.ChosenElement];
                    var p2 = self.elements()[player2.ChosenElement];
                    
                    self.players()[0].chosenElement(p1);
                    self.players()[1].chosenElement(p2);

                    self.winner(data.GameWinner.Name + ' with ' + self.elements()[data.GameWinner.ChosenElement]);
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