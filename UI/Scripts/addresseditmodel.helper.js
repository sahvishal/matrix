
$(document).ready(function () {
    $('form').attr("autocomplete", "off");

    $('.address-city').autoComplete({
        minchar: 3,
        autoChange: true,
        url: '/App/AutoCompleteService.asmx/GetCityByPrefixText',
        type: "POST",
        data: "prefixText",
        contextKey: 0
    });

    if ($(".mock-state-ddl").length < 1) {
        $('.addresseditmodel-div:first').append("<select class='mock-state-ddl' style='display:none;'> </select>");
        $(".mock-state-ddl:first").html($(".addresseditmodel-div:first select[id*=StateId]:first").html());
    }

    $(".addresseditmodel-div select[id*=CountryId]").change(function () {
        var selectedValue = $(this).find("option:selected").val();
        var targetControl = $(this).parents(".addresseditmodel-div:first").find("select[id*=StateId]");
        var selectedStateId = targetControl.find("option:selected").val();

        targetControl.empty();
        targetControl.append($(".mock-state-ddl:first option:first").clone());

        $(".mock-state-ddl:first option").each(function () {
            var stateId = $(this).val();
            var currentOption = $(this);

            $.each(stateIdCountryIdArray, function () {
                if (this.StateId != stateId) return;
                if (this.CountryId == selectedValue) {
                    targetControl.append(currentOption.clone());
                }
                return false;
            });
        });

        if (selectedStateId == null || targetControl.find("option[value=" + selectedStateId + "]").length < 1) {
            targetControl.find("option:first").attr("selected", true);
        }
        else {
            targetControl.find("option[value=" + selectedStateId + "]").attr("selected", true);
        }

    });

    $(".addresseditmodel-div select[id*=StateId]").change(function () {
        var selectedValue = $(this).find("option:selected").val();
        $.each(stateIdCountryIdArray, function () {
            if (this.StateId == selectedValue) {
                $(".addresseditmodel-div input[id*=CountryId]").val(this.CountryId);
                return;
            }
        });
    });

    $(".addresseditmodel-div select[id*=CountryId]").change();
    setDefaultCountryId();
});

function setDefaultCountryId() {
    var countryId = $(".addresseditmodel-div input[id*=CountryId]").val();
    if (countryId == "" || countryId == "0") {
        $(".addresseditmodel-div input[id*=CountryId]").val("1");
    }
}

