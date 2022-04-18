var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#tblBooks').DataTable({
        "ajax": {
            "url": "/Admin/ProductBook/GetAll"
        },

        "columns": [
            { "data": "title", "width": "20%" },
            { "data": "author", "width": "15%" },
            { "data": "isbn", "width": "15%" },
            { "data": "category.name", "width": "15%" },
            { "data": "datePublished", "width": "10%", render: $.fn.dataTable.render.moment('YYYY-MM-DDThh:mm:ss', 'YYYY') },
            { "data": "coverType.name", "width": "15%" },
                             
            { "data": "price", "width": "10%" },
            
            
        ]
    });
}