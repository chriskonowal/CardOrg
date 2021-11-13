// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

$('.btnDelete').button({
    icon: "ui-icon-trash"
});
$('.btnAdd').button({
    icon: "ui-icon-plus"
});
$('.btnEdit').button({
    icon: "ui-icon-wrench"
});
$('#myTable').DataTable({
    responsive: true
});
$('.btnSave').button({
    icon: "ui-icon-disk"
});
$('input[type="textbox"]').addClass("ui-widget ui-widget-content ui-corner-all");

function FillDataTable(tableId, orderCheckBox, checkboxClass, hiddenFieldId) {
    var teamTable = $('#' + tableId).DataTable({
        'columnDefs': [
            {
                'targets': 0,
                "orderDataType": orderCheckBox
            },     
        ],
        responsive: true
    });

    $('#' + tableId + ' tbody').on('change', '.' + checkboxClass, function () {
        $('#' + hiddenFieldId).val('');
        var teamIds = ''
        var rowcollection = teamTable.$('.' + checkboxClass + ':checked', { "page": "all" });
        rowcollection.each(function (index, elem) {
            var checkbox_value = $(elem).val();
            if (teamIds.length > 0) {
                teamIds += ','
            }
            teamIds += checkbox_value;
        })
        $('#' + hiddenFieldId).val(teamIds);
    });

    var hdnTeamIds = $('#' + hiddenFieldId).val().split(',');
    if (hdnTeamIds.length > 0) {
        for (var i = 0; i < hdnTeamIds.length; i++) {
            var id = hdnTeamIds[i];
            var rowcollection = teamTable.$('.' + checkboxClass, { "page": "all" });
            rowcollection.each(function (index, elem) {
                var checkbox_value = $(elem).val();
                if (checkbox_value == id) {
                    $(elem).prop('checked', true);
                }
            })
        }
    }

    $.fn.dataTable.ext.order[orderCheckBox] = function (settings, col) {
        return this.api().column(col, { order: 'index' }).nodes().map(function (td, i) {
            return $('input', td).prop('checked') ? '1' : '0';
        });
    }
}