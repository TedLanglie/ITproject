function getResults(input, json) {
    if (input === "")
        return;

    input = input.toUpperCase();

    const CAP = 5;
    let values = [];

    let result = json.filter(function (obj) {
        return obj.Symbol.startsWith(input);
    });

    let counter = 0;
    Object.keys(result).every(key => {
        if (counter >= CAP)
            return false;
        else {
            values[key] = result[key];
            counter++;
            return true;
        }
    })
    return values;
}

function setDropdownTable(tableData, table) {
    removeAllChildNodes(table);

    if (tableData === undefined)
        return;

    let tableBody = document.createElement('tbody');

    tableData.forEach(function (rowData) {
        let row = document.createElement('tr');
        let link = document.createElement('input');
        link.setAttribute("type", "submit");
        link.setAttribute("value", rowData.Symbol);
        link.setAttribute("onclick", "onClickDropdown(rowData.Symbol)");
        link.innerHTML = rowData.Symbol;
        row.appendChild(link);
        tableBody.appendChild(row);
    });

    table.appendChild(tableBody);
}

function onClickDropdown(symbol) {
    let form = document.getElementById("inputform");
    let input = document.getElementById("input");
    input.value = symbol;
    form.submit();
}

function removeAllChildNodes(parent) {
    while (parent.firstChild) {
        parent.removeChild(parent.firstChild);
    }
}

