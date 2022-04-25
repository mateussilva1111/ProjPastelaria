var user = (function () {
    var config = {
        urls: {
            index: '',
            putUser: ''
        }
    };

    var init = function ($config) {
        config = $config;
    };

    var put = function (form) {
        var model = $(form).serializeObject();
      
        $.post(config.urls.putUser, model).done(function () {
            reload();
        }).fail(function (xhr) {
            alert(xhr.text)
 
        });
    };

    return {
        init: init,
        putUser: put
        
    };


})();