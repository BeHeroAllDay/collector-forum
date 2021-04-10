// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    $('#txt').keyup(function (e) {
        if (e.keyCode == 13) {
            var curr = getCaret(this);
            var val = $(this).val();
            var end = val.length;

            $(this).val(val.substr(0, curr) + '<br>' + val.substr(curr, end));
        }

    })
});

function getCaret(el) {
    if (el.selectionStart) {
        return el.selectionStart;
    }
    else if (document.selection) {
        el.focus();

        var r = document.selection.createRange();
        if (r == null) {
            return 0;
        }

        var re = el.createTextRange(),
            rc = re.duplicate();
        re.moveToBookmark(r.getBookmark());
        rc.setEndPoint('EndToStart', re);

        return rc.text.length;
    }
    return 0;
}