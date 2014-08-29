(function () {
    define(["/modules/Person.js", "knockout"], function (Person, ko) {
        return {
            createViewmodel: function (params, componentInfo) {
                if (params instanceof Person) {
                    return params;
                }
                return new Person(params.name, params.isComputer, params.chosenElement, ko.observableArray(["Rock", "Paper", "Scissors"]));
            }
        };
    });
})();