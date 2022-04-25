var users = (function () {

    var config = {
        urls: {
            index: '',
            usuarios: ''
        }
    };
    debugger;

    var init = function ($config) {
        config = $config;
    };

    var getUsers = function () {
        debugger;
        $.get(config.urls.usuarios
            ).done(function () {
            }).fail(function (xhr) {
            });
    };
    console.log(getUsers);

    debugger;

    return {
        init: init,
        usuarios: getUsers
    };


})();