$(function () {

    $('.city-btn').click(function () {

        $.ajax({
            type: 'GET',
            url: '@Url.Action("GetCitysWithTheMostJobs", "Jobs")',
            success: function (result) {
                $('#answer').val(result)
            }
        })
    });

});