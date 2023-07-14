
$(document).ready(function ()
{ 
    $('input[name=txtName]').bind('keypress', function (event) {
        var regex = new RegExp("^[a-zA-Z ]+$");
        var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
        if (!regex.test(key)) {
            event.preventDefault();
            return false;
        }
    });
      
});


function registerCustomer() { 
    $('#cover-spin').show();  
    var isValidate = true; 
    clearAlerts(); 
    var names = document.getElementById("txtName").value; 
    var homeAddress = document.getElementById("txtHomeAddress").value; 
    var postalCode = document.getElementById("txtPostalCode").value; 
    var townName = document.getElementById("txtTownName").value;

    if (names == undefined || names == null || names == "")
    {
        msg_campo_valido1.style.display = 'block';
        isValidate = false;
    }
        
    if (homeAddress == undefined || homeAddress == null || homeAddress == "")
    {
        msg_campo_valido2.style.display = 'block';
        isValidate = false;
    }

    if (postalCode == undefined || postalCode == null || postalCode == "")
    {
        msg_campo_valido3.style.display = 'block';
        isValidate = false;
    }

    if (townName == undefined || townName == null || townName == "")
    {
        msg_campo_valido4.style.display = 'block';
        isValidate = false;
    }

    if (!isValidate) {
        $('#cover-spin').hide();
    }
    else { 
        var requestCustomerApi = {
            names: names,
            homeAddress: homeAddress,
            postalCode: postalCode,
            population: townName
        };

        $.ajax({
            type: 'POST',
            url: '/api/client/create/customer',
            contentType: 'application/json',
            async: true,
            data: JSON.stringify(requestCustomerApi),
            success: function (data) {  
                $('#cover-spin').hide(); 
                if (data == "The customer registered successfully") { 
                    toastr.success("", "The customer registered successfully.");
                    $('#txtName').val('');
                    $('#txtHomeAddress').val('');
                    $('#txtPostalCode').val('');
                    $('#txtTownName').val(''); 
                } else {
                    toastr.error("An error was generated on the server, please try again.");
                }
            }, error: function (xhr, status, error) {
                $('#cover-spin').hide();
                toastr.warning(error);
            }
        });
    }
}

function clearAlerts() {
    msg_campo_valido1.style.display = 'none';
    msg_campo_valido2.style.display = 'none';
    msg_campo_valido3.style.display = 'none';
    msg_campo_valido4.style.display = 'none'; 
}

function closePopup() {
    parent.parentCreateCustomer();
}