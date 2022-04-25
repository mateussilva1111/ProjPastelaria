var cargo = (function () {

    var config = {
        urls: {
            cargos: '',
        }
    };

    var init = function ($config) {
        config = $config;
    };

    var getCargos = function () {
        debugger;
        $.get(config.urls.getCargos
            ).done(function () {
            }).fail(function (xhr) {

            });
    };

    return {
        init: init,
        cargos: getCargos
    };


})();