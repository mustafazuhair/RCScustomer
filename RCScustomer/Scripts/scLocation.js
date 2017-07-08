
$(function () {
    function split(val) {
        return val.split(/,\s*/);
    }
    function extractLast(term) {
        return split(term).pop();
    }

    $("#LocationName").bind("keydown", function (event) {
        if (event.keyCode === $.ui.keyCode.TAB &&
            $(this).data("autocomplete").menu.active) {
            event.preventDefault();
        }
    })
    $("#LocationName").autocomplete({
        source: function (request, response) {
            //define a function to call your Action (assuming UserController)
            $.ajax({
                url: '/DropdownUtility/GetLocationName', type: "GET", dataType: "json",
                //query will be the param used by your action method
                data: { query: request.term },
                // data: { query: request.term },
                term: extractLast(request.term),
                success: function (data) {
                    response($.map(data, function (item) {
                        return { ContactName: item.ContactName, CContactKey: item.CContactKey, LocationContactAddress: item.LocationContactAddress, LocationContactZipCode: item.LocationContactZipCode, LocationContactCityName: item.LocationContactCityName, LocationContactStateName: item.LocationContactStateName, LocationName: item.LocationName, label: item.label, value: item.value };
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
            $("#LocationKey").val(ui.item.value);

            $("#LocationName").val(ui.item.LocationName);
            $("#LocationContactAddress").val(ui.item.LocationContactAddress);
            $("#LocationContactZipCode").val(ui.item.LocationContactZipCode);
            $("#LocationContactCityName").val(ui.item.LocationContactCityName);
            $("#LocationContactStateName").val(ui.item.LocationContactStateName);
            $("#ContactName").val(ui.item.ContactName);
            $("#CContactKey").val(ui.item.CContactKey);

            // add placeholder to get the comma-and-space at the end
            terms.push("");
            this.value = terms.join("");
            return false;
        }
    });

});



$(function () {
    function split(val) {
        return val.split(/,\s*/);
    }
    function extractLast(term) {
        return split(term).pop();
    }

    $("#LocationContactName").bind("keydown", function (event) {
        if (event.keyCode === $.ui.keyCode.TAB &&
            $(this).data("autocomplete").menu.active) {
            event.preventDefault();
        }
    })
    $("#LocationContactName").autocomplete({
        source: function (request, response) {
            //define a function to call your Action (assuming UserController)
            $.ajax({
                url: '/DropdownUtility/GetLocationContactName', type: "GET", dataType: "json",
                //query will be the param used by your action method
                data: { query: request.term, LocationKey: $("#LocationKey").val() },
                // data: { query: request.term },
                term: extractLast(request.term),
                success: function (data) {
                    response($.map(data, function (item) {
                        return { LocationContactAddress: item.LocationContactAddress, LocationContactZipCode: item.LocationContactZipCode, LocationContactCityName: item.LocationContactCityName, LocationContactStateName: item.LocationContactStateName, label: item.label, value: item.value };
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
            $("#LocationContactKey").val(ui.item.value);
            $("#LocationContactAddress").val(ui.item.LocationContactAddress);
            $("#LocationContactZipCode").val(ui.item.LocationContactZipCode);
            $("#LocationContactCityName").val(ui.item.LocationContactCityName);
            $("#LocationContactStateName").val(ui.item.LocationContactStateName);
         

            // add placeholder to get the comma-and-space at the end
            terms.push("");
            this.value = terms.join("");
            return false;
        }
    });

});



$(function () {
    function split(val) {
        return val.split(/,\s*/);
    }
    function extractLast(term) {
        return split(term).pop();
    }

    $("#LocationCityName").bind("keydown", function (event) {
        if (event.keyCode === $.ui.keyCode.TAB &&
            $(this).data("autocomplete").menu.active) {
            event.preventDefault();
        }
    })
    $("#LocationCityName").autocomplete({
        source: function (request, response) {
            //define a function to call your Action (assuming UserController)
            $.ajax({
                url: '/DropdownUtility/GetLocationCityName', type: "GET", dataType: "json",
                //query will be the param used by your action method
                data: { query: request.term, LocationKey: $("#LocationKey").val() },
                term: extractLast(request.term),
                success: function (data) {
                    response($.map(data, function (item) {
                        return { label: item.label, value: item.value };
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
            $("#CityKey").val(ui.item.value);


            // add placeholder to get the comma-and-space at the end
            terms.push("");
            this.value = terms.join("");
            return false;
        }
    });

});


$(function () {
    function split(val) {
        return val.split(/,\s*/);
    }
    function extractLast(term) {
        return split(term).pop();
    }

    $("#CityStateName").bind("keydown", function (event) {
        if (event.keyCode === $.ui.keyCode.TAB &&
            $(this).data("autocomplete").menu.active) {
            event.preventDefault();
        }
    })
    $("#CityStateName").autocomplete({
        source: function (request, response) {
            //define a function to call your Action (assuming UserController)
            $.ajax({
                url: '/DropdownUtility/GetCityStateName', type: "GET", dataType: "json",
                //query will be the param used by your action method
                data: { query: request.term, CityKey: $("#CityKey").val() },
                term: extractLast(request.term),
                success: function (data) {
                    response($.map(data, function (item) {
                        return { label: item.label, value: item.value };
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
            $("#StateCode").val(ui.item.value);


            // add placeholder to get the comma-and-space at the end
            terms.push("");
            this.value = terms.join("");
            return false;
        }
    });

});


$(function () {
    function split(val) {
        return val.split(/,\s*/);
    }
    function extractLast(term) {
        return split(term).pop();
    }

    $("#CustomerContactName").bind("keydown", function (event) {
        if (event.keyCode === $.ui.keyCode.TAB &&
            $(this).data("autocomplete").menu.active) {
            event.preventDefault();
        }
    })
    $("#CustomerContactName").autocomplete({
        source: function (request, response) {
            //define a function to call your Action (assuming UserController)
            $.ajax({
                url: '/DropdownUtility/GetLocationCustomerContactName', type: "GET", dataType: "json",
                //query will be the param used by your action method
                data: { query: request.term, LocationKey: $("#LocationKey").val() },
                // data: { query: request.term },
                term: extractLast(request.term),
                success: function (data) {
                    response($.map(data, function (item) {
                        return { LocationContactAddress: item.LocationContactAddress, LocationContactZipCode: item.LocationContactZipCode, LocationContactCityName: item.LocationContactCityName, LocationContactStateName: item.LocationContactStateName, label: item.label, value: item.value };
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
            $("#LocationContactKey").val(ui.item.value);
            $("#LocationContactAddress").val(ui.item.LocationContactAddress);
            $("#LocationContactZipCode").val(ui.item.LocationContactZipCode);
            $("#LocationContactCityName").val(ui.item.LocationContactCityName);
            $("#LocationContactStateName").val(ui.item.LocationContactStateName);



            // add placeholder to get the comma-and-space at the end
            terms.push("");
            this.value = terms.join("");
            return false;
        }
    });

});


