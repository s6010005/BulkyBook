var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#tblCompanies').DataTable({
        "ajax": {
            "url": "/Admin/Company/GetAll"
        },
        //"pageLength": 2,
        "language": {
            "paginate": {
                "previous": "Προηγούμενη",
                "next": "Επόμενη"
            },
            "info": "_START_ εως _END_ από τις συνολικά _TOTAL_ εγγραφές",
            "search": "Αναζήτηση:",
            "lengthMenu": "_MENU_ εγγραφές",
        },
        "columnDefs": [
            { "orderable": false, "targets": 0 },
            { "orderable": false, "targets": 8 }
        ],
        "columns": [

            { "data": "name", "width": "20%" },
            { "data": "email", "width": "20%" },
            { "data": "tin", "width": "10%" },
            { "data": "city", "width": "10%" },
            { "data": "streetAddress", "width": "10%" },
            { "data": "postalCode", "width": "5%" },
            { "data": "phoneNumber", "width": "10%" },
            { "data": "phoneNumberMobile", "width": "10%" },
            { "data": "registrationDate", "width": "10%", render: $.fn.dataTable.render.moment('YYYY-MM-DDThh:mm:ss', 'DD-MM-YYYY') },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                        <a href="/Admin/Company/Upsert?id=${data}"
                        class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i></a>
                        <a onClick=Delete('/Admin/Company/Delete/${data}')
                        class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i></a>
					</div>
                        `
                },
                "width": "10%"
            }
            
            
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'ΔΙΑΓΡΑΦΗ',
        text: 'Είστε σίγουροι οτι θέλετε να διαγράψετε την εγγραφή;',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        cancelButtonText: 'Όχι',

        confirmButtonText: 'Ναί'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}