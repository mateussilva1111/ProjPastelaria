var cargo = (function () {

    var config = {
        urls: {
            index: '',
            putCargo:'',
            postCargo: ''
        }
    };

    var init = function ($config) {
        config = $config;
    };

    var getCargos = function () {
        $.get(config.urls.getCargos
            ).success(function (data) {
                console.log(data);
            }).error(function (xhr) {
                console.log("erro");
            });
    };

    var put = function (form) {
        var model = $(form).serializeObject();
        $.post(config.urls.putCargo, model).done(function (data) {
            console.log(data);

        }).success(function () {
            location.reload(true)
        }).error(function (xhr) {
            alert(xhr.text)
        });
    };

    var post = function (form) {
        var model = $(form).serializeObject();
        $.post(config.urls.postCargo, model).done(function (data) {

        }).success(function () {


            location.reload(true)
        }).error(function (xhr) {
            alert(xhr.text)
        });
    }

 


    return {
        init: init,
        putCargo: put,
        postCargo: post
    };


})();