$(function () {
    $("#Country").change(function () {
        $('#stateForm').empty();
        var selectedValue = $('#Country').find(":selected").val();
        if (selectedValue == "US") {
            $.getJSON("/Checkout/GetUsStateCodes",
                function (data) {
                    var html = "<label class=\"col-md-2 control-label\" for=\"State\">State</label>" +
                        "<div class=\"col-md-10\">" +
                        "<div class=\"editor-field\">" +
                            "<select class=\"form-control\" data-val=\"true\" data-val-required=\"State is required\" id=\"State\" name=\"State\">" +
                                "<option selected=\"selected\" disabled>Select a State</option>";
                    $.each(data, function (index, item) {
                        html += "<option value=\"" + item.value + "\">" + item.key + "</option>";
                    });
                    html += "</select><span class=\"field-validation-valid text-danger\" data-valmsg-for=\"State\" data-valmsg-replace=\"true\"></span> </div> </div>";
                    $('#stateForm').prepend(html);
                    $("form").removeData("validator").removeData("unobtrusiveValidation");
                    $.validator.unobtrusive.parse("form");
                });
        }
        else if (selectedValue == "CA")
        {
            $.getJSON("/Checkout/GetCaStateCodes",
                function (data) {
                    var html = "<label class=\"col-md-2 control-label\" for=\"State\">State</label>" +
                        "<div class=\"col-md-10\">" +
                        "<div class=\"editor-field\">" +
                            "<select class=\"form-control\" data-val=\"true\" data-val-required=\"State is required\" id=\"State\" name=\"State\">" +
                                "<option selected=\"selected\" disabled>Select a State</option>";
                    $.each(data, function (index, item) {
                        html += "<option value=\"" + item.value + "\">" + item.key + "</option>";
                    });
                    html += "</select><span class=\"field-validation-valid text-danger\" data-valmsg-for=\"State\" data-valmsg-replace=\"true\"></span> </div> </div>";
                    $('#stateForm').prepend(html);
                    $("form").removeData("validator").removeData("unobtrusiveValidation");
                    $.validator.unobtrusive.parse("form");
                });
        }
    });
});