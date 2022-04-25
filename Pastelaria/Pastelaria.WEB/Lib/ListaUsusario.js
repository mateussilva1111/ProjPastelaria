var usuarios = (function () {
    var config = {
        urls: {
            Index: '',
            putUser:''
        }
    };

    var init = function ($config) {
        config = $config;
    };

    listaUsuarios = function(){
        $.get(config.urls.ListaUsuarios
            ).done(function () {
            }).fail(function (xhr) {

            });
    };

    var put = function (form) {
        debugger;
        var model = $(form).serializeObject();
        $.post(config.urls.putUser, model).done(function (data) {
            console.log(data);

        }).success(function () {
            location.reload();
           
        }).error(function (xhr) {
            alert(xhr.text)
        });
    };


    return {
        init: init,
        putUser: put
    };


})();