var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#tblBooks').DataTable({
        "ajax": {
            "url": "/Admin/ProductBook/GetAll"
        },
        "columnDefs": [
            { "orderable": false, "targets": 0 },
            { "orderable": false, "targets": 8 }
        ],
        "columns": [
            {
                "data": "imageUrl",
                "render": function (imageUrl) {
                    return `<img src=${imageUrl} style="height:30px; width:30px">`
                },"width": "2%" },
            { "data": "title", "width": "20%" },
            { "data": "author", "width": "15%" },
            { "data": "isbn", "width": "15%" },
            { "data": "category.name", "width": "10%" },
            { "data": "datePublished", "width": "8%", render: $.fn.dataTable.render.moment('YYYY-MM-DDThh:mm:ss', 'YYYY') },
            { "data": "coverType.name", "width": "10%" },
                             
            { "data": "price", "width": "5%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                        <a href="/Admin/ProductBook/Upsert?id=${data}"
                        class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i></a>
                        <a onClick=Delete('/Admin/ProductBook/Delete/${data}')
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