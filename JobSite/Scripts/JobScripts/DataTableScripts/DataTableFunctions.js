$(function () {
    $("#Company").click(function () {
        var orderBy = this.getAttribute('data-order');
        if (orderBy === "ascending")
        {
            sortCompanysBy(orderBy);
            this.setAttribute('data-order', 'descending');
        }
        else if (orderBy === "descending")
        {
            sortCompanysBy(orderBy);
            this.setAttribute('data-order', 'ascending');
        }

    });

});

function sortCompanysBy(order) {
    var buttonClicked = this;
    $.ajax({
        type: 'POST',
        url: '/Jobs/OrderBy',
        data: { key: this.innerText, order: order },
        dataType: "json",
        success: function (result) {
            var table = $('.table');
            var resultIndex = 0;
            var tableRows = table.find('tr');
            var tableHeaders = $(tableRows[0]).find("th");

            for (var i = 1; i < tableRows.length; i++) {
                var cells = tableRows[i].cells;

                for (var c = 0; c < cells.length - 1; c++) {
                    cells[c].innerText = result[resultIndex][tableHeaders[c].innerText] || 'No Data';
                }
                resultIndex++;
            }
        }
    });
}
