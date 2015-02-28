$(function () {
    $('form').submit(function () {
        var s = true;

        $('.requiredField', this).each(function (i, e) {
            $(e).removeClass("requiredFieldError");
            if ($(e).val() == '') {
                s = false;
                $(e).addClass("requiredFieldError");
                $(e).animate({ left: '+=50' }, 100).animate({ left: '-=50' }, 100).animate({ left: '+=50' }, 100).animate({ left: '-=50' }, 100);
            }
        });

        $('.emailField', this).each(function (i, e) {
            $(e).removeClass("requiredFieldError");
            if (!(/[a-zA-Z0-9.-_]+@[a-zA-Z0-9.-]+\.[a-zA-Z0-9]{2,5}/.test($(e).val()))) {
                s = false;
                $(e).addClass("requiredFieldError");
                $(e).animate({ left: '+=50' }, 100).animate({ left: '-=50' }, 100).animate({ left: '+=50' }, 100).animate({ left: '-=50' }, 100);
            }
        });

        return s;
    });
});