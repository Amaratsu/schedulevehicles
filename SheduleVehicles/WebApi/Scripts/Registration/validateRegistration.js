(function() {

    var app = {
        initialize: function() {
            this.setUpListeners();
        },

        setUpListeners: function() {
            $('form').on('submit', app.submitForm);
            $('form').on('keydown', 'input', app.removeError);
        },

        submitForm: function(e) {
            e.preventDefault();

            var form = $(this),
                submitBtn = form.find('button[type="submit"]');

            if (app.validateForm(form) === false) return false;

            submitBtn.attr('disabled', 'disabled');

            var user = form.serialize();

            $.ajax({
                    url: '/Home/Registration',
                    type: 'POST',
                    data: user
                })
                .done(function(msg) {
                    if (msg === "saveSuccess") {
                        $("#errorEmail").html("");
                        var result =
                            "<div class ='alert alert-success' role='alert'>Registration was successful, you can log in using your email and password..</div>";
                        form.html(result);
                    } else if (msg === "saveError") {
                        var errorResult =
                            "<div class ='alert alert-danger' role='alert'>The error mail is used, enter a different email.</div>";
                        $('#errorEmail').html(errorResult);
                    } else {
                        form.html(msg);
                    }
                })
                .always(function() {
                    submitBtn.removeAttr('disabled');
                });

        },

        validateForm: function(form) {
            var inputs = form.find('input'),
                valid = true;

            $.each(inputs,
                function(index, val) {
                    var input = $(val),
                        val = input.val(),
                        formGroup = input.parents('.form-group'),
                        label = formGroup.find('label').text().toLowerCase(),
                        textError = 'Введите ' + label;

                    if (val.length === 0) {
                        formGroup.addClass('has-error').removeClass('has-success');
                        input.tooltip({
                            placement: 'right',
                            title: textError
                        }).tooltip('show');
                        valid = false;
                    } else {
                        formGroup.addClass('has-success').removeClass('has-error');
                    }
                });
            return valid;
        },

        removeError: function() {
            $(this).tooltip().parents('.form-group').removeClass('has-error');
        }
    }

    app.initialize();
}());