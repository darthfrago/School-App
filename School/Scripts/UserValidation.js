jQuery.validator.addMethod("textonly", function(value, element)
{
    return this.optional(element) || !(/[^-\.a-zA-Z\s]/.test(value));
}, jQuery.format("Please only enter letters")
);

jQuery.validator.addMethod("alphanumeric", function (value, element) {
    return this.optional(element) || /^[a-zA-Z0-9_]+$/i.test(value);
}
, "Letters, numbers or underscores only please");

$("#ParentForm").validate({
    ignore: "",
    rules: {
        name: {
            required: true,
            textonly: true
        },
        surname: {
            required: true,
            textonly: true
        },
        email: {
            email: true
        },
        username: {
            required: true,
            maxlength: 16,
            alphanumeric: true
        },
        password: {
            required: true,
            minlength: 6
        }
    },
    messages: {
        name: {
            required: "Please enter the parent's name",
            textonly: "Please enter alphabets only"
        },
        surname: {
            required: "Please enter the parent's surname",
            textonly: "Please enter alphabets only"
        },
        email: "Please enter a valid email address",
        username: {
            required: "The username is required",
            maxlength: "The username cannot be more than 16 characters",
            alphanumeric: "Please enter letters, numbers or underscores"
        },
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
            required: true,
            textonly: true
        },
        surname: {
            required: true,
            textonly: true
        },
        email: {
            email: true
        },
        username: {
            required: true,
            maxlength: 16,
            alphanumeric: true
        },
        password: {
            required: true,
            minlength: 6
        }
    },
    messages:
    {
        name: {
            required: "Please enter the teacher's name",
            textonly: "Please enter alphabets only"
        },
        surname: {
            required: "Please enter the teacher's surname",
            textonly: "Please enter alphabets only"
        },
        email: "Please enter a valid email address",
        username: {
            required: "The username is required",
            maxlength: "The username cannot be more than 16 characters",
            alphanumeric: "Please enter letters, numbers or underscores"
        },
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

$("#ProfileForm").validate({
    ignore: "",
    rules: {
        name: {
            required: true,
            textonly: true
        },
        surname: {
            required: true,
            textonly: true
        },
        email: {
            email: true
        },
        username: {
            required: true,
            maxlength: 16,
            alphanumeric: true
        },
        password: {
            minlength: 6
        }
    },
    messages:
    {
        name: {
            required: "Please enter the name",
            textonly: "Please enter alphabets only"
        },
        surname: {
            required: "Please enter the surname",
            textonly: "Please enter alphabets only"
        },
        email: "Please enter a valid email address",
        username: {
            required: "The username is required",
            maxlength: "The username cannot be more than 16 characters",
            alphanumeric: "Please enter letters, numbers or underscores"
        },
        password: {
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

$("#LearnerForm").validate({
    ignore: "",
    rules: {
        name: {
            required: true,
            textonly: true
        },
        surname: {
            required: true,
            textonly: true
        },
        age: {
            required: true,
            number: true
        },
        class_id: {
            required: true
        },
        user_id: {
            required: true
        }
    },
    messages:
    {
        name: {
            required: "Please enter the learner's name",
            textonly: "Please enter alphabets only"
        },
        surname: {
            required: "Please enter the learner's surname",
            textonly: "Please enter alphabets only"
        },
        age: {
            required: "Please enter the learner's age",
            number: "Please enter a number"
        },
        class_id: {
            required: "Please choose a class"
        },
        user_id: {
            required: "Please choose a parent"
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

$("#ContactUsForm").validate({
    ignore: "",
    rules: {
        Name: {
            required: true,
            textonly: true
        },
        PhoneNumber: {
            required: true,
            number: true
        },
        Message: {
            required: true
        }
    },
    messages:
    {
        Name: {
            required: "Please enter your name",
            textonly: "Please enter alphabets only"
        },
        PhoneNumber: {
            required: "Please enter your contact number",
            number: "Please enter a valid number"
        },
        Message: {
            required: "Please enter your message"
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

