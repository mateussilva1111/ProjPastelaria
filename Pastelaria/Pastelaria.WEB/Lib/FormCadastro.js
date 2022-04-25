var cargo = (function () {

    var config = {
        urls: {
            index: '',
            post: ''
        }
    };

    var init = function ($config) {
        config = $config;
    };

    var cadastroCargo = function (form) {
        var model = $(form).serializeObject();

        
        $.post(config.urls.post, model).done(function () {
            window.location.href = config.urls.index
        }).fail(function (xhr) {

        });
    };

    return {
        init: init,
        post: cadastroCargo
    };
})();
