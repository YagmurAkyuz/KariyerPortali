﻿var initTable1 = function () {

    var table = $('#allEmployersTable');
    // begin first table
    table.dataTable({

        // Internationalisation. For more info refer to http://datatables.net/manual/i18n
        "language": {
            "aria": {
                "sortAscending": ": activate to sort column ascending",
                "sortDescending": ": activate to sort column descending"
            },
            "emptyTable": "Tabloda veri yok.",
            "info": " _START_ ile _END_ arasında toplam _TOTAL_ kayıt gösteriliyor.",
            "infoEmpty": "Kayıt bulunamadı.",
            "infoFiltered": "( _MAX_ adet kayıttan arananlar)",
            "lengthMenu": "Göster _MENU_ ",
            "search": "Ara:",
            "zeroRecords": "Eşleşen kayıt bulunamadı.",
            "paginate": {
                "previous": "Prev",
                "next": "Next",
                "last": "Last",
                "first": "First"
            }
        },

        // Or you can use remote translation file
        //"language": {
        //   url: '//cdn.datatables.net/plug-ins/3cfcc339e89/i18n/Portuguese.json'
        //},

        // Uncomment below line("dom" parameter) to fix the dropdown overflow issue in the datatable cells. The default datatable layout
        // setup uses scrollable div(table-scrollable) with overflow:auto to enable vertical scroll(see: assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.js). 
        // So when dropdowns used the scrollable div should be removed. 
        //"dom": "<'row'<'col-md-6 col-sm-12'l><'col-md-6 col-sm-12'f>r>t<'row'<'col-md-5 col-sm-12'i><'col-md-7 col-sm-12'p>>",

        "bServerSide": true,
        "bProcessing": true,
        "sAjaxSource": "/Employer/AjaxHandler",
        "bStateSave": true, // save datatable state(pagination, sort, etc) in cookie.

        "lengthMenu": [
            [5, 15, 20, -1],
            [5, 15, 20, "All"] // change per page values here
        ],
        // set the initial value
        "pageLength": 5,
        "pagingType": "bootstrap_full_number",
        "columnDefs": [
            {  // set default column settings
                'orderable': false,
                'searchable': false,
                'targets': [0],
                'render': function (data, type, row) {
                    return '<label class="mt-checkbox mt-checkbox-single mt-checkbox-outline"><input type="checkbox" class="checkboxes" value="1" /><span></span></label>';
                }
            },

            {
                'orderable': false,
                'searchable': false,
                'targets': [5],
                'render': function(data, type, row) {
                    return '<div class="btn-group"><button class="btn btn-xs green dropdown-toggle" type="button" data-toggle="dropdown" aria-expanded="false">Eylemler<i class="fa fa-angle-down"></i></button>'
                        + '<ul class="dropdown-menu" role="menu"><li><a href="/Employer/Edit/' + row[0] + '"><i class="icon-note"></i> Düzenle</a></li><li><a href="/Employer/Details/' + row[0] + '"><i class="icon-list"></i> Detaylar</a></li><li>'
                        + '<a href="/Employer/Delete/' + row[0] + '"><i class="icon-ban"></i> Sil</a></li></ul></div>';
                }
                
            }
            
        ],
        
        "order": [
            [1, "asc"]
        ] // set first column as a default sort by asc
    });
  
    var tableWrapper = jQuery('#allEmployersTable_wrapper');

    table.find('.group-checkable').change(function () {
        var set = jQuery(this).attr("data-set");
        var checked = jQuery(this).is(":checked");
        jQuery(set).each(function () {
            if (checked) {
                $(this).prop("checked", true);
                $(this).parents('tr').addClass("active");
            } else {
                $(this).prop("checked", false);
                $(this).parents('tr').removeClass("active");
            }
        });
    });

    table.on('change', 'tbody tr .checkboxes', function () {
        $(this).parents('tr').toggleClass("active");
    });
}