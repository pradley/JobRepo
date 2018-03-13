$(function () {
    $('.createButton').click(function () {
        //Need to pass antiforgery token 
        $.ajax({
            type: "POST",
            url: '/Jobs/Create',
            data: $("#createJob").serialize(),
            success: function (result) {
                alert(result);
            }
        })
    });

});