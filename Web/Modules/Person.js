(function() {
    define(["knockout"], function(ko) {
        return function(name, isComputer, chosenElement, elements) {
            var self = this;

            self.name = ko.observable(name).extend({ required: "Please enter a name", logChange: "name" });
            self.isComputer = ko.observable(isComputer).extend({ logChange: "isComputer" });
            self.chosenElement = ko.observable(chosenElement).extend({ logChange: "chosenElement" });
            self.elements = elements;
        };
    });
})();