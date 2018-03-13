$(function () {
    $('.city-btn').click(function () {
        $.ajax({
            type: 'GET',
            url: '/Jobs/GetCitysWithTheMostJobs',
            success: function (result) {
                $('#answer').val(result)
            }
        })
    });

});