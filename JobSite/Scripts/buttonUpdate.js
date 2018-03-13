$(function () {
    $('.analytics-btn').click(function () {
        var buttonClicked = this;
        $.ajax({
            type: 'GET',
            url: buttonClicked.getAttribute('data-url'),
            success: function (result) {
                $(buttonClicked.getAttribute('data-answer')).val(result);
            }
        })
    });

});