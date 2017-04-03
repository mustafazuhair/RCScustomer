$(function () {
    function split(val) {
        return val.split(/,\s*/);
    }
    function extractLast(term) {
        return split(term).pop();
    }

    $("#EmployeeName").bind("keydown", function (event) {
        if (event.keyCode === $.ui.keyCode.TAB &&
                  $(this).data("autocomplete").menu.active) {
            event.preventDefault();
        }
    })
    $("#EmployeeName").autocomplete({
        source: function (request, response) {
            //define a function to call your Action (assuming UserController)
            $.ajax({
                url: '/DropdownUtility/GetStaff', type: "GET", dataType: "json",
                //query will be the param used by your action method
                data: { query: request.term },
                term: extractLast(request.term),
                success: function (data) {
                    response($.map(data, function (item) {
                        return { label: item.label, value: item.value, Position: item.Designation, EmailAddress: item.EmailAddress };
                    }))
                }
            })
        },
        search: function () {
            // custom minLength
            var term = extractLast(this.value);
            if (term.length < 1) {
                return false;
            }
        },
        focus: function () {
            // prevent value inserted on focus
            return false;
        },
        select: function (event, ui) {
            var terms = split(this.value);
            // remove the current input
            terms.pop();
            // add the selected item
            terms.push(ui.item.label);
            $("#PersonnelKey").val(ui.item.value);
            $("#Position").val(ui.item.Position);
            $("#EmailAddress").val(ui.item.EmailAddress);


            // add placeholder to get the comma-and-space at the end
            terms.push("");
            this.value = terms.join("");
            return false;
        }
    });

});