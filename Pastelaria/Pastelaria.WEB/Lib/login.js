var login = (function () {

    var config = {
        urls: {
            index: '',
            postlogin: '',
            cadastro: ''
        }
    };

    var init = function ($config) {
        config = $config;
    };

    var post = function (form) {
      
        var model = $(form).serializeObject();
        
        $.post(config.urls.postlogin, model).done(function () {
            debugger;
            window.location.href = config.urls.index
            console.log("sucesso");
           
        }).fail(function (xhr) {
            console.log("erro");
        });
    };

    var cadastro = function (form) {

        var model = $(form).serializeObject();

        $.post(config.urls.cadastro, model).done(function () {

        }).success(function () {
            location.reload();
        }).fail(function (xhr) {
            console.log("erro");
        });
    };

   
    
    return {
        init: init,
        postlogin: post,
        cadastro: cadastro
    };
})();
