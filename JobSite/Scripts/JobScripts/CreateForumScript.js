(function () {
    $('div > input').keyup(function () {

        var emptyField = false;
        $('div > input').each(function ()
        {
            if ($(this).val() == '' && $(this).attr('id')!== "Distcance")
            {
                emptyField = true;
            }
            
        });

        if (emptyField)
        {
            $('#Create').prop('disabled', 'disabled');
        }
        else
        {
            $('#Create').removeAttr('disabled');
        }
    });
})()