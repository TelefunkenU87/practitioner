var printButton = document.getElementById("print-button"),
    clearButton = document.getElementById("clear-button"),
    displayJsonButton = document.getElementById("display-json"),
    displayArea = document.getElementById("display-area"),
    criteriaField = document.getElementById("criteria-field"),
    criteriaOperator = document.getElementById("criteria-operator"),
    criteriaValue = document.getElementById("criteria-value"),
    jsonBuilder = document.getElementById("json-builder");

let json = [];

printButton.addEventListener("click", function () {
    var CriteriaField = criteriaField.value;
    var CriteriaOperator = criteriaOperator.value;
    var CriteriaValue = criteriaValue.value;
    jsonBuilder.innerHTML += "<tr> <td>" + CriteriaField + "</td> <td>" + CriteriaOperator + "</td> <td>" + CriteriaValue + "</td> </tr>";
    var criteria = {
        Field: CriteriaField,
        Operator: CriteriaOperator,
        Where: CriteriaValue
    };
    json.push(criteria);
});

clearButton.addEventListener("click", function () {
    jsonBuilder.innerText = "";
    displayArea.innerText = "";
});

displayJsonButton.addEventListener("click", function () {
    //var jsonDisplay = JSON.stringify(json);
    //displayArea.innerText = jsonDisplay;
    var sendJson = {
        "property1": "value1",
        "property2": 3
    };

    $.ajax({
        type: "POST",
        url: 'https://localhost:44395/Test/SendCriteria', //change to your url
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        traditional: true,
        data: JSON.stringify(sendJson), // pass json object to web api
        success: function (result) {
            console.log('Data received: ');
            console.log(result);
        }
    });
})