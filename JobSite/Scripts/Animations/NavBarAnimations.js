$(function () {
    sessionStorage.setItem("firstVisit", "0");
    if (sessionStorage.firstVisit === "0") {

        $('.navbar > a').each(function () {
            $(this).animate(
                {
                    "padding-right": "230px",
                    opacity: "0.9",
                },
                4000
            )

        
        });
        sessionStorage.setItem("firstVisit", "1");
    }

  

});