$(document).ready(function () {
    setDropClient();
});

function closePopup() {
    parent.parentCustomerContact();
}

function setDropClient() { 
    $.ajax({
        type: 'GET',
        url: '/api/client/drop/list/customer/',
        contentType: 'application/json',
        async: true,
        success: function (data) {
            $('#cover-spin').hide();

            var dpdClients = document.getElementById('dpdClients');

            $.each(data, function (i, m) {

                var options = document.createElement("option");
                var id = m.clientId;
                var valor = m.clientDesc;

                options.value = id;
                options.text = valor;

                dpdClients.add(options); 
            });

        }, error: function (xhr, status, error) {
            $('#cover-spin').hide();
            toastr.warning(error);
        }
    });

}

function registerCustomerContact() {
    $('#cover-spin').show();
    var isValidate = true;
    clearAlerts();
    var clientid = document.getElementById("dpdClients").value;;
    var names = document.getElementById("txtNames").value;
    var phone = document.getElementById("txtPhone").value;
    var email = document.getElementById("txtEmail").value;

    if (clientid == 0 || clientid == null || clientid == "") {
        msg_campo_valido1.style.display = 'block';
        isValidate = false;
    }

    if (names == undefined || names == null || names == "") {
        msg_campo_valido2.style.display = 'block';
        isValidate = false;
    }

    if (phone == undefined || phone == null || phone == "") {
        msg_campo_valido3.style.display = 'block';
        isValidate = false;
    }

    if (email == undefined || email == null || email == "") {
        msg_campo_valido4.style.display = 'block';
        isValidate = false;
    }

    if (!isValidate) {
        $('#cover-spin').hide();
    }
    else {
        var requestCustomerApi = {
            clientid: clientid,
            names: names,
            phone: phone,
            email: email
        };

        $.ajax({
            type: 'POST',
            url: '/api/customerContact/create/customer/contact',
            contentType: 'application/json',
            async: true,
            data: JSON.stringify(requestCustomerApi),
            success: function (data) {
                $('#cover-spin').hide();
                if (data == "The customer contact was registered successfully") {
                    toastr.success("", "The customer contact was registered successfully.");
                    $('#dpdClients').val(0);
                    $('#txtNames').val('');
                    $('#txtPhone').val('');
                    $('#txtEmail').val('');
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