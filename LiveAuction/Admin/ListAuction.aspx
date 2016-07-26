<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Admin.Master"
    CodeBehind="ListAuction.aspx.cs" Inherits="LiveAuction.Admin.ListAuction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Custom styling plus plugins -->
    <link href="css/custom.css" rel="stylesheet">
    <link href="css/icheck/flat/green.css" rel="stylesheet">
    <link href="css/datatables/tools/css/dataTables.tableTools.css" rel="stylesheet">
    <!-- Datatables -->
    <script src="js/datatables/js/jquery.dataTables.js"></script>
    <script src="js/datatables/tools/js/dataTables.tableTools.js"></script>
    <link href="../Scripts/DropzoneJs_scripts/dropzone.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/DropzoneJs_scripts/dropzone.js" type="text/javascript"></script>
    <script type="text/javascript">
        var dropImages = [];
        $(document).ready(function () {

            Dropzone.autoDiscover = false;

            //Simple Dropzonejs 
            $("#dZUpload").dropzone({
                url: "../fileupload/ajax_fileupload.ashx",
                maxFiles: 5,
                maxFilesize: 2,
                addRemoveLinks: true,
                removedfile: function (file) {

                    var deleteurl = $(file.previewTemplate).find('a.dz-remove').attr('data-dz-remove');
                    //ajax call
                    $.ajax({
                        url: deleteurl,
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        //data: obj,
                        responseType: "json",
                        success: function (e) { },
                        error: function (e) { }
                    });

                    //remove the image from array
                    var imageName = file.xhr.response;
                    dropImages = $.grep(dropImages, function (value) {
                        return value != imageName;
                    });
                    //remove the image from UI
                    var _ref;
                    return (_ref = file.previewElement) != null ? _ref.parentNode.removeChild(file.previewElement) : void 0;
                    //file.previewElement.parentNode.removeChild(file.previewElement);

                },
                success: function (file, response) {

                    var imgName = response;
                    file.previewElement.classList.add("dz-success");
                    dropImages.push(imgName);
                    console.log("Successfully uploaded :" + imgName);
                    var url = '../fileupload/ajax_fileupload.ashx?cmd=delete&file=' + response;
                    $(file.previewTemplate).find('a.dz-remove').attr('data-dz-remove', url);
                },
                error: function (file, response) {
                    file.previewElement.classList.add("dz-error");
                }
            });

            $("#successbtn").click(function () {
                $(this).after(
        '<div class="alert alert-success alert-dismissable">' +
            '<button type="button" class="close" ' +
                    'data-dismiss="alert" aria-hidden="true">' +
                '&times;' +
            '</button>' +
            'Password Changed' +
         '</div>');
            });
        });

        function validateForm() {
            debugger;
            $('#hdnimagefiles').val(dropImages.toString());
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="">
        <div class="page-title">
            <div class="title_left">
                <h3>
                    Auction <small></small>
                </h3>
            </div>
            <div class="title_right">
            </div>
        </div>
        <div class="clearfix">
        </div>
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>
                            Auction<small>List</small></h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li><a href="#"><i class="fa fa-chevron-up"></i></a></li>
                        </ul>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="x_content">
                        <asp:Literal ID="literalText" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
            <br />
            <br />
            <br />
        </div>
    </div>
    <!-- pace -->
    <script src="js/pace/pace.min.js"></script>
    <script>
        $(document).ready(function () {
            $('input.tableflat').iCheck({
                checkboxClass: 'icheckbox_flat-green',
                radioClass: 'iradio_flat-green'
            });
        });

        var asInitVals = new Array();
        $(document).ready(function () {
            var oTable = $('#example').dataTable({
                "oLanguage": {
                    "sSearch": "Search all columns:"
                },
                "aoColumnDefs": [{
                    'bSortable': false,
                    'aTargets': [0]
                } //disables sorting for column one
            ],
                'iDisplayLength': 12,
                "sPaginationType": "full_numbers",
                "dom": 'T<"clear">lfrtip',
                "tableTools": {
                    "sSwfPath": "js/datatables/tools/swf/copy_csv_xls_pdf.swf"
                }
            });
            $("tfoot input").keyup(function () {
                /* Filter on the column based on the index of this element's parent <th> */
                oTable.fnFilter(this.value, $("tfoot th").index($(this).parent()));
            });
            $("tfoot input").each(function (i) {
                asInitVals[i] = this.value;
            });
            $("tfoot input").focus(function () {
                if (this.className == "search_init") {
                    this.className = "";
                    this.value = "";
                }
            });
            $("tfoot input").blur(function (i) {
                if (this.value == "") {
                    this.className = "search_init";
                    this.value = asInitVals[$("tfoot input").index(this)];
                }
            });
        });
    </script>
</asp:Content>
