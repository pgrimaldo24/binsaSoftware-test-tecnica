

$(document).ready(function () {
    $('#cover-spin').show(); 
    listCustomerDt(); 
});


function listCustomerDt() { 
    $('#cover-spin').show();
    var msg = document.getElementById('msgDataTable');
    var div = document.getElementById('tbl-report-customer');
    msg.style.display = 'none';

    $.ajax({
        type: 'GET',
        url: '/api/client/list/customer',
        contentType: 'application/x-www-form-urlencoded',
        async: true,
        cache: false,
        processData: false,
        contentType: false, 
        success: function (data) { 
             
            $('#cover-spin').hide();
            div.style.display = 'block';
            msg.style.display = 'none';

            var dtCustomer = $('#dtCustomers').DataTable({
                destroy: true,
                responsive: false,
                scrollCollapse: true,
                lengthMenu: [[10, 25, 50, -1], [10, 25, 50, "All"]],
                processing: true,
                searching: false,
                data: data,
                columns: [
                    { title: "NOMBRES", data: "names", className: "colum_center" },
                    { title: "DOMICILIO", data: "homeAddress", className: "colum_center" },
                    { title: "CODIGO POSTAL", data: "postalCode", className: "colum_center" },
                    { title: "POBLACION", data: "population", className: "colum_center" }, 
                    {
                        title: "ACCIONES",
                        "render": function (id, val1, val2, val3) {

                            var btnAcciones = "<button type='button' name=" + val2.clientId + " class='btn btn-primary' style='padding-block: 2px;' onclick='detailCustomer(" + val2.clientId + ");'><i class='fa fa-search'></i> Editar</button> &nbsp; <button type='button' name=" + val2.clientId + " class='btn btn-danger' style='padding-block: 2px;' onclick='deleteCustomer(" + val2.clientId + ");'><i class='fa fa-trash'></i> Eliminar</button>";
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

function createCustomer() {
    $('#frm_new_customer').attr('src', '/Client/PopupNewCustomer');
    $('#popup_new_customer').modal('show');
}

function parentCreateCustomer() {
    $('#frm_new_customer').attr('src', '');
    $('#popup_new_customer').modal('hide');
}

function detailCustomer(id) {
    $('#frm_detail_customer').attr('src', '/Client/PopupEditCustomer?id=' + id);
    $('#popup_detail_customer').modal('show');
}

function parentDetailCustomer() {
    $('#frm_detail_customer').attr('src', '');
    $('#popup_detail_customer').modal('hide');
}

function createCustomerContact() {
    $('#frm_new_customer_contact').attr('src', '/CustomerContact/CustomerContactView');
    $('#popup_new_customer_contact').modal('show');
}

function parentCustomerContact() {
    $('#frm_new_customer_contact').attr('src', '');
    $('#popup_new_customer_contact').modal('hide');
}

function deleteCustomer(id) {
    $('#frm_delete_customer_').attr('src', '/Client/PopupDeleteCustomer?id=' + id);
    $('#popup_delete_customer').modal('show');
}

function parentDeleteCustomer() {
    $('#frm_delete_customer_').attr('src', '');
    $('#popup_delete_customer').modal('hide');
}