
jQuery.extend({

    initTooltip: function () {
        $("*[data-toggle='tooltip']").tooltip();
    },

    origin: function () {
        return window.location.protocol + "//" + window.location.host;
    },

    btnLoading: function (selector) {
        $(selector).attr('data-loading-text', 'Procesando...');
    },

    startPageLoading: function () {
        $('body').block({
            //message: '<i class="fa fa-spinner fa-spin fa-2x"></i>',
            message: '',
            overlayCSS: {
                backgroundColor: '#fff',
                opacity: 0.8,
                cursor: 'wait',
                'box-shadow': '0 0 0 1px #ddd'
            },
            css: {
                border: 0,
                padding: 0,
                backgroundColor: 'none'
            }
        });
    },

    stopPageLoading: function () {
        $('body').unblock();
    },

    startElementLoading: function (selector) {
        $(selector).block({
            message: '<i class="fa fa-spinner fa-spin fa-2x text-primary"></i>',
            //message: '',
            overlayCSS: {
                backgroundColor: '#fff',
                opacity: 0.8,
                cursor: 'wait',
                'box-shadow': '0 0 0 1px #ddd'
            },
            css: {
                border: 0,
                padding: 0,
                backgroundColor: 'none'
            }
        });
    },

    stopElementLoading: function (selector) {
        $(selector).unblock();
    },

    formEnter: function (selectorFrm, selectorClick) {
        $(selectorFrm).keypress(function (e) {
            if (e.which === 13) {
                e.preventDefault();
                $(selectorClick).click();
            }
        });
    },
});

window.paceOptions = {
    ajax: false,
    restartOnRequestAfter: false,
};

function __setCookie(name, value, exdays) {
    var d, expires;
    exdays = exdays || 1;
    d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    expires = "expires=" + d.toUTCString();
    document.cookie = name + "=" + value + "; " + expires;
}

function __getCookie(name) {
    var cookie, c;
    cookies = document.cookie.split(';');
    for (var i = 0; i < cookies.length; i++) {
        c = cookies[i].split('=');
        if (c[0] == name) {
            return c[1];
        }
    }
    return "";
}

var __defaultParsleyForm = function () {
    return {
        successClass: 'has-success',
        errorClass: 'has-error',
        classHandler: function (ps) {
            var $el = $(ps.$element);
            if (typeof $el.attr('readonly') == 'undefined') {
                return $el.closest('.form-group, td');
            } else {
                return '';
            }
        },
        errorsContainer: function errorsContainer(ps) {
            var $el = $(ps.$element);
            var type = $el.attr('type');
            if (typeof type != 'undefined') {
                type = type.toLowerCase();
                if (type == 'checkbox' || type == 'radio') {
                    return $el.closest('[data-content-group]');
                }
                if (type == 'file') {
                    return $el.closest('[data-content-file]');
                }
            }
        },
        //errorsWrapper: '<ul class="help-block list-unstyled" style="padding-left:3px;"></ul>'
        errorsWrapper: ''
    };
};
