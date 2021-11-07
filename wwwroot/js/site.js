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
$('#myTable').DataTable();
$('.btnSave').button({
    icon: "ui-icon-disk"
});
$('input[type="textbox"]').addClass("ui-widget ui-widget-content ui-corner-all");