<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Admin.Master" CodeBehind="ListAuction.aspx.cs" Inherits="LiveAuction.Admin.ListAuction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <!-- Custom styling plus plugins -->
<link href="css/custom.css" rel="stylesheet">
<link href="css/icheck/flat/green.css" rel="stylesheet">
<link href="css/datatables/tools/css/dataTables.tableTools.css" rel="stylesheet">

  <!-- Datatables -->
<script src="js/datatables/js/jquery.dataTables.js"></script>
<script src="js/datatables/tools/js/dataTables.tableTools.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="">
    <div class="page-title">
        <div class="title_left">
            <h3>
               Auction 
                <small>
                   
                </small>
            </h3>
        </div>
        <div class="title_right">
            <%--<div class="col-md-5 col-sm-5 col-xs-12 form-group pull-right top_search">
                <div class="input-group">
                    <input type="text" class="form-control" placeholder="Search for...">
                    <span class="input-group-btn">
                        <button class="btn btn-default" type="button">Go!</button>
                    </span>
                </div>
            </div>--%>
        </div>
    </div>
    <div class="clearfix"></div>
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Auction<small>List</small></h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li>
                            <a href="#"><i class="fa fa-chevron-up"></i></a>
                        </li>
                        <%--<li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false"><i class="fa fa-wrench"></i></a>
                            <ul class="dropdown-menu" role="menu">
                                <li>
                                    <a href="#">Settings 1</a>
                                </li>
                                <li>
                                    <a href="#">Settings 2</a>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <a href="#"><i class="fa fa-close"></i></a>
                        </li>--%>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                <asp:Literal ID="literalText" runat="server"></asp:Literal>
                   <%-- <table id="example" class="table table-striped responsive-utilities jambo_table">
                        <thead>
                            <tr class="headings">
                                <th>
                                    <input type="checkbox" class="tableflat">
                                </th>
                                <th>Auction Id </th>
                                <th>Auction Name </th>
                                <th>Auction Date </th>
                                <th>Commission(%) </th>                                
                                <th class=" no-link last">
                                    <span class="nobr">Action</span>
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr class="even pointer">
                                <td class="a-center ">
                                    <input type="checkbox" class="tableflat">
                                </td>
                                <td class=" ">1</td>
                                <td class=" ">Test Auction 1</td>
                                <td class=" ">May 23, 2016 03:00:56 PM </td>
                                <td class=" ">10</td>                                
                                <td class=" last">
                                    <a href="#">View</a>
                                </td>
                            </tr>
                            <tr class="odd pointer">
                                <td class="a-center ">
                                    <input type="checkbox" class="tableflat">
                                </td>
                                <td class=" ">2</td>
                                <td class=" ">Test Auction 2</td>
                                <td class=" ">May 23, 2016 03:00:56 PM </td>
                                <td class=" ">10</td>
                                <td class=" last">
                                    <a href="#">View</a>
                                </td>
                            </tr>
                            <tr class="even pointer selected">
                                <td class="a-center ">
                                    <input type="checkbox" class="tableflat">
                                </td>
                                <td class=" ">3</td>
                                <td class=" ">Test Auction 3</td>
                                <td class=" ">May 23, 2016 03:00:56 PM </td>
                                <td class=" ">10</td>
                                <td class=" last">
                                    <a href="#">View</a>
                                </td>
                            </tr>
                            <tr class="odd pointer">
                                <td class="a-center ">
                                    <input type="checkbox" class="tableflat">
                                </td>
                                <td class=" ">4</td>
                                <td class=" ">Test Auction 4</td>
                                <td class=" ">May 23, 2016 03:00:56 PM </td>
                                <td class=" ">10</td>
                                <td class=" last">
                                    <a href="#">View</a>
                                </td>
                            </tr>
                            <tr class="even pointer">
                                <td class="a-center ">
                                    <input type="checkbox" class="tableflat">
                                </td>
                                <td class=" ">5</td>
                                <td class=" ">Test Auction 5</td>
                                <td class=" ">May 23, 2016 03:00:56 PM </td>
                                <td class=" ">10</td>
                                <td class=" last">
                                    <a href="#">View</a>
                                </td>
                            </tr>
                            <tr class="odd pointer">
                                <td class="a-center ">
                                    <input type="checkbox" class="tableflat">
                                </td>
                                <td class=" ">6</td>
                                <td class=" ">Test Auction 6</td>
                                <td class=" ">May 23, 2016 03:00:56 PM </td>
                                <td class=" ">10</td>
                                <td class=" last">
                                    <a href="#">View</a>
                                </td>
                            </tr>
                            <tr class="even pointer">
                                <td class="a-center ">
                                    <input type="checkbox" class="tableflat">
                                </td>
                                <td class=" ">7</td>
                                <td class=" ">Test Auction 7</td>
                                <td class=" ">May 23, 2016 03:00:56 PM </td>
                                <td class=" ">10</td>
                                <td class=" last">
                                    <a href="#">View</a>
                                </td>
                            </tr>
                            <tr class="odd pointer">
                                <td class="a-center ">
                                    <input type="checkbox" class="tableflat">
                                </td>
                                <td class=" ">8</td>
                                <td class=" ">Test Auction 8</td>
                                <td class=" ">May 23, 2016 03:00:56 PM </td>
                                <td class=" ">10</td>
                                <td class=" last">
                                    <a href="#">View</a>
                                </td>
                            </tr>
                            <tr class="even pointer">
                                <td class="a-center ">
                                    <input type="checkbox" class="tableflat">
                                </td>
                                <td class=" ">9</td>
                                <td class=" ">Test Auction 9</td>
                                <td class=" ">May 23, 2016 03:00:56 PM </td>
                                <td class=" ">10</td>
                                <td class=" last">
                                    <a href="#">View</a>
                                </td>
                            </tr>
                            <tr class="odd pointer">
                                <td class="a-center ">
                                    <input type="checkbox" class="tableflat">
                                </td>
                                <td class=" ">10</td>
                                <td class=" ">Test Auction 10</td>
                                <td class=" ">May 23, 2016 03:00:56 PM </td>
                                <td class=" ">10</td>
                                <td class=" last">
                                    <a href="#">View</a>
                                </td>
                            </tr>
                            <tr class="even pointer">
                                <td class="a-center ">
                                    <input type="checkbox" class="tableflat">
                                </td>
                                <td class=" ">11</td>
                                <td class=" ">Test Auction 11</td>
                                <td class=" ">May 23, 2016 03:00:56 PM </td>
                                <td class=" ">10</td>
                                <td class=" last">
                                    <a href="#">View</a>
                                </td>
                            </tr>
                            <tr class="odd pointer">
                                <td class="a-center ">
                                    <input type="checkbox" class="tableflat">
                                </td>
                                <td class=" ">12</td>
                                <td class=" ">Test Auction 12</td>
                                <td class=" ">May 23, 2016 03:00:56 PM </td>
                                <td class=" ">10</td>
                                <td class=" last">
                                    <a href="#">View</a>
                                </td>
                            </tr>
                            <tr class="even pointer selected">
                                <td class="a-center ">
                                    <input type="checkbox" class="tableflat">
                                </td>
                                <td class=" ">13</td>
                                <td class=" ">Test Auction 13</td>
                                <td class=" ">May 23, 2016 03:00:56 PM </td>
                                <td class=" ">10</td>
                                <td class=" last">
                                    <a href="#">View</a>
                                </td>
                            </tr>
                            <tr class="odd pointer">
                                <td class="a-center ">
                                    <input type="checkbox" class="tableflat">
                                </td>
                                <td class=" ">14</td>
                                <td class=" ">Test Auction 14</td>
                                <td class=" ">May 23, 2016 03:00:56 PM </td>
                                <td class=" ">10</td>
                                <td class=" last">
                                    <a href="#">View</a>
                                </td>
                            </tr>
                            <tr class="even pointer">
                                <td class="a-center ">
                                    <input type="checkbox" class="tableflat">
                                </td>
                                <td class=" ">15</td>
                                <td class=" ">Test Auction 15</td>
                                <td class=" ">May 23, 2016 03:00:56 PM </td>
                                <td class=" ">10</td>
                                <td class=" last">
                                    <a href="#">View</a>
                                </td>
                            </tr>
                            <tr class="odd pointer">
                                <td class="a-center ">
                                    <input type="checkbox" class="tableflat">
                                </td>
                                <td class=" ">16</td>
                                <td class=" ">Test Auction 16</td>
                                <td class=" ">May 23, 2016 03:00:56 PM </td>
                                <td class=" ">10</td>
                                <td class=" last">
                                    <a href="#">View</a>
                                </td>
                            </tr>
                            <tr class="even pointer">
                                <td class="a-center ">
                                    <input type="checkbox" class="tableflat">
                                </td>
                                <td class=" ">17</td>
                                <td class=" ">Test Auction 17</td>
                                <td class=" ">May 23, 2016 03:00:56 PM </td>
                                <td class=" ">10</td>
                                <td class=" last">
                                    <a href="#">View</a>
                                </td>
                            </tr>
                            <tr class="odd pointer">
                                <td class="a-center ">
                                    <input type="checkbox" class="tableflat">
                                </td>
                                <td class=" ">18</td>
                                <td class=" ">Test Auction 18</td>
                                <td class=" ">May 23, 2016 03:00:56 PM </td>
                                <td class=" ">10</td>
                                <td class=" last">
                                    <a href="#">View</a>
                                </td>
                            </tr>
                            <tr class="even pointer">
                                <td class="a-center ">
                                    <input type="checkbox" class="tableflat">
                                </td>
                                <td class=" ">19</td>
                                <td class=" ">Test Auction 19</td>
                                <td class=" ">May 23, 2016 03:00:56 PM </td>
                                <td class=" ">10</td>
                                <td class=" last">
                                    <a href="#">View</a>
                                </td>
                            </tr>
                            <tr class="odd pointer">
                                <td class="a-center ">
                                    <input type="checkbox" class="tableflat">
                                </td>
                                <td class=" ">20</td>
                                <td class=" ">Test Auction 20</td>
                                <td class=" ">May 23, 2016 03:00:56 PM </td>
                                <td class=" ">10</td>
                                <td class=" last">
                                    <a href="#">View</a>
                                </td>
                            </tr>
                            <tr class="even pointer">
                                <td class="a-center ">
                                    <input type="checkbox" class="tableflat">
                                </td>
                                <td class=" ">21</td>
                                <td class=" ">Test Auction 21</td>
                                <td class=" ">May 23, 2016 03:00:56 PM </td>
                                <td class=" ">10</td>
                                <td class=" last">
                                    <a href="#">View</a>
                                </td>
                            </tr>
                            <tr class="odd pointer">
                                <td class="a-center ">
                                    <input type="checkbox" class="tableflat">
                                </td>
                                <td class=" ">22</td>
                                <td class=" ">Test Auction 22</td>
                                <td class=" ">May 23, 2016 03:00:56 PM </td>
                                <td class=" ">10</td>
                                <td class=" last">
                                    <a href="#">View</a>
                                </td>
                            </tr>
                            <tr class="even pointer selected">
                                <td class="a-center ">
                                    <input type="checkbox" class="tableflat">
                                </td>
                                <td class=" ">23</td>
                                <td class=" ">Test Auction 23</td>
                                <td class=" ">May 23, 2016 03:00:56 PM </td>
                                <td class=" ">10</td>
                                <td class=" last">
                                    <a href="#">View</a>
                                </td>
                            </tr>
                            <tr class="odd pointer">
                                <td class="a-center ">
                                    <input type="checkbox" class="tableflat">
                                </td>
                                <td class=" ">24</td>
                                <td class=" ">Test Auction 24</td>
                                <td class=" ">May 23, 2016 03:00:56 PM </td>
                                <td class=" ">10</td>
                                <td class=" last">
                                    <a href="#">View</a>
                                </td>
                            </tr>
                            <tr class="even pointer">
                                <td class="a-center ">
                                    <input type="checkbox" class="tableflat">
                                </td>
                                <td class=" ">25</td>
                                <td class=" ">Test Auction 25</td>
                                <td class=" ">May 23, 2016 03:00:56 PM </td>
                                <td class=" ">10</td>
                                <td class=" last">
                                    <a href="#">View</a>
                                </td>
                            </tr>
                            <tr class="odd pointer">
                                <td class="a-center ">
                                    <input type="checkbox" class="tableflat">
                                </td>
                                <td class=" ">26</td>
                                <td class=" ">Test Auction 26</td>
                                <td class=" ">May 23, 2016 03:00:56 PM </td>
                                <td class=" ">10</td>
                                <td class=" last">
                                    <a href="#">View</a>
                                </td>
                            </tr>
                            <tr class="even pointer">
                                <td class="a-center ">
                                    <input type="checkbox" class="tableflat">
                                </td>
                                <td class=" ">27</td>
                                <td class=" ">Test Auction 27</td>
                                <td class=" ">May 23, 2016 03:00:56 PM </td>
                                <td class=" ">10</td>
                                <td class=" last">
                                    <a href="#">View</a>
                                </td>
                            </tr>
                            <tr class="odd pointer">
                                <td class="a-center ">
                                    <input type="checkbox" class="tableflat">
                                </td>
                                <td class=" ">28</td>
                                <td class=" ">Test Auction 28</td>
                                <td class=" ">May 23, 2016 03:00:56 PM </td>
                                <td class=" ">10</td>
                                <td class=" last">
                                    <a href="#">View</a>
                                </td>
                            </tr>
                            <tr class="even pointer">
                                <td class="a-center ">
                                    <input type="checkbox" class="tableflat">
                                </td>
                                <td class=" ">29</td>
                                <td class=" ">Test Auction 29</td>
                                <td class=" ">May 23, 2016 03:00:56 PM </td>
                                <td class=" ">10</td>
                                <td class=" last">
                                    <a href="#">View</a>
                                </td>
                            </tr>
                            <tr class="odd pointer">
                                <td class="a-center ">
                                    <input type="checkbox" class="tableflat">
                                </td>
                                <td class=" ">30</td>
                                <td class=" ">Test Auction 30</td>
                                <td class=" ">May 23, 2016 03:00:56 PM </td>
                                <td class=" ">10</td>
                                <td class=" last">
                                    <a href="#">View</a>
                                </td>
                            </tr>
                           
                        </tbody>
                    </table>--%>
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
