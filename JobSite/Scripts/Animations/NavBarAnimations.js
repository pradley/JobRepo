$(function () {

     var firstVisit = sessionStorage.getItem("firstVisit");
     if (!firstVisit) {
        var navBar = $('.invisable > a');
        navBar.each(function () {
            $(this).animate(
                {
                    "padding-right": "230px",
                    opacity: "0.9",
                },
                4000
            )

        });

        $(".invisable").removeClass("invisable").addClass("visable");

        sessionStorage.setItem("firstVisit", "true");
     }
     else {
         $(".invisable").removeClass("invisable").addClass("visable");
     }

});