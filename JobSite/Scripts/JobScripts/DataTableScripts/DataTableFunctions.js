//Make a session variable orderchanged set the value to the last order 
//Check if orderchanged is true
// Get what the last order was everytime this script loads 
var orderChanged = sessionStorage.getItem("orderChanged");
var companyAndJobIds = {};
$(function () {
    sortCompanysBy(orderChanged);

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
        sessionStorage.setItem("orderChanged", orderBy );
    });

});

function sortCompanysBy(order) {
    var buttonClicked = this;
    debugger;
    if (order) {

        $.ajax({
            type: 'POST',
            url: '/Jobs/OrderBy',
            data: { key: this.innerText, order: order },
            dataType: "json",
            success: function (results) {
                var table = $('.table');
                var resultIndex = 0;
                var tableRows = table.find('tr');
                var tableHeaders = $(tableRows[0]).find("th");

                for (var i = 1; i < tableRows.length; i++) {
                    var cells = tableRows[i].cells;
                    var result = results[resultIndex];
                    var lastCellIndex = cells.length - 1;
                    var lastCell = cells[lastCellIndex];
                    var editDeleteHTML = lastCell.innerHTML;
                    var companyNameID = cells[cells.length - 1].getAttribute("id");
                    var currentCompanyName = result.Company.replace(/ /g, "");
                    var companyIDSelector = "#" + currentCompanyName;


                    for (var c = 0; c < cells.length; c++) {
                        if (c != cells.length - 1) {
                            cells[c].innerText = results[resultIndex][tableHeaders[c].innerText] || '';
                        }
                        //If the Id on the last row isnt the name of the company we are working with 
                        else if (currentCompanyName != companyNameID) {
                            //if you dont exist in collection then replace html
                            if (result != null && companyAndJobIds[companyNameID] == null) {

                                companyAndJobIds[companyNameID] = editDeleteHTML
                                lastCell.innerHTML = $(companyIDSelector)[0].innerHTML;
                            }
                            else {

                                lastCell.innerHTML = companyAndJobIds[companyNameID];
                            }

                        }

                    }
                    resultIndex++;
                }
            }
        });
    }
}
