var endereco = (function () {
    var config = {
        urls: {
            index: '',
            putEndereco: '',
            postEndereco: ''
        }
    };

    var init = function ($config) {
        config = $config;
    };

    var put = function (form) {
        debugger;
        var model = $(form).serializeObject();

        $.post(config.urls.putEndereco, model).done(function () {
            location.reload();
        }).fail(function (xhr) {
            alert(xhr.text)

        });
    };

    var post = function (form) {
        debugger;
        var model = $(form).serializeObject();

        $.post(config.urls.postEndereco, model).done(function () {
            location.reload();
        }).fail(function (xhr) {
            alert(xhr.text)

        });
    };

    return {
        init: init,
        putEndereco: put,
        postEndereco: post

    };


})();