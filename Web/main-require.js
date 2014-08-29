require.config({
    paths: {
        "jquery": "scripts/jquery-2.1.1.min",
        "bootstrap": "scripts/bootstrap.min",
        "knockout": "Scripts/knockout-3.2.0",
        "text": "Scripts/text",
    },
    shim: {
        'jquery': {
            exports: 'JQuery'
        },
        'bootstrap': {
            deps: ['jquery'],
            exports: 'jQuery'
        }
    }
});

require(["knockout", "text","jquery","bootstrap"], function (ko) {
    $(document).ready(function () {
        ko.components.register("game", {
            viewModel: { require: "/modules/ViewModel.js" },
            template: { require: "text!/templates/game.tmpl.html" }
        });
        ko.components.register("person", {
            viewmodel: { require: '/modules/PersonViewModel.js' },
            template: { require: "text!/templates/person.tmpl.html" }
        });
        ko.extenders.logChange = function (target, option) {
            target.subscribe(function (newValue) {
                console.log(option + ": " + newValue);
            });
            return target;
        };
        ko.extenders.required = function (target, overrideMessage) {
            //add some sub-observables to our observable
            target.hasError = ko.observable();
            target.validationMessage = ko.observable();

            //define a function to do validation
            function validate(newValue) {
                target.hasError(newValue ? false : true);
                target.validationMessage(newValue ? "" : overrideMessage || "This field is required");
            }

            //initial validation
            validate(target());

            //validate whenever the value changes
            target.subscribe(validate);

            //return the original observable
            return target;
        };
        ko.applyBindings();
    });
});
