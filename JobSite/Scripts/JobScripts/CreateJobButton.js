$(function () {
    $('.createButton').click(function () {
        // TODO Need to pass antiforgery token 
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

 //TODO Bug when you submit the first Duplicate entry the alert message doesnt show  