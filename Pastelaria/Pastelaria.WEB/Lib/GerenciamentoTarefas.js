var tarefa = (function () {

    var config = {
        urls: {
            index: '',
            tarefas: ''
        }
    };

    var init = function ($config) {
        config = $config;
    };

    var getTarefas = function () {
        $.get(config.urls.getTarefas
            ).done(function () {
            }).fail(function (xhr) {

            });
    };
    
    return {
        init: init,
        tarefas: getTarefas 
    };

})();

