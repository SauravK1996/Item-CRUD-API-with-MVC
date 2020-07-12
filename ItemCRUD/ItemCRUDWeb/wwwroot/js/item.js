var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/items/GetAllItem",
            "type": "GET",
            "datatype": "json"
        },
        "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
        "dom": 'lfrBtip',
        "buttons": [
            'colvis','copy', 'csv', 'excel', 'pdf', 'print'
        ],
        "columns": [
            { "data": "title", "width": "20%" },
            { "data": "description", "width": "35%" },
            { "data": "unitType", "width": "15%" },
            { "data": "rate", "width": "10%" },
            {
                "data": "itemId",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/items/Upsert/${data}" class='btn btn-success text-white'
                                    style='cursor:pointer;'> <i class='far fa-edit'></i></a>
                                    &nbsp;
                                <a onclick=Delete("/items/Delete/${data}") class='btn btn-danger text-white'
                                    style='cursor:pointer;'> <i class='far fa-trash-alt'></i></a>
                                </div>
                            `;
                }, "width": "20%"
            }
        ]
    });
}

function Delete(url) {
    //sweetalert
    swal({
        title: "Are you sure you want to Delete?",
        text: "You will not be able to restore the data!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        //based on user clicks yes or no 
        if (willDelete) {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                        swal("Item has been successfully deleted!", {
                            icon: "success",
                        });
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        } else {
            swal("Item is safe!");
        }
    });
}