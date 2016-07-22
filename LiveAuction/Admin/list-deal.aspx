<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="list-deal.aspx.cs" Inherits="LiveAuction.seller_track.list_deal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Scripts/DropzoneJs_scripts/dropzone.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/DropzoneJs_scripts/dropzone.js" type="text/javascript"></script>
    <script src="../Admin/js/timepicker/DateTimePicker.js" type="text/javascript"></script>
    <link href="../Admin/css/timepicker/DateTimePicker.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $('#liItemUpload').addClass('sdmnu-active');
        });

    </script>
    <script language="javascript" type="text/javascript">
        function OnlyNumbers(e) {
            if (navigator.appName == "Microsoft Internet Explorer") {
                if ((e.keyCode >= 48 && e.keyCode <= 57) || (e.keyCode == 46) || (e.keyCode == 8)) {

                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                if ((e.charCode >= 48 && e.charCode <= 57) || (e.charCode == 46) || (e.charCode == 0)) {
                    return true;
                }
                else {
                    return false;
                }
            }
        }    
    </script>
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
    <!-- this is the breadcumbs area -->
    <section class="breadcumbs-area-sec">
         <div class="container">
             <div class="row">
                 <div class="col-md-12">
                     <div class="breadcumb">
                     <a href="#" class="incative">Home &raquo; </a><a href="#" class="incative">Register &raquo; </a><span class="current-page">Deal Item</span></div>
                 </div>
             </div>
         </div>
     </section>
    <!-- end of breadcumbs area -->
    <button id="successbtn" type="button" class="hide">
        Click Here</button>
    <section class="creat-account-sec">
        <div class="container">
            <div class="row">
              
              <div class="cr-accnt">
                <div class="col-md-12">
                    <div class="account-creat-title">
                        <h2>1. Item</h2>
                    </div>
                </div>
                <div class="col-md-8">
                	<p>Picking the right category is important and helps buyes to find your product easily. Can't find the right categroy? Just Choose "others"/"others"</p>
                </div>
                <div class="col-md-12">
                    <div class="form-horizontal crt-acnt-frm">
                      <div class="form-group">
                        <label for="creat-ac-lb" class="col-sm-3 control-label">is the products new or used?</label>
                        <div class="col-sm-3">
                        <asp:DropDownList runat="server" ID="ItemUsed" class="form-control">
                        <asp:ListItem Text="new"></asp:ListItem>
                        <asp:ListItem Text="used"></asp:ListItem>
                        </asp:DropDownList>
                         
                        </div>
                      </div>
                     
                      <div class="form-group">
                       
                        <label for="creat-ac-lb" class="col-sm-3 control-label">Category</label>
                        <div class="col-sm-3">                          
                          <asp:DropDownList runat="server" CssClass="form-control" id="categotyLevel1"
                                AutoPostBack="true"  
                                OnSelectedIndexChanged="categotyLevel1_SelectedIndexChanged" >
                          </asp:DropDownList>             						  
                        </div>
                        <div class="col-sm-3">
                        <asp:DropDownList runat="server" CssClass="form-control" id="categotyLevel2" AutoPostBack="true"
                                OnSelectedIndexChanged="categotyLevel2_SelectedIndexChanged">
                          </asp:DropDownList>                         
                        </div>
                        <div class="col-sm-3">
                        <asp:DropDownList runat="server" CssClass="form-control" id="categotyLevel3">
                          </asp:DropDownList>                           
                        </div>
                        
                      </div>
                      <div class="form-group">
                        <label for="creat-ac-lb" class="col-sm-3 control-label">Does this product have a brand?</label>
                        <div class="col-sm-9">
                          <div class="radio">
              							<label class="radio-inline">
                                        <asp:RadioButton runat="server" ID="rdbYes" GroupName="Branded" Text="Yes" />                               
              							 <%-- <input type="radio" name="inlineRadioOptions" id="inlineRadio1" value="option1"> Yes--%>
              							</label>
              							<label class="radio-inline">
                                        <asp:RadioButton runat="server" ID="rdbNo" GroupName="Branded" Text="No"/>
              							 <%-- <input type="radio" name="inlineRadioOptions" id="inlineRadio2" value="option2"> No--%>
              							</label>
              							</div>
                        </div>
                      </div>
                      <div class="form-group">
                        <label for="creat-pswrd-lb" class="col-sm-3 control-label">Title</label>
                        <div class="col-sm-3">
                        <asp:TextBox ID="txtTitle" CssClass="form-control" runat="server" placeholder=""></asp:TextBox>
                        <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ValidationGroup="lot" EnableClientScript="true"
                              ControlToValidate="txtTitle"
                              ErrorMessage="Title is a required field."
                              ForeColor="Red">
                            </asp:RequiredFieldValidator>
                          <%--<input type="password" class="form-control" id="creat-pswrd-lb" placeholder="">--%>
                        </div>
                      </div>
                      <div class="form-group">
                        <label for="creat-pswrd-lb" class="col-sm-3 control-label">Sku</label>
                        <div class="col-sm-3">
                        <asp:TextBox ID="txtSKU" CssClass="form-control" runat="server" placeholder="optional"></asp:TextBox>
                         <%-- <input type="password" class="form-control" id="creat-pswrd-lb" placeholder="optional">--%>
                        </div>
                        <div class="col-sm-6">
                          <p>Enter a SKU(or your own internal code)to track item performance re list with ease and manage inventory(coming soon).We highly recommend that you fill this out.</p>
                        </div>
                      </div>
                      <div class="form-group">
                        <label for="creat-pswrd-lb-re" class="col-sm-3 control-label">Description</label>
                        <div class="col-sm-3">
                        <asp:TextBox ID="txtDesc" CssClass="form-control" runat="server" Rows="3"></asp:TextBox>
                          <%--<textarea class="form-control" rows="3"></textarea>--%>
                        </div>
                      </div>
                      <div class="form-group">
                        <label for="creat-pswrd-lb-re" class="col-sm-3 control-label">Checkout question</label>
                        <div class="col-sm-3">
                        <asp:TextBox ID="txtQuestion" CssClass="form-control" runat="server" placeholder="optional"></asp:TextBox>
                        </div>
                        <div class="col-sm-6">
                          <p><strong>Example</strong> what size should this ring be (6,7 or 8)?(The buyer will be asked this question when they pay)</p>
                        </div>
                      </div>
                        <div class="item form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12" for="email">
                                Auction Date <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:TextBox ID="auctiondate" ClientIDMode="Static" placeholder="DD-MM-YYYY" runat="server"
                                    data-field="date" class="form-control col-md-7 col-xs-12"></asp:TextBox><div id="Div2">
                                    </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Auction date Required" ControlToValidate="auctiondate"
                                    ForeColor="Red" ValidationGroup="Auction"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="item form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12" for="website">
                                Auction Time <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:TextBox ID="auctiontime" runat="server" class="time form-control col-md-7 col-xs-12"
                                    data-field="time" placeholder="17:00"></asp:TextBox><div id="dtBox">
                                    </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Auction time Required" ControlToValidate="auctiontime"
                                    ForeColor="Red" ValidationGroup="Auction"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
              </div>
              
              <div class="cr-accnt">
                <div class="col-md-12">
                    <div class="account-creat-title">
                        <h2>2. pricing</h2>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="form-horizontal crt-acnt-frm">
                      <div class="form-group">
                        <label for="creat-pswrd-lb" class="col-sm-3 control-label">Original price:</label>
                        <div class="col-sm-3">
                        <asp:TextBox ID="txtOriginalPrice" CssClass="form-control" runat="server" placeholder="£"></asp:TextBox>
                        </div>
                      </div>
                      </div>
                    </div>
                    <div class="col-md-12">
                    <div class="form-horizontal crt-acnt-frm">
                      <div class="form-group">
                        <label for="creat-pswrd-lb" class="col-sm-3 control-label">Deal price:</label>
                        <div class="col-sm-3">
                        <asp:TextBox ID="TxtDealPrice" CssClass="form-control" runat="server" placeholder="£"></asp:TextBox>
                        </div>
                      </div>
                      </div>
                    </div>
                </div>
              </div>

              <div class="cr-accnt">
                <div class="col-md-12">
                    <div class="account-creat-title">
                        <h2>3. shipping</h2>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="form-horizontal crt-acnt-frm">
                      	<div class="form-group">
                        	<label for="creat-ac-lb" class="col-sm-3 control-label">Packages ship from: </label>
                        	<div class="col-sm-3">
                             <asp:DropDownList runat="server" ID="ddlCountry" CssClass="form-control">
                        <asp:ListItem Text="UK"></asp:ListItem>
                        <asp:ListItem Text="Australia"></asp:ListItem>
                        <asp:ListItem Text="Norway"></asp:ListItem>
                        <asp:ListItem Text="USA"></asp:ListItem>
                        </asp:DropDownList>
   
                        	</div>
                       	</div>
                       	<div class="form-group">
                        	<label for="creat-ac-lb" class="col-sm-3 control-label">After payment i ship within: </label>
                        	<div class="col-sm-3">
                             <asp:DropDownList runat="server" ID="ddlShipWithin" CssClass="form-control">
                        <asp:ListItem Text="1 Business day"></asp:ListItem>
                        <asp:ListItem Text="2 Business day"></asp:ListItem>
                        <asp:ListItem Text="3 Business day"></asp:ListItem>
                        <asp:ListItem Text="4 Business day"></asp:ListItem>
                        <asp:ListItem Text="5 Business day"></asp:ListItem>
                        </asp:DropDownList>
                        	</div>
                       	</div>
                       	<div class="form-group">
                        	<label for="creat-ac-lb" class="col-sm-3 control-label">Delivery to the U S takes: </label>
                        	<div class="col-sm-3">
                            <asp:DropDownList runat="server" ID="ddlTimeTake" CssClass="form-control">
                                <asp:ListItem Text="1 Business day"></asp:ListItem>
                                <asp:ListItem Text="2 Business day"></asp:ListItem>
                                <asp:ListItem Text="3 Business day"></asp:ListItem>
                                <asp:ListItem Text="4 Business day"></asp:ListItem>
                                <asp:ListItem Text="5 Business day"></asp:ListItem>
                             </asp:DropDownList>
                        	</div>
                       	</div>
                       	<div class="form-group">
	                        <label for="creat-pswrd-lb" class="col-sm-3 control-label">I offer <span>free</span> shiping to the us</label>
	                        <div class="col-sm-6">
	                          	<label class="checkbox-inline">
                                <asp:CheckBox runat="server" ID="chkFreeShipping" Text="I offer free shiping to the us" />
								  <%--<input type="checkbox" id="inlineCheckbox1" value="option1">--%>
								</label>
	                      	</div>
	                    </div>
                       	<div class="form-group">
                        	<label for="creat-ac-lb" class="col-sm-3 control-label">Shiping price to the us: </label>
                        	<div class="col-sm-3">
                            <asp:DropDownList runat="server" ID="ddlPrice" CssClass="form-control">
                        <asp:ListItem Text="£0"></asp:ListItem>
                        <asp:ListItem Text="£1"></asp:ListItem>
                        <asp:ListItem Text="£2"></asp:ListItem>
                        <asp:ListItem Text="£3"></asp:ListItem>
                        <asp:ListItem Text="£4"></asp:ListItem>
                        </asp:DropDownList>
                        	</div>
                       	</div>
                       	<div class="form-group">
	                        <label for="creat-pswrd-lb" class="col-sm-3 control-label">I ship everywhere </label>
	                        <div class="col-sm-6">
	                          	<label class="checkbox-inline">
                                <asp:CheckBox runat="server" ID="chkShip" Text="I ship everywhere" />
								</label>
	                      	</div>
	                    </div>
                    </div>
                </div>
              </div>

              <div class="cr-accnt">
                <div class="col-md-12">
                    <div class="account-creat-title">
                        <h2>4. Photos</h2>
                    </div>
                </div>
                <div class="col-md-12">
                	<div class="photo-detail">
                		<p>Please upload at least (2) photos of your item</p>
                	</div>
                </div>
                <div class="col-md-12">
                    <div class="well">
                    	<ul class="shipping-lst">
                    		<li>at least 1 photo should be take by you, clearly showing any feature or defects</li>
                    		<li>Photos must be <strong>at least 500 px wide and 480 px tall </strong> and <strong>no more that 4 MB</strong> in file size</li>
                    		<li><strong>Tip: </strong>An item with more photos is more likely to sell at a higher price</li>
                    		<li>Drag and Drop photos to change the order</li>
                    	</ul>
                    </div>
                </div>
                <div class="col-md-12">
                       <div id="dZUpload" class="dropzone">
        <div class="dz-default dz-message">
            Drag and drop photos into the box.
        </div>
    </div>
    <input type="hidden" id="hdnimagefiles" name="hdnimagefiles" />
                </div>
              </div>
              <div class="col-md-12">
              	<div class="item-submit-button text-center">
                <asp:Button ID="btnSave" runat="server" Text="Save & Continue" 
                        CssClass="btn btn-danger" onclick="btnSave_Click" ValidationGroup="lot" CausesValidation="true" OnClientClick="return validateForm()"/>              		
              	</div>
              </div>
              
            </div>
        </div>
    </section>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#dtBox").DateTimePicker();
        });
    </script>
</asp:Content>
