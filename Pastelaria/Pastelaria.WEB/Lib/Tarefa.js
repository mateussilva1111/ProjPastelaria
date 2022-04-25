var tarefa = (function () {

    var config = {
        urls: {
            index:'',
            getTarefas: ''
        }
    };

    var init = function ($config) {
        config = $config;
    };

    

    var tarefas = function () {
        $.get(config.urls.getTarefas
            ).done(function () {
            }).fail(function (xhr) {

            });
    };

    return {
        init: init,
        get: tarefas
    };


})();