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
        let symbol = document.createElement('a');
        let company = document.createElement('a');

        symbol.innerHTML = rowData.Symbol;
        company.innerHTML = rowData.Company;

        row.onclick = () => {
            let form = document.getElementById("inputform");
            let input = document.getElementById("input");
            input.value = rowData.Symbol;
            form.submit();
        }

        row.appendChild(symbol);
        row.appendChild(company);
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

