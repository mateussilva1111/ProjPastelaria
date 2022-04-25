var tarefa = (function () {
    var config = {
        urls: {
            putTarefa: '',
            postTarefa: ''
        }
    };

    var init = function ($config) {
        config = $config;
    };

    var put = function (form) {       
        var model = $(form).serializeObject();
        $.post(config.urls.putTarefa, model).done(function (data) {
            console.log(data);

        }).success(function () {
            location.reload(true)
        }).error(function (xhr) {
            alert(xhr.text)
        });
    };

    var post = function (form) {
        var model = $(form).serializeObject();
        $.post(config.urls.postTarefa, model).done(function (data) {

        }).success(function () {
         
           
            location.reload(true)
        }).error(function (xhr) {
            alert(xhr.text)
        });
    };

    return {
        init: init,
        putTarefa: put,
        postTarefa: post

    };
})();