var viewModel = ko.observable({ first: 2, second: 5, third: 100 });
var response = ko.observable("Ready");
var gotError = ko.observable(false);

var sendRequest = function (requestType) {
    $.ajax("/api/bindings/sumnumbers", {
        type: "GET",
        data: {
            "numbers.first": viewModel().first,
            "numbers.second": viewModel().second,
            "numbers.op.add": viewModel().add,
            "numbers.op.double": viewModel().double
        },
        success: function (data) {
            gotError(false);
            response("Total: " + data);
        },
        error: function (jqXHR) {
            gotError(true);
            response(jqXHR.status + " (" + jqXHR.statusText + ")");
        }
    });
};
$(document).ready(function () {
    ko.applyBindings();
});