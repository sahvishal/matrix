var PrimaryCarePhysicianFactory = function () {
    
    var get = function () {
        if (isEmpty()) {
            return null;
        }
       
        var primaryCarePhysician = {
                FullName: {
                    "FirstName": $("#pcpFirstNameInputText").val(),
                    "LastName": $("#pcpLastNameInputText").val()
                }
        };
        
        if ($(".sameAsPracticeAddress").is(":checked")) {
            copyAddress();
        }

        if (isAddressComplete()) {
            primaryCarePhysician.Address = {
                "StreetAddressLine1": $('#pcpAddressInputText').val(),
                "StreetAddressLine2": $('#pcpStreetAddressLine2').val(),
                "City": $('#pcpCityInputText').val(),
                "CountryId": $('.ddl-pcpcountry option:selected').val(),
                "StateId": $('.ddl-pcpStates option:selected').val(),
                "ZipCode": $('#pcpZipInputText').val()
            };
            primaryCarePhysician.MailingAddress = {
                "StreetAddressLine1": $('#pcpMailingAddress1').val(),
                "StreetAddressLine2": $('#pcpMailingAddress2').val(),
                "City": $('#pcpMailingCityInputText').val(),
                "CountryId": $('.ddl-pcpMailingcountry option:selected').val(),
                "StateId": $('.ddl-pcpMailingStates option:selected').val(),
                "ZipCode": $('#pcpMailingZipInputText').val()
            };
        } else {
            primaryCarePhysician.Address = {
                "StreetAddressLine1": '',
                "StreetAddressLine2": '',
                "City": '',
                "CountryId": 0,
                "StateId": 0,
                "ZipCode": ''
            };
            
            primaryCarePhysician.MailingAddress = {
                "StreetAddressLine1": '',
                "StreetAddressLine2": '',
                "City": '',
                "CountryId": 0,
                "StateId": 0,
                "ZipCode": ''
            };
        }

        return primaryCarePhysician;
    };

    var set = function (result) {
        $(".mailingAddress").hide();
        $(".sameAsPracticeAddress").attr('checked', true);
        if (result.d == null) return;
        
        primaryCarePhysicianData = result.d;
        var data = result.d;
        if (data.FullName != null) {
            $("#pcpFirstNameInputText").val(data.FullName.FirstName);
            $("#pcpLastNameInputText").val(data.FullName.LastName);
        }
        if (data.Address != null && data.Address.StreetAddressLine1 != '') {
            
            $('#pcpAddressInputText').val(data.Address.StreetAddressLine1);
            $('#pcpStreetAddressLine2').val(data.Address.StreetAddressLine2);
            $('#pcpCityInputText').val(data.Address.City);
            $('#pcpZipInputText').val(data.Address.ZipCode);
            
            $('.ddl-pcpcountry option').each(function () {
                if ($(this).val() == data.Address.CountryId)
                    $(this).attr("selected", true);
            });

            changeStateforCountryPcp();
            
            $('.ddl-pcpStates option').each(function () {
                if ($(this).val() == data.Address.StateId)
                    $(this).attr("selected", true);
            });
            $(".sameAsPracticeAddress").attr('checked', data.HasSameAddress);
            
            if (data.HasSameAddress) {
                $(".mailingAddress").hide();
            } else {
                $(".mailingAddress").show();
            }
            $('#pcpMailingAddress1').val(data.MailingAddress.StreetAddressLine1);
            $('#pcpMailingAddress2').val(data.MailingAddress.StreetAddressLine2);
            $('#pcpMailingCityInputText').val(data.MailingAddress.City);
            $('#pcpMailingZipInputText').val(data.MailingAddress.ZipCode);

            $('.ddl-pcpMailingcountry option').each(function () {
                if ($(this).val() == data.MailingAddress.CountryId)
                    $(this).attr("selected", true);
            });

            changeStateforCountryPcpMailingAddress();

            $('.ddl-pcpMailingStates option').each(function () {
                if ($(this).val() == data.MailingAddress.StateId)
                    $(this).attr("selected", true);
            });
            
        }
        
        if (typeof data.IsPcpAddressVerified !== "undefined" && data.IsPcpAddressVerified != null && data.IsPcpAddressVerified == true)
        {
            var date = correctDateExpression(data.PcpAddressVerifiedOn);
            var pcpAddressVerifiedOn = (date.getMonth() + 1) + "/" + date.getDate() + "/" + date.getFullYear();
            $('#pcpAddressVerifyMessagelbl').text('Pcp address is verified by ' + data.PcpAddresVarifiedByUserName + ' (' + data.PcpAddresVarifiedByRole + ') on ' + pcpAddressVerifiedOn);
        }
        else
        {
            $('#pcpAddressVerifyMessagelbl').text('Pcp address is not verified.');
        }
    };

    var copyAddress = function () {
       
      
        $('#pcpMailingAddress1').val($('#pcpAddressInputText').val());
        $('#pcpMailingAddress2').val($('#pcpStreetAddressLine2').val());
        $('#pcpMailingCityInputText').val($('#pcpCityInputText').val());
        $('#pcpMailingZipInputText').val($('#pcpZipInputText').val());
        var counteryId = $('.ddl-pcpcountry option:selected').val();
        var stateId = $('.ddl-pcpStates option:selected').val();
        
        $('.ddl-pcpMailingcountry option').each(function () {
            if ($(this).val() == counteryId)
                $(this).attr("selected", true);
        });

        changeStateforCountryPcpMailingAddress();

        $('.ddl-pcpMailingStates option').each(function () {
            if ($(this).val() == stateId)
                $(this).attr("selected", true);
        });
    };

    var isValid = function () {
       
        if ((!isPcpAddressEmpty() || $("#pcpLastNameInputText").val() !== '') && $("#pcpFirstNameInputText").val() === ''  ) {
                alert("Physician First Name is mandatory");
                return false;
            }
        if ((!isPcpAddressEmpty() || $("#pcpFirstNameInputText").val() !== '') && $("#pcpLastNameInputText").val() === '' ) {
                alert("Physician Last Name is mandatory");
                return false;
            }
       
        if ($(".sameAsPracticeAddress").is(":checked")==false) {
            if (!isAddressComplete()) {
                alert("Please provide physician complete practice address");
                return false;
            }
            
            if (!isPcpMailingAddressComplete()) {
                alert("Please provide physician complete mailing address");
                return false;
            }
        }
        
        return true;
    };

    var isEmpty = function () {
        return isPcpAddressEmpty() && $("#pcpFirstNameInputText").val() == '' && $("#pcpLastNameInputText").val() === '';
    };

    var isPcpAddressEmpty = function () {

        if ($('#pcpAddressInputText').val() === '' && $('#pcpStreetAddressLine2').val() === '' && $('#pcpCityInputText').val() === ''
            && Number($('.ddl-pcpcountry option:selected').val()) <= 0 && (typeof $('.ddl-pcpStates option:selected').val() == "undefined" || Number($('.ddl-pcpStates option:selected').val()) <= 0)
            && $('#pcpZipInputText').val() === '')
            return true;

        return false;
    };

    var isPcpMailingAddressComplete = function () {

        if ($('#pcpMailingAddress1').val() !== '' && $('#pcpMailingCityInputText').val() !== ''
            && Number($('.ddl-pcpMailingcountry option:selected').val()) > 0 && (typeof $('.ddl-pcpMailingStates option:selected').val() !== "undefined" && Number($('.ddl-pcpMailingStates option:selected').val()) > 0)
            && $('#pcpMailingZipInputText').val() !== '')
            return true;

        return false;
    };

    var isAddressComplete = function() {
        if ($('#pcpAddressInputText').val() !== '' && $('#pcpCityInputText').val() !== ''
            && Number($('.ddl-pcpcountry option:selected').val()) > 0 && (typeof $('.ddl-pcpStates option:selected').val() !== "undefined" && Number($('.ddl-pcpStates option:selected').val()) > 0)
            && $('#pcpZipInputText').val() !== '')
            return true;
        
        return false;
    };

    var changeStateforCountryPcp = function () {
        var valueSelectedCountry = $(".ddl-pcpcountry option:selected").val();
        if (stateCountryList == null || stateCountryList == undefined) return;

        $(".ddl-pcpStates").html("");

        $(".ddl-pcpStates").append("<option value='0'> -- Select -- </option>");
        $.each(stateCountryList, function () {
            if (this.CountryId == valueSelectedCountry) {
                $(".ddl-pcpStates").append("<option value='" + this.Id + "'> " + this.Name + " </option>");
            }
        });
    };
    
    var changeMailingStateforCountryPcp = function () {
        var valueSelectedCountry = $(".ddl-pcpMailingcountry option:selected").val();
        if (stateCountryList == null || stateCountryList == undefined) return;

        $(".ddl-pcpMailingStates").html("");

        $(".ddl-pcpMailingStates").append("<option value='0'> -- Select -- </option>");
        $.each(stateCountryList, function () {
            if (this.CountryId == valueSelectedCountry) {
                $(".ddl-pcpMailingStates").append("<option value='" + this.Id + "'> " + this.Name + " </option>");
            }
        });
    };
    
    var changeStateforCountryPcpMailingAddress = function () {
        var valueSelectedCountry = $(".ddl-pcpMailingcountry option:selected").val();
        if (stateCountryList == null || stateCountryList == undefined) return;

        $(".ddl-pcpMailingStates").html("");

        $(".ddl-pcpMailingStates").append("<option value='0'> -- Select -- </option>");
        $.each(stateCountryList, function () {
            if (this.CountryId == valueSelectedCountry) {
                $(".ddl-pcpMailingStates").append("<option value='" + this.Id + "'> " + this.Name + " </option>");
            }
        });
    };

    var cityData = function (cities) {
        for (var i = 0; i < cities.d.length; i++) {
            var currentSearchItem = cities.d[i];
            var htmlElement = $("<div class='search-pcp-result'>" + currentSearchItem.Name + "</div>");
            $("#pcpresult").append(htmlElement);
        }

        $(".search-pcp-result").each(function (index) {
            $(this).click(function () {
                $("#pcpCityInputText").val(cities.d[index].Name);
                $(".pcp-city_id").val(cities.d[index].CityID);
                $("#pcpresult").hide();
                $("#results").empty();
            });
        });

        $(document).bind("click", function () {
            $('#pcpresult').hide();
            $("#pcpresult").empty();
        });

        $("#pcpresult").show();
    };
    
    var mailingCityData = function (cities) {
        for (var i = 0; i < cities.d.length; i++) {
            var currentSearchItem = cities.d[i];
            var htmlElement = $("<div class='search-pcp-mailing-result'>" + currentSearchItem.Name + "</div>");
            $("#pcpresult").append(htmlElement);
        }

        $(".search-pcp-mailing-result").each(function (index) {
            $(this).click(function () {
                $("#pcpMailingCityInputText").val(cities.d[index].Name);
                $(".pcp-mailing-city_id").val(cities.d[index].CityID);
                $("#pcpresult").hide();
                $("#results").empty();
            });
        });

        $(document).bind("click", function () {
            $('#pcpresult').hide();
            $("#pcpresult").empty();
        });

        $("#pcpresult").show();
    };

    return { get: get, set: set, setStateData: changeStateforCountryPcp,setMailingState:changeMailingStateforCountryPcp, CityData: cityData, isValid: isValid, copyAddress: copyAddress, mailingCityData: mailingCityData };
}();