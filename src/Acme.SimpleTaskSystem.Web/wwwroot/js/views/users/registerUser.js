(function ($) {

    $(function () {
        var form = $('#RegisterForm');
        form.find('input:first');
        form.validate();
        form.find('button[type=submit]')
            .click(function (e) {
                e.preventDefault()
                if (!form.valid()) {
                    return;
                }
                var input = form.serializeFormToObject();
                abp.services.app.task.register1(input)
                    .done(function () {
                    location.href = "/Tasks";
                });
            });
    });
})(JQuery)
