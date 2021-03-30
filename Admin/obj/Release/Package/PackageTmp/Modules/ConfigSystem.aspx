<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="ConfigSystem.aspx.cs" Inherits="Admin.Modules.ConfigSystem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<script src="../Scripts/ckfinder/ckfinder.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div class="padding-md">
		<div id="pnView" class="panel panel-default table-responsive">
			<div class="panel-heading">
				<asp:Label ID="lblTitle" runat="server" Text="Cấu hình hệ thống"></asp:Label>
			</div>
			<div class="padding-md alert-info">
				<div class="row">
					<div class="col-md-12 col-sm-12">
						<asp:Button ID="btnUpdate_T" runat="server" CssClass="btn btn-sm btn-success" Text="Cập nhật" OnClientClick="UpdateEditor();" OnClick="btnAdd_Click"></asp:Button>
					</div>
					<!-- /.col -->
				</div>
				<!-- /.row -->
			</div>
			<!-- /.padding-md -->
			<div class="padding-md clearfix">
				<div class="form-horizontal no-margin">
					<div class="form-group">
						<label class="col-lg-2 control-label">Máy chủ gửi mail</label>
						<div class="col-lg-10">
							<input type="text" id="txtSmtpServer" runat="server" class="form-control input-sm" data-required="true"/>
						</div>
						<!-- /.col -->
					</div>
					<!-- /form-group -->
					<div class="form-group">
						<label class="col-lg-2 control-label">Cổng gửi mail</label>
						<div class="col-lg-10">
							<input type="text" id="txtPort" runat="server" class="form-control input-sm" data-required="true"/>
						</div>
						<!-- /.col -->
					</div>
					<!-- /form-group -->
					<div class="form-group">
						<label class="col-lg-2 control-label">Mail nhận liên hệ</label>
						<div class="col-lg-10">
							<input type="text" id="txtMailReceipt" runat="server" class="form-control input-sm" data-required="true"/>
						</div>
						<!-- /.col -->
					</div>
					<!-- /form-group -->
					<div class="form-group">
						<label class="col-lg-2 control-label">Mail gửi thông tin</label>
						<div class="col-lg-10">
							<input type="text" id="txtMailSend" runat="server" class="form-control input-sm" data-required="true"/>
						</div>
						<!-- /.col -->
					</div>
					<!-- /form-group -->
					<div class="form-group">
						<label class="col-lg-2 control-label">Mật khẩu mail gửi</label>
						<div class="col-lg-10">
							<input type="text" id="txtEmailPassword" runat="server" class="form-control input-sm" data-required="true"/>
						</div>
						<!-- /.col -->
					</div>
					<!-- /form-group -->
					<div class="form-group">
						<label class="col-lg-2 control-label">Thông tin liên hệ</label>
						<div class="col-lg-10">
							<FCKeditorV2:FCKeditor ID="fckDetail" runat="server" Height="200"/>
						</div>
						<!-- /.col -->
					</div>
					<!-- /form-group -->
					<div class="form-group">
						<label class="col-lg-2 control-label">Copyright</label>
						<div class="col-lg-10">
							<FCKeditorV2:FCKeditor ID="fckCopyright" runat="server" Height="100" ToolbarSet="Basic" />
						</div>
						<!-- /.col -->
					</div>
					<!-- /form-group -->
				</div>
				<!-- /panel-body -->
			</div>
			<!-- /.padding-md -->
			<div class="padding-md alert-info">
				<div class="row">
					<div class="col-md-12 col-sm-12">
						<asp:Button ID="btnUpdate_B" runat="server" CssClass="btn btn-sm btn-success" Text="Cập nhật" OnClientClick="UpdateEditor();" OnClick="btnAdd_Click"></asp:Button>
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
