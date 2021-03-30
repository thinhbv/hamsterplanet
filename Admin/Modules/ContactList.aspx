<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="ContactList.aspx.cs" Inherits="Admin.Modules.ContactList" %>
<%@ Import Namespace="Libs.Utils" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<style type="text/css">
		#checkbox .DataTables_sort_icon {
			display:none;
		}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div class="padding-md">
		<div id="pnView" class="panel panel-default table-responsive">
			<div class="panel-heading">
				Quản lý thông tin liên hệ
				<asp:Label ID="lblCount" runat="server" CssClass="label label-info pull-right"></asp:Label>
			</div>
			<div class="padding-md alert-info">
				<div class="row">
					<div class="col-md-12 col-sm-12">
						<asp:Button ID="btnDelete_T" runat="server" CssClass="btn btn-sm btn-danger" OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" Text="Xóa"  OnClick="btnDelete_Click"></asp:Button>
					</div>
					<!-- /.col -->
				</div>
				<!-- /.row -->
			</div>
			<!-- /.padding-md -->
			<div class="padding-md clearfix">
				<table class="table table-bordered table-hover table-striped" id="dataTable">
					<thead>
						<tr>
							<th id="checkbox">
								<label class="label-checkbox">
									<input type="checkbox" id="chk-all"/>
									<span class="custom-checkbox" style="top: -9px; left: -2px;"></span>
								</label>
							</th>
							<th>Tên khách hàng</th>
							<th>Công ty</th>
							<th>Email</th>
							<th>Phone</th>
							<th>Tiêu đề</th>
							<th>Chi tiết</th>
							<th>Ngày liên hệ</th>
						</tr>
					</thead>
					<tbody>
						<asp:Repeater ID="rptData" runat="server" OnItemCommand="rptData_ItemCommand">
							<ItemTemplate>
								<tr>
									<td>
										<label class="label-checkbox">
											<input id="chkItem" runat="server" type="checkbox" class="chk-row">
											<span class="custom-checkbox"></span>
										</label>
									</td>
									<td><%#Eval("Name").ToString() %></td>
									<td><%#Eval("Company").ToString() %></td>
									<td><%#Eval("Email").ToString() %></td>
									<td><%#Eval("Phone").ToString() %></td>
									<td><%#Eval("Title").ToString() %></td>
									<td><%#Eval("Detail").ToString() %></td>
									<td><%#string.Format("{0:dd/MM/yyyy}", Eval("Date")) %></td>
									<td>
										<asp:ImageButton ID="cmdDelete" runat="server" AlternateText="Xóa" CommandName="Delete" CssClass="Delete"
											ToolTip="Xóa" ImageUrl="~/App_Themes/Admin/images/delete.png" CommandArgument='<%#Eval("Id")%>' OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" />
								<asp:HiddenField ID="hdId" runat="server" Value='<%#Eval("Id") %>' />
									</td>
								</tr>
							</ItemTemplate>
						</asp:Repeater>
					</tbody>
				</table>
			</div>
			<!-- /.padding-md -->
			<div class="padding-md alert-info">
				<div class="row">
					<div class="col-md-12 col-sm-12">
						<asp:Button ID="btnDelete_B" runat="server" CssClass="btn btn-sm btn-danger" OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" Text="Xóa" OnClick="btnDelete_Click"></asp:Button>
					</div>
					<!-- /.col -->
				</div>
				<!-- /.row -->
			</div>
			<!-- /.padding-md -->
		</div>
		<!-- /panel -->
	</div>
	<!-- /.padding-md -->
</asp:Content>
