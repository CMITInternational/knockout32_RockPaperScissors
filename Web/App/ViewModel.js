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

        self.player1 = ko.observable(new Person("Person", false, "Rock", self.elements));
        self.player2 = ko.observable(new Person("Computer", true, "Paper", self.elements));

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
            $.ajax({
                type: 'PUT',
                url: 'http://localhost:51478/api/Game',
                cache: false,
                data: ko.toJSON({
                    player1: self.player1(),
                    player2: self.player2()
                }),
                contentType: 'application/json',
                success: function (data) {
                    var element1 = self.elements()[data.GamePlayed.Player1.ChosenElement];
                    var element2 = self.elements()[data.GamePlayed.Player2.ChosenElement];
                    
                    self.player1().chosenElement(element1);
                    self.player2().chosenElement(element2);

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