function refreshValidate(container) {
    $(container).find("form").each(function (index) {
        var control = $(this);
        control.removeData("validator");
        control.removeData("unobtrusiveValidation");
        $.validator.unobtrusive.parse(control[0]);
    });
    $("[data-valmsg-summary]").click(function () {
        ClearErrors();
    });
    $(".validation-summary-errors").each(function () {
        var summary = $(this);
        summary.delay(6000).fadeOut(2000);
    });
}
function waitButton(element, msg) {
    if (msg == null || msg == undefined)
        msg = 'Carregando...';

    var button = $(element);
    if (button.is("input")) {
        var val = button.val();

        button.attr('data-value', val);
        button.val(msg);
        button.attr('disabled', 'disabled');
    }
    else {
        var val = button.html();

        button.attr('data-value', val);
        button.html(msg).attr('disabled', 'disabled');
    }
}
function readyButton(element) {
    var button = $(element);
    if (button.is("input")) {
        var val = button.attr('data-value');
        button.val(val);
        button.removeAttr('disabled');
    }
    else {
        var val = button.attr('data-value');
        button.html(val).removeAttr('disabled');
    }
}
function successMessage(message, callback) {
    window.top.$("#success_msg_text").text(message);
    window.top.$("#success_msg").show();
    $("#success_msg").delay(5000).fadeOut(2000);
    if (callback)
        callback();
}

function errorMessage(message) {
    var container = window.top.$("[data-valmsg-summary]").first(), list = container.find("ul");
    if (container.length == 0) {
        $("body").append('<div class="validation-summary-valid" style="display: none;" data-valmsg-summary="true"><ul><li>-- No errors --</li></ul></div>');
        container = window.top.$("[data-valmsg-summary]").first();
        list = container.find("ul");
    }

    if (list) {
        list.empty();
        var lines = message.split('\n');
        $.each(lines, function () {
            $("<li />").html($.trim(this)).appendTo(list);
        });
        container.addClass("validation-summary-errors").removeClass("validation-summary-valid");
        $("[data-valmsg-summary]").first().show().delay(3000).fadeOut(2000);
    }
}
function refreshValidate(container) {
    $(container).find("form").each(function (index) {
        var control = $(this);
        control.removeData("validator");
        control.removeData("unobtrusiveValidation");
        $.validator.unobtrusive.parse(control[0]);
    });
    $("[data-valmsg-summary]").click(function () {
        ClearErrors();
    });
    $(".validation-summary-errors").each(function () {
        var summary = $(this);
        summary.delay(6000).fadeOut(2000);
    });
}

function postForm(button, callback, formId) {
    button = $(button);
    var form = null;
    if (formId)
        form = $("#" + formId);
    else
        form = button.closest("form");
    if (form.valid()) {
        $.ajax({
            url: form.attr("action"), type: "POST", data: form.serialize(),
            success: function (data) {
                callback(data);
            },
            beforeSend: function () { waitButton(button); },
            complete: function () { readyButton(button); }
        });
    }
}

function ajaxForm(control, callback, formId, submit) {
    if (control) control = $(control);
    var form = null;
    if (formId)
        form = $("#" + formId);
    else if (control)
        form = control.closest("form");
    form.ajaxForm({
        beforeSubmit: function (arr, $form, options) {
            if (control) waitButton(control);
        },
        success: function (data) {
            callback(data);
            if (control) {
                readyButton(control);
            }
        },
        error: function () {
            if (control) readyButton(control);
            errorHandler(callback);
        }
    });
    if (submit) {
        form.submit();
    }
}