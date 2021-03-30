<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="UserAdd.aspx.cs" Inherits="Admin.Modules.UserAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div class="padding-md">
		<div id="pnView" class="panel panel-default table-responsive">
			<div class="panel-heading">
				<asp:Label ID="lblTitle" runat="server" Text="Thêm mới người dùng"></asp:Label>
			</div>
			<div class="padding-md alert-info">
				<div class="row">
					<div class="col-md-12 col-sm-12">
						<asp:Button ID="btnAdd_T" runat="server" CssClass="btn btn-sm btn-success" Text="Thêm mới" OnClientClick="UpdateEditor();" OnClick="btnAdd_Click"></asp:Button>
						<asp:Button ID="btnUpdate_T" runat="server" CssClass="btn btn-sm btn-success" Text="Cập nhật" OnClientClick="UpdateEditor();" OnClick="btnAdd_Click" Visible="false"></asp:Button>
						<button type="reset" class="btn btn-sm btn-danger"><i class="fa fa-refresh fa-lg"></i> Nhập lại</button>
						<a class="btn btn-sm btn-primary" href="UserList.aspx"><i class="fa fa-ban fa-lg"></i> Hủy bỏ</a>
					</div>
					<!-- /.col -->
				</div>
				<!-- /.row -->
			</div>
			<!-- /.padding-md -->
			<div class="padding-md clearfix">
				<div class="form-horizontal no-margin">
					<div class="form-group">
						<label class="col-lg-2 control-label">Tên người dùng</label>
						<div class="col-lg-10">
							<input type="text" id="txtName" runat="server" class="form-control input-sm" data-required="true"/>
							<asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="Vui lòng nhập giá trị" SetFocusOnError="True"></asp:RequiredFieldValidator>
						</div>
						<!-- /.col -->
					</div>
					<!-- /form-group -->
					<div class="form-group">
						<label class="col-lg-2 control-label">Tên đăng nhập</label>
						<div class="col-lg-10">
							<input type="text" id="txtUserName" runat="server" class="form-control input-sm" data-required="true"/>
							<asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName" Display="Dynamic" ErrorMessage="Vui lòng nhập giá trị" SetFocusOnError="True"></asp:RequiredFieldValidator>
						</div>
						<!-- /.col -->
					</div>
					<!-- /form-group -->
					<div class="form-group">
						<label class="col-lg-2 control-label">Mật khẩu</label>
						<div class="col-lg-10">
							<input type="password" id="txtPassword" runat="server" class="form-control input-sm" data-required="true"/>
						</div>
						<!-- /.col -->
					</div>
					<!-- /form-group -->
					<div class="form-group">
						<label class="col-lg-2 control-label">Email</label>
						<div class="col-lg-10">
							<input type="text" id="txtEmail" runat="server" class="form-control input-sm" data-required="true"/>
						</div>
						<!-- /.col -->
					</div>
					<!-- /form-group -->
					<div class="form-group">
						<label class="col-lg-2 control-label">Phone</label>
						<div class="col-lg-10">
							<input type="text" id="txtPhone" runat="server" class="form-control input-sm"/>
						</div>
						<!-- /.col -->
					</div>
					<!-- /form-group -->
					<div class="form-group">
						<label class="col-lg-2 control-label">Quyền Admin</label>
						<div class="col-lg-10">
							<label class="label-checkbox">
								<input id="chkAdmin" runat="server" type="checkbox" />
								<span class="custom-checkbox"></span>
								Admin
							</label>
						</div>
						<!-- /.col -->
					</div>
					<!-- /form-group -->
					<div class="form-group">
						<label class="col-lg-2 control-label">Trạng thái</label>
						<div class="col-lg-10">
							<label class="label-checkbox">
								<input id="chkActive" runat="server" type="checkbox" />
								<span class="custom-checkbox"></span>
								Kích hoạt
							</label>
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
						<asp:Button ID="btnAdd_B" runat="server" CssClass="btn btn-sm btn-success" Text="Thêm mới" OnClick="btnAdd_Click"></asp:Button>
						<asp:Button ID="btnUpdate_B" runat="server" CssClass="btn btn-sm btn-success" Text="Cập nhật" OnClientClick="UpdateEditor();" OnClick="btnAdd_Click" Visible="false"></asp:Button>
						<button type="reset" class="btn btn-sm btn-danger"><i class="fa fa-refresh fa-lg"></i> Nhập lại</button>
						<a class="btn btn-sm btn-primary" href="UserList.aspx"><i class="fa fa-ban fa-lg"></i> Hủy bỏ</a>
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
