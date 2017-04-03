$(function () {
    function split(val) {
        return val.split(/,\s*/);
    }
    function extractLast(term) {
        return split(term).pop();
    }

    $("#StateName").bind("keydown", function (event) {
        if (event.keyCode === $.ui.keyCode.TAB &&
                  $(this).data("autocomplete").menu.active) {
            event.preventDefault();
        }
    })
    $("#StateName").autocomplete({
        source: function (request, response) {
            //define a function to call your Action (assuming UserController)
            $.ajax({
                url: '/DropdownUtility/GetStateName', type: "GET", dataType: "json",
                //query will be the param used by your action method
                data: { query: request.term },
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

    $("#CityName").bind("keydown", function (event) {
        if (event.keyCode === $.ui.keyCode.TAB &&
                  $(this).data("autocomplete").menu.active) {
            event.preventDefault();
        }
    })
    $("#CityName").autocomplete({
        source: function (request, response) {
            //define a function to call your Action (assuming UserController)
            $.ajax({
                url: '/DropdownUtility/GetCityName', type: "GET", dataType: "json",
                //query will be the param used by your action method
                data: { query: request.term, StateKey: $("#StateCode").val() },
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

    $("#Zipcode").bind("keydown", function (event) {
        if (event.keyCode === $.ui.keyCode.TAB &&
                  $(this).data("autocomplete").menu.active) {
            event.preventDefault();
        }
    })
    $("#Zipcode").autocomplete({
        source: function (request, response) {
            //define a function to call your Action (assuming UserController)
            $.ajax({
                url: '/DropdownUtility/GetZipcode', type: "GET", dataType: "json",
                //query will be the param used by your action method
                data: { query: request.term, dKey: $("#CityKey").val() },
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
            $("#ZIPKey").val(ui.item.value);


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

    $("#CustomerName").bind("keydown", function (event) {
        if (event.keyCode === $.ui.keyCode.TAB &&
                  $(this).data("autocomplete").menu.active) {
            event.preventDefault();
        }
    })
    $("#CustomerName").autocomplete({
        source: function (request, response) {
            //define a function to call your Action (assuming UserController)
            $.ajax({
                url: '/DropdownUtility/GetCustomerName', type: "GET", dataType: "json",
                //query will be the param used by your action method
                data: { query: request.term },
                term: extractLast(request.term),
                success: function (data) {
                    response($.map(data, function (item) {
                        return { CPhone: item.CPhone, CMobile: item.CMobile, CEmail: item.CEmail, RepresentedBy: item.RepresentedBy, Title: item.Title, ContactCell: item.ContactCell, ContactEmail: item.ContactEmail, label: item.label, value: item.value, CustomeAddress: item.CustomeAddress };
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
            $("#CustomerKey").val(ui.item.value);
            $("#CustomerName").val(ui.item.CustomerName);
            $("#CustomeAddress").val(ui.item.CustomeAddress);
            $("#CPhone").val(ui.item.CPhone);
            $("#CEmail").val(ui.item.CEmail);
            $("#RepresentedBy").val(ui.item.RepresentedBy);
            $("#Title").val(ui.item.Title);


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
                url: '/DropdownUtility/GetCustomerContactName', type: "GET", dataType: "json",
                //query will be the param used by your action method
                data: { query: request.term, CustomerKey: $("#CustomerKey").val() },
                term: extractLast(request.term),
                success: function (data) {
                    response($.map(data, function (item) {
                        return { CContactKey: item.CContactKey, CustomerContactName: item.CustomerContactName,label: item.label, value: item.value };
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
            //$("#CContactKey").val(ui.item.value);
            $("#CContactKey").val(ui.item.CContactKey);
            $("#CustomerContactName").val(ui.item.CustomerContactName);


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

    $("#TradeName").bind("keydown", function (event) {
        if (event.keyCode === $.ui.keyCode.TAB &&
            $(this).data("autocomplete").menu.active) {
            event.preventDefault();
        }
    })
    $("#TradeName").autocomplete({
        source: function (request, response) {
            //define a function to call your Action (assuming UserController)
            $.ajax({
                url: '/DropdownUtility/GetTradeName', type: "GET", dataType: "json",
                //query will be the param used by your action method
                data: { query: request.term, CustomerKey: $("#CustomerKey").val() },
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
            $("#TradeKey").val(ui.item.value);


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

    $("#JobStatusName").bind("keydown", function (event) {
        if (event.keyCode === $.ui.keyCode.TAB &&
            $(this).data("autocomplete").menu.active) {
            event.preventDefault();
        }
    })
    $("#JobStatusName").autocomplete({
        source: function (request, response) {
            //define a function to call your Action (assuming UserController)
            $.ajax({
                url: '/DropdownUtility/GetJobStatusName', type: "GET", dataType: "json",
                //query will be the param used by your action method
                data: { query: request.term },
                term: extractLast(request.term),
                success: function (data) {
                    response($.map(data, function (item) {
                        return { JobStatusKey: item.JobStatusKey, JobStatusName: item.JobStatusName,label: item.label, value: item.value };
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
            $("#JobStatusKey").val(ui.item.JobStatusKey);
            $("#JobStatusName").val(ui.item.JobStatusName);


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
                data: { query: request.term, CustomerKey: $("#CustomerKey").val() },
                // data: { query: request.term },
                term: extractLast(request.term),
                success: function (data) {
                    response($.map(data, function (item) {
                        return { LocationName: item.LocationName ,JobName: item.JobName, label: item.label, value: item.value };
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
            $("#JobName").val(ui.item.JobName);
            $("#LocationName").val(ui.item.LocationName);
            
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





// Job Create vendor

$(function () {
    function split(val) {
        return val.split(/,\s*/);
    }
    function extractLast(term) {
        return split(term).pop();
    }

    $("#JobVendorName").bind("keydown", function (event) {
        if (event.keyCode === $.ui.keyCode.TAB &&
            $(this).data("autocomplete").menu.active) {
            event.preventDefault();
        }
    })
    $("#JobVendorName").autocomplete({
        source: function (request, response) {
            //define a function to call your Action (assuming UserController)
            $.ajax({
                url: '/DropdownUtility/GetJobVendorName', type: "GET", dataType: "json",
                //query will be the param used by your action method
                data: { query: request.term, JobKey: $("#JobKey").val() },
                term: extractLast(request.term),
                success: function (data) {
                    response($.map(data, function (item) {
                        return { LaborKey: item.LaborKey, ServiceCharge: item.ServiceCharge,JobVendorName: item.JobVendorName, RadiusInMiles: item.RadiusInMiles, label: item.label, value: item.value };
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
            
            $("#VendorKey").val(ui.item.value);
            $("#JobVendorName").val(ui.item.JobVendorName);
            $("#Distance").val(ui.item.RadiusInMiles);
            $("#ServiceCharge").val(ui.item.ServiceCharge);
            $("#LaborKey").val(ui.item.LaborKey);

            

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

    $("#JobVendorContactName").bind("keydown", function (event) {
        if (event.keyCode === $.ui.keyCode.TAB &&
            $(this).data("autocomplete").menu.active) {
            event.preventDefault();
        }
    })
    $("#JobVendorContactName").autocomplete({
        source: function (request, response) {
            //define a function to call your Action (assuming UserController)
            $.ajax({
                url: '/DropdownUtility/GetJobVendorContactName', type: "GET", dataType: "json",
                //query will be the param used by your action method
                data: { query: request.term, VendorKey: $("#VendorKey").val() },
                term: extractLast(request.term),
                success: function (data) {
                    response($.map(data, function (item) {
                        return { JobVendorContactName: item.JobVendorContactName,label: item.label, value: item.value };
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

            $("#ContactKey").val(ui.item.value);
            $("#JobVendorContactName").val(ui.item.JobVendorContactName);
          
            // add placeholder to get the comma-and-space at the end
            terms.push("");
            this.value = terms.join("");
            return false;
        }
    });

});
