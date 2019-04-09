$(function () {
    $('.request-btn').click(function () {

        var buttonClicked = this;
        $.ajax({
            //TODO Add error method 
            type: 'POST',
            url: buttonClicked.getAttribute('data-url'),
            data: { methodName: buttonClicked.value, param: $('#jobExists').val() },
            dataType: "json",
            success: function (result) {
                $(`#${buttonClicked.value}`).html(`<div id='QueryAnswer'>${result}</div>`)
                $("#QueryAnswer").animate(
                    {
                        left: '900px',
                        opacity: '0.9'
                    }, 3000
                );
                $("#QueryAnswer").animate({ opacity: '0.0' }, 5000);
                $("#QueryAnswer").animate({ left: '1790px' }, 7000);
                setTimeout(function () {$("#jobExists").val(''); },6000)
            }
        })
    });

});
