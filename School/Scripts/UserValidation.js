$("#ParentForm").validate({
    ignore: "",
    rules: {
        name: {
            required: true
        },
        surname: {
            required: true
        },
        email: {
            email: true
        },
        username: {
            required: true
        },
        password: {
            required: true,
            minlength: 6
        }
    },
    messages: {
        name: "Please the parent's name",
        surname: "Please the parent's surname",
        email: "Please enter a valid email address",
        username: "The username is required",
        password: {
            required: "The password is required",
            minlength: "The password must be a minimum of 6 characters"
        }
    },
    highlight: function (element) {
        $(element).closest('.help-block').removeClass('valid');
        // display OK icon
        $(element).closest('.form-group').removeClass('has-success').addClass('has-error').find('.symbol').removeClass('ok').addClass('required');
        // add the Bootstrap error class to the control group
        $(".tab-content").find("div.tab-pane:hidden:has(div.has-error)").each(function () {
            var id = $(this).attr("id");
            $('a[href="#' + id + '"]').tab('show');
        });
    },
    unhighlight: function (element) {// revert the change done by hightlight
        $(element).closest('.form-group').removeClass('has-error');
        // set error class to the control group
    },
    success: function (label, element) {
        label.addClass('help-block valid');
        // mark the current input as valid and display OK icon
        $(element).closest('.form-group').removeClass('has-error').addClass('has-success').find('.symbol').removeClass('required').addClass('ok');
    }
});

$("#TeacherForm").validate({
    ignore: "",
    rules: {
        name: {
            required: true
        },
        surname: {
            required: true
        },
        email: {
            email: true
        },
        username: {
            required: true
        },
        password: {
            required: true,
            minlength: 6
        }
    },
    messages: {
        name: "Please the teacher's name",
        surname: "Please the teacher's surname",
        email: "Please enter a valid email address",
        username: "The username is required",
        password: {
            required: "The password is required",
            minlength: "The password must be a minimum of 6 characters"
        }
    },
    highlight: function (element) {
        $(element).closest('.help-block').removeClass('valid');
        // display OK icon
        $(element).closest('.form-group').removeClass('has-success').addClass('has-error').find('.symbol').removeClass('ok').addClass('required');
        // add the Bootstrap error class to the control group
        $(".tab-content").find("div.tab-pane:hidden:has(div.has-error)").each(function () {
            var id = $(this).attr("id");
            $('a[href="#' + id + '"]').tab('show');
        });
    },
    unhighlight: function (element) {// revert the change done by hightlight
        $(element).closest('.form-group').removeClass('has-error');
        // set error class to the control group
    },
    success: function (label, element) {
        label.addClass('help-block valid');
        // mark the current input as valid and display OK icon
        $(element).closest('.form-group').removeClass('has-error').addClass('has-success').find('.symbol').removeClass('required').addClass('ok');
    }
});

$("#NewsForm").validate({
    ignore: "",
    rules: {
        title: {
            required: true,
            maxlength: 50
        },
        news_text: {
            required: true
        }
    },
    messages: {
        title: {
            required: "Please enter a title for your news",
            maxlength: "Title cannot exeed 50 letters"
        },
        news_text: "Please enter some news"
    },
    highlight: function (element) {
        $(element).closest('.help-block').removeClass('valid');
        // display OK icon
        $(element).closest('.form-group').removeClass('has-success').addClass('has-error').find('.symbol').removeClass('ok').addClass('required');
        // add the Bootstrap error class to the control group
        $(".tab-content").find("div.tab-pane:hidden:has(div.has-error)").each(function () {
            var id = $(this).attr("id");
            $('a[href="#' + id + '"]').tab('show');
        });
    },
    unhighlight: function (element) {// revert the change done by hightlight
        $(element).closest('.form-group').removeClass('has-error');
        // set error class to the control group
    },
    success: function (label, element) {
        label.addClass('help-block valid');
        // mark the current input as valid and display OK icon
        $(element).closest('.form-group').removeClass('has-error').addClass('has-success').find('.symbol').removeClass('required').addClass('ok');
    }
});

