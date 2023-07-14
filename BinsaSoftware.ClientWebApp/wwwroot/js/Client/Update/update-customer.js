$(document).ready(function () {
    $('#cover-spin').show();
    detailCustomerById();
    listCustomerContactDt(); 
});

function clearAlerts() {
    msg_campo_valido1.style.display = 'none';
    msg_campo_valido2.style.display = 'none';
    msg_campo_valido3.style.display = 'none';
    msg_campo_valido4.style.display = 'none';
}


function detailCustomerById() { 
    $.ajax({
        type: 'GET',
        url: '/api/client/detail/customer/' + document.getElementById('clientId').innerHTML,
        contentType: 'application/json',
        async: true, 
        success: function (data) {
            $('#cover-spin').hide(); 
            $('#txtName').val(data.nombre);
            $('#txtHomeAddress').val(data.domicilio);
            $('#txtPostalCode').val(data.codigoPostal);
            $('#txtTownName').val(data.poblacion);
             
        }, error: function (xhr, status, error) {
            $('#cover-spin').hide();
            toastr.warning(error);
        }
    });
}

function listCustomerContactDt() {
  
    $('#cover-spin').show();
    var msg = document.getElementById('msgDataTable');
    var div = document.getElementById('tbl-report-customer-contact');
    msg.style.display = 'none';

    $.ajax({
        type: 'GET',
        url: '/api/customerContact/list/customer/contact/' + document.getElementById('clientId').innerHTML,
        contentType: 'application/x-www-form-urlencoded',
        async: true,
        cache: false,
        processData: false,
        contentType: false,
        success: function (data) {

            $('#cover-spin').hide();
            div.style.display = 'block';
            msg.style.display = 'none';

            var dtCustomer = $('#dtCustomersContact').DataTable({
                destroy: true,
                responsive: false,
                scrollCollapse: true,
                lengthMenu: [[10, 25, 50, -1], [10, 25, 50, "All"]],
                processing: true,
                searching: false,
                data: data,
                columns: [
                    { title: "NOMBRES", data: "names", className: "colum_center" },
                    { title: "TELÉFONO", data: "phone", className: "colum_center" },
                    { title: "EMAIL", data: "email", className: "colum_center" },
                    {
                        title: "ACCIONES",
                        "render": function (id, val1, val2, val3) {

                            var btnAcciones = "<button type='button' name=" + val2.clientId + " class='btn btn-danger' style='padding-block: 2px;' onclick='deleteCustomerContact(" + val2.clientId + ");'><i class='fa fa-trash'></i> Eliminar</button>";
                            return btnAcciones;
                        }
                    }
                ],
                language: {
                    "searchPlaceholder": "",
                    "decimal": "",
                    "emptyTable": "No hay información",
                    "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
                    "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
                    "infoFiltered": "",
                    "infoPostFix": "",
                    "thousands": ",",
                    "lengthMenu": "",
                    "loadingRecords": "Cargando...",
                    "processing": "Procesando...",
                    "search": "",
                    "zeroRecords": "Sin resultados encontrados",
                    "paginate": {
                        "first": "Primero",
                        "last": "Ultimo",
                        "next": "Siguiente",
                        "previous": "Anterior"
                    }
                },
            });
        }, error: function (xhr, status, error) {
            $('#cover-spin').hide();
            msg.style.display = 'block';
            toastr.warning(error);
        }
    });
}

function closePopup() {
    parent.parentDetailCustomer();
}

function updateCustomer() {
    $('#cover-spin').show();
    var isValidate = true;
    clearAlerts();
    var names = document.getElementById("txtName").value;
    var homeAddress = document.getElementById("txtHomeAddress").value;
    var postalCode = document.getElementById("txtPostalCode").value;
    var townName = document.getElementById("txtTownName").value;

    if (names == undefined || names == null || names == "") {
        msg_campo_valido1.style.display = 'block';
        isValidate = false;
    }

    if (homeAddress == undefined || homeAddress == null || homeAddress == "") {
        msg_campo_valido2.style.display = 'block';
        isValidate = false;
    }

    if (postalCode == undefined || postalCode == null || postalCode == "") {
        msg_campo_valido3.style.display = 'block';
        isValidate = false;
    }

    if (townName == undefined || townName == null || townName == "") {
        msg_campo_valido4.style.display = 'block';
        isValidate = false;
    }

    if (!isValidate) {
        $('#cover-spin').hide();
    }
    else {
        var requestCustomerApi = {
            ClientId: document.getElementById('clientId').innerHTML,
            Nombre: names,
            Domicilio: homeAddress,
            CodigoPostal: postalCode,
            Poblacion: townName
        };

        $.ajax({
            type: 'PUT',
            url: '/api/client/update/customer',
            contentType: 'application/json',
            async: true,
            data: JSON.stringify(requestCustomerApi),
            success: function (data) {
                $('#cover-spin').hide();
                if (data == "The client was successfully updated") {
                    toastr.success("", "The client was successfully updated");
                    detailCustomerById();
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

function deleteCustomerContact(id) {
    $.ajax({
        type: 'DELETE',
        url: '/api/customerContact/delete/contact/' + id,
        contentType: 'application/json',
        async: true,
        success: function (data) {
            $('#cover-spin').hide();
            if (data == "The contact was deleted successfully") {
                toastr.success("", "The contact was deleted successfully");
                closePopup();
            } else {
                toastr.error("An error was generated on the server, please try again.");
            }
        }, error: function (xhr, status, error) {
            $('#cover-spin').hide();
        }
    });
}