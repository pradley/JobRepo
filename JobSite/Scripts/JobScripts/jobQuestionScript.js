$(function () {
    $('.postRequest-btn').click(function () {

        var buttonClicked = this;
        $.ajax({
            //TODO Add error method 
            type: 'POST',
            url: buttonClicked.getAttribute('data-url'),
            data: { methodName: buttonClicked.value },
            dataType: "json",
            success: function (result) {
                $("#jobExistsAnswer").text(result);
                $("#jobExistsAnswer").animate(
                    {
                        left: '900px',
                        opacity: '0.9'
                    }, 3000
                );
                $("#jobExistsAnswer").animate({ opacity: '0.0' }, 5000);
                $("#jobExistsAnswer").animate({ left: '1790px' }, 7000);
                setTimeout(function () {$("#jobExists").val(''); },6000)
            }
        })
    });

});

function JobExistsHandler() {

    $('.postRequest-btn').click(function () {
        var buttonClicked = this;
        $.ajax({
            //TODO Add error method 
            type: 'POST',
            url: "/Jobs/JobQuery",
            data: { methodName: buttonClicked.val() },
            dataType: "json",
            success: function (result) {
                $("#jobExistsAnswer").text(result);
                $("#jobExistsAnswer").animate(
                    {
                        left: '900px',
                        opacity: '0.9'
                    }, 3000
                );
                $("#jobExistsAnswer").animate({ opacity: '0.0' }, 5000);
                $("#jobExistsAnswer").animate({ left: '1790px' }, 7000);
                setTimeout(function () { $("#jobExists").val(''); }, 6000)
            },
            error: function (result) {
                alert("Request Failed");
            }
        })
    });

}