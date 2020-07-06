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
    let url = "https://localhost:44395/api/ReportData/" + categoryDropdown.options[categoryDropdown.selectedIndex].value;
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
    let url = "https://localhost:44395/api/ReportData/Search?Id=" + fieldDropdown.options[fieldDropdown.selectedIndex].value;
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

//$('#Category').change(function () {
//    var selectedCategory = $("#Category").val();
//    var fieldsSelect = $('#Fields');
//    fieldsSelect.empty();
//    if (selectedCategory != null && selectedCategory != '') {
//        $.getJSON('@Url.Action("GetFields")', { category: selectedCategory }, function (fields) {
//            if (fields != null && !jQuery.isEmptyObject(fields)) {
//                fieldsSelect.append($('<option/>', {
//                    value: null,
//                    text: ""
//                }));
//                $.each(fields, function (index, field) {
//                    fieldsSelect.append($('<option/>', {
//                        value: field.Value,
//                        text: field.Text
//                    }));
//                });
//            };
//        });
//        //$.ajax({
//        //    type: "GET",
//        //    url: "https://localhost:44395/Report/GetFields"
//        //});
//    }
//});

//'use strict';

//$(document).ready(function () {

//    $.extend($, {
//        option: '<option value="0" selected="selected">Select Option</option>'
//    });

//    // Method to clear dropdowns down to a given level
//    $.extend($, {
//        clearDropDown: function (arrayObj, startIndex) {
//            $.each(arrayObj, function (index, value) {
//                if (index >= startIndex) {
//                    $(value).html($.option);
//                }
//            });
//        }
//    });

//    // Method to disable dropdowns down to a given level
//    $.extend($, {
//        disableDropDown: function (arrayObj, startIndex) {
//            $.each(arrayObj, function (index, value) {
//                if (index >= startIndex) {
//                    $(value).attr('disabled', 'disabled');
//                }
//            });
//        }
//    });

//    // Method to disable dropdowns down to a given level
//    $.extend($, {
//        enableDropDown: function (that) {
//            that.removeAttr('disabled');
//        }
//    });

//    // Method to generate and append options
//    $.extend($, {
//        generateOptions: function (element, selection, limit) {
//            var options = '';
//            for (var i = 1; i <= limit; i++) {
//                options += '<option value="' + i + '">Option ' + selection + '-' + i + '</option>';
//            }
//            element.append(options);
//        }
//    });

//    // Select each of the dropdowns
//    var firstDropDown = $('#Category');
//    var secondDropDown = $('#Fields');
//    var thirdDropDown = $('#third');

//    // Hold selected option
//    var firstSelection = '';
//    var secondSelection = '';
//    var thirdSelection = '';

//    // Hold selection
//    var selection = '';

//    // Selection handler for first level dropdown
//    firstDropDown.on('change', function () {

//        // Get selected option
//        firstSelection = firstDropDown.val();

//        // Clear all dropdowns down to the hierarchy
//        $.clearDropDown($('select'), 1);

//        // Disable all dropdowns down to the hierarchy
//        $.disableDropDown($('select'), 1);

//        // Check current selection
//        if (firstSelection === '0') {
//            return;
//        }

//        // Enable second level DropDown
//        $.enableDropDown(secondDropDown);

//        // Generate and append options
//        selection = firstSelection;
//        $.generateOptions(secondDropDown, selection, 4);
//    });

//    // Selection handler for second level dropdown
//    secondDropDown.on('change', function () {
//        secondSelection = secondDropDown.val();

//        // Clear all dropdowns down to the hierarchy
//        $.clearDropDown($('select'), 2);

//        // Disable all dropdowns down to the hierarchy
//        $.disableDropDown($('select'), 2);

//        // Check current selection
//        if (secondSelection === '0') {
//            return;
//        }

//        // Enable third level DropDown
//        $.enableDropDown(thirdDropDown);

//        // Generate and append options
//        selection = firstSelection + '-' + secondSelection;
//        $.generateOptions(thirdDropDown, selection, 4);
//    });

//    // Selection handler for third level dropdown
//    thirdDropDown.on('change', function () {
//        thirdSelection = thirdDropDown.val();

//        // Final work goes here

//    });

//    /*
//     * In this way we can make any number of dependent dropdowns
//     *
//     */

//});