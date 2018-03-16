$(function () {
    $('[class=box]').each(function () {
        $(this).hide();
    });

    $(".animation").click(function () {
        var appearSpeed = 2000;
        var removeSpeed = 1000;
        $('[class=box]').each(function () {
            $(this).fadeIn(appearSpeed);
            $(this).animate(
                {
                    border: "25px",
                    opacity: "0.0",
                },
                removeSpeed


            )
            appearSpeed = appearSpeed + 1000;
            removeSpeed = removeSpeed - 100;
        })

        setTimeout(function () {
            $('[class=box]').each(function () {

               // $(this).fadeOut();
            })
        });

    });





})