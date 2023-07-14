
function closePopup() {
    parent.parentDeleteCustomer();
}

function deleteCustomer() {  
    $.ajax({
        type: 'DELETE',
        url: '/api/client/delete/customer/' + document.getElementById('clientId').innerHTML,
        contentType: 'application/json',
        async: true, 
        success: function (data) {
            $('#cover-spin').hide();
            if (data == "The client was successfully removed") {
                toastr.success("", "The client was successfully removed");
                closePopup();
            } else {
                toastr.error("An error was generated on the server, please try again.");
            }
        }, error: function (xhr, status, error) {
            $('#cover-spin').hide(); 
        }
    });
}