'use strict';

let categoryDropdown = document.getElementById("Category"),
    fieldDropdown = document.getElementById("Fields"),
    operatorDropdown = document.getElementById("Operator"),
    friendlyWhereDropdown = document.getElementById("FriendlyWhere");

fieldDropdown.disabled = true;
operatorDropdown.disabled = true;
friendlyWhereDropdown.disabled = true;

categoryDropdown.addEventListener("change", function () {
    //alert("Bang!");
    if (fieldDropdown.disabled === true) {
        categoryDropdown.remove(0);
        fieldDropdown.disabled = false;
        operatorDropdown.disabled = false;
        friendlyWhereDropdown.disabled = false;
    };
    //let url = "https://localhost:44395/api/ReportData/" + categoryDropdown.options[categoryDropdown.selectedIndex].value;
    let url = "/api/ReportData/" + categoryDropdown.options[categoryDropdown.selectedIndex].value;
    fetch(url, {
        method: 'GET'
    })
        .then(function (response) { return response.json(); })
        .then(function (json) {
            // use the json
            // alert(json);
            let docfrag = document.createDocumentFragment();
            for (let i = 0; i < json.length; i++) {
                console.log(json[i].value);
                console.log(json[i].text);
                docfrag.appendChild(new Option(json[i].text, json[i].value));
            }
            fieldDropdown.innerHTML = "";
            fieldDropdown.appendChild(docfrag);
        });
});

fieldDropdown.addEventListener("change", function () {
    //alert("Bang!");
    //let url = "https://localhost:44395/api/ReportData/Search?Id=" + fieldDropdown.options[fieldDropdown.selectedIndex].value;
    let url = "/api/ReportData/Search?Id=" + fieldDropdown.options[fieldDropdown.selectedIndex].value;
    fetch(url, {
        method: 'GET'
    })
        .then(function (response) { return response.json(); })
        .then(function (json) {
            // use the json
            // alert(json);
            let docfrag = document.createDocumentFragment();
            for (let i = 0; i < json.length; i++) {
                console.log(json[i].value);
                console.log(json[i].text);
                docfrag.appendChild(new Option(json[i].text, json[i].value));
            }
            friendlyWhereDropdown.innerHTML = "";
            friendlyWhereDropdown.appendChild(docfrag);
        });
});
