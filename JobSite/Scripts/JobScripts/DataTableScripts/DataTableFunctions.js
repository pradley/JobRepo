//Make a session variable orderchanged set the value to the last order 
//Check if orderchanged is true
// Get what the last order was everytime this script loads 
var orderChanged = sessionStorage.getItem("orderChanged");
var companyAndJobIds = {};
$(function () {
    DisplayFirstTableSet();
    sortCompanysBy(orderChanged);

    //#region EventHandlerSetUp
    $("#Company").click(function () {
        var orderBy = this.getAttribute('data-order');
        if (orderBy === "ascending") {
            sortCompanysBy(orderBy);
            this.setAttribute('data-order', 'descending');
        }
        else if (orderBy === "descending") {
            sortCompanysBy(orderBy);
            this.setAttribute('data-order', 'ascending');
        }
        sessionStorage.setItem("orderChanged", orderBy);
    });

    $("#GlobalSearch").keyup(function () {
        var input = this.value;
        var tableRows = GetJobTableRows();
        tableRows.each(function (index) {
            if (input === "") {
                tableRows.each(function (index) {
                    this.hidden = false;

                });
            }
            else if (!this.innerText.includes(input)) {
                this.hidden = true;
            }
            else {
                this.hidden = false;
            }

            //TODO Add a No results row 

        });
    });


    $(".page-item").click(function () {
        //Disable previously active button
        var activePageButton = $("li.active");
        activePageButton.removeClass("active");

        //Hide previous rows
        var lowerAndUpperBounds = activePageButton.attr("data-rows").split("-");
        var lowerBound = parseInt(lowerAndUpperBounds[0]);
        var upperBound = parseInt(lowerAndUpperBounds[1]);
        var tableRows = GetJobTableRows();
        tableRows.slice(lowerBound, upperBound).each(function (index) { this.hidden = true; });

        //Activate New button 
        var clickedPageButton = this;
        clickedPageButton.classList.add("active");
        lowerAndUpperBounds = clickedPageButton.getAttribute("data-rows").split("-");
        lowerBound = parseInt(lowerAndUpperBounds[0]);
        upperBound = parseInt(lowerAndUpperBounds[1]);
        tableRows.slice(lowerBound, upperBound).each(function (index) { this.hidden = false; });

    });
    //#endregion
});

function sortCompanysBy(order) {
    var buttonClicked = this;

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

                                companyAndJobIds[companyNameID] = editDeleteHTML;
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

function GetJobTableRows() {
    var jobsTable = $('.table');
    var tableRows = jobsTable.find('tr');
    return tableRows;
}

function DisplayFirstTableSet() {
    var tableRows = GetJobTableRows();
    tableRows.slice(11, tableRows.length).each(function (index) { this.hidden = true; });
}
