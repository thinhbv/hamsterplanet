﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="NewsList.aspx.cs" Inherits="Admin.Modules.NewsList" %>
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
				Quản lý tin tức
				<asp:Label ID="lblCount" runat="server" CssClass="label label-info pull-right"></asp:Label>
			</div>
			<div class="padding-md alert-info">
				<div class="row">
					<div class="col-md-12 col-sm-12">
						<a class="btn btn-sm btn-success" href="NewsAdd.aspx"><i class="fa fa-plus-circle fa-lg"></i> Thêm mới</a>
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
							<th>Tiêu đề tin tức</th>
							<th>Hình ảnh</th>
							<th>Mô tả</th>
							<th>Hiển thị trang chủ</th>
							<th>Thứ tự</th>
							<th>Kích hoạt</th>
							<th>Thao tác</th>
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
									<td><%#Eval("Name") %></td>
									<td><img src='<%#StringClass.ThumbImage(Eval("Image").ToString()) %>' alt='<%#Eval("Name") %>' title='<%#Eval("Name") %>' width="100" /></td>
									<td><%#StringClass.FormatContentNews(Eval("Content").ToString(), 50) %></td>
									<td><%#BizUtils.ShowCheckBoxStatus(Eval("Priority").ToString()) %></td>
									<td><%#Eval("Ord") %></td>
									<td><%#BizUtils.ShowStatus(Eval("Active").ToString()) %></td>
									<td>
										<asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Sửa" CommandName="Edit"
											CssClass="Edit" ToolTip="Sửa" ImageUrl="/App_Themes/Admin/images/edit.png" CommandArgument='<%#Eval("Id")%>' />
										<asp:ImageButton ID="cmdDelete" runat="server" AlternateText="Xóa" CommandName="Delete" CssClass="Delete"
											ToolTip="Xóa" ImageUrl="~/App_Themes/Admin/images/delete.png" CommandArgument='<%#Eval("Id")%>' OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" />
										<asp:ImageButton ID="cmdActive" runat="server" AlternateText='Hiển thị' CommandName="Active" CssClass="Active" ToolTip='Hiển thị'
											ImageUrl="~/App_Themes/Admin/images/start.png" CommandArgument='<%#Eval("Active")%>' />
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
						<a class="btn btn-sm btn-success" href="NewsAdd.aspx"><i class="fa fa-plus-circle fa-lg"></i> Thêm mới</a>
						<asp:Button ID="btnDelete_B" runat="server" CssClass="btn btn-sm btn-danger" OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" Text="Xóa" OnClick="btnDelete_Click"></asp:Button>
					</div>
					<!-- /.col -->
				</div>
				<!-- /.row -->
			</div>
			<!-- /.padding-md -->
		</div>
		<!-- /panel -->
		<div id="pnInfo" class="panel panel-default table-responsive" visible="false">
		</div>
		<!-- /panel -->
	</div>
	<!-- /.padding-md -->
</asp:Content>
