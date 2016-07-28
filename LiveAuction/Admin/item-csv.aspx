<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="item-csv.aspx.cs" Inherits="LiveAuction.seller_track.item_csv" %>

<%@ Register Src="~/UserControl/SellerLeftPanel.ascx" TagName="SellerLeftPanel" TagPrefix="UCSellerLeftPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $('#liCSVAuctions').addClass('sdmnu-active');
        });
    </script>
    <link href="../Scripts/DropzoneJs_scripts/dropzone.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/DropzoneJs_scripts/dropzone.js" type="text/javascript"></script>
    <script type="text/javascript">
        var dropImages = [];
        $(document).ready(function () {

            Dropzone.autoDiscover = false;

            //Simple Dropzonejs 
            $("#dZUpload").dropzone({
                url: "../fileupload/admin_ajax_fileupload.ashx",
                maxFiles: 20,
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
    <!-- this is the breadcumbs area -->
    <section class="breadcumbs-area-sec">
         <div class="container">
             <div class="row">
                 <div class="col-md-12">
                     <div class="breadcumb">
                     <a href="#" class="incative">Home &raquo; </a><span class="current-page">item csv</span></div>
                 </div>
             </div>
         </div>
     </section>
    <!-- end of breadcumbs area -->
    <section class="creat-account-sec">
        <div class="container">
            <div class="row">
             <%--<UCSellerLeftPanel:SellerLeftPanel runat="server" ID="SellerLftPnl" />--%>
              <div class="col-md-12">
                <div class="cr-accnt">
                  <div class="tt">
                      <div class="account-creat-title">
                          <h2>CSV Auction</h2>
                      </div>
                  </div>
                  <div class="tt">
                    <div class="bulk-item-butn">
                      <a class="btn btn-primary btn-blkitem" data-toggle="modal" data-target="#bidpopup">Upload Bulk Items</a>
                      <span class="label label-success successUpload" style="visibility:hidden">File uploaded successfully.</span>
                      <asp:PlaceHolder ID="fileUploadSuccessfull" runat="server"></asp:PlaceHolder>

                    </div>
                  </div>
                  <%--<div class="tt">
                    <div class="description-table-sec">
                      <div class="description-title">
                        CSV table description and acceptable values:
                      </div>
                      <div class="description-table">
                        <div class="table-responsive">
                          <table class="table table-bordered table-striped table-condensed table-csv">
                            <thead class="btn-primary">
                              <tr class="row">
                                <th class="col-xs-3">HEADER</th>
                                <th class="col-xs-3">REQUIRED</th>
                                <th class="col-xs-3">TYPE</th>
                                <th class="col-xs-3">ACCEPTABLE VALUES</th>
                              </tr>
                            </thead>
                            <tbody>
                              <tr class="row">
                                <td class="col-xs-3">1</td>
                                <td class="col-xs-3">2</td>
                                <td class="col-xs-3">3</td>
                                <td class="col-xs-3">4</td>
                              </tr>
                            </tbody>
                          </table>
                        </div>
                      </div>
                    </div>
                  </div>--%>
                </div>
              </div>
            </div>
        </div>
    </section>
    <!-- start of bid popup -->
    <section class="bid-popup-sector" style="margin-top: 40%">
        <!-- Modal -->
        <div class="modal fade" id="bidpopup" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
          <div class="modal-dialog bid-model-dialog" role="document">
            <div class="modal-content bid-model-content">
              <div class="modal-header bid-model-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title" id="myModalLabel">CSV section</h4>
              </div>
              <div class="modal-body bid-model-body">
                  <div class="row">
                    <div class="col-md-12 col-lg-12">
                    <h4 class="modal-title" id="H1">Select Auction</h4>
                    <asp:DropDownList ID="auction" runat="server" CssClass="form-control"></asp:DropDownList>
                    <div class="col-xs-12"><hr></div><br />
                      <%--<div class="cr-accnt pop-cr-accnt">
                      </div>--%>
                    </div>
                    <div class='col-md-12 col-lg-12'>
                                <h4 class='modal-title' id='H4'>Upload Image files</h4>
                                        <div class='cr-accnt'>
                                            <div class='col-md-12'>
                                                <div id='dZUpload' class='dropzone'>
                                                    <div class='dz-default dz-message'>
                                                        Drag and drop photos into the box.
                                                    </div>
                                                </div>
                                                 <input type='hidden' id='hdnimagefiles' name='hdnimagefiles' />
                                            </div>
                                      </div>
                                </div>
                    <div class="col-md-12 col-lg-12">
                    <h4 class="modal-title" id="H2">Upload CSV file</h4>
                    <asp:FileUpload ID="CSVFileUpload" runat="server" CssClass="btn btn-default btn-file" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.csv|.txt)$"
                                        ControlToValidate="CSVFileUpload" runat="server" ForeColor="Red" ErrorMessage="Please select a valid CSV file."
                                        Display="Dynamic" />
                                        <asp:RequiredFieldValidator  ControlToValidate="CSVFileUpload" ID="RequiredFieldValidator1" runat="server" ErrorMessage="CSV file is required" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                    <div class="col-xs-12"><hr></div><br />
                      <%--<div class="cr-accnt pop-cr-accnt">
                      </div>--%>
                    </div>
                    <div class="col-md-12 col-lg-12">
                    <asp:Button ID="Button1"  CssClass="btn btn-default" Text="Upload" OnClick = "Upload" runat="server" />
                      <%--<div class="cr-accnt pop-cr-accnt">
                      </div>--%>
                    </div>
                  </div>
              </div>
              <!-- modal main body end -->
            </div>
          </div>
        </div>
      </section>
    <!-- end of bid popup -->
</asp:Content>
