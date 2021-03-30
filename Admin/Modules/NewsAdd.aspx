<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="NewsAdd.aspx.cs" Inherits="Admin.Modules.NewsAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<script src="../Scripts/ckfinder/ckfinder.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div class="padding-md">
		<div id="pnView" class="panel panel-default table-responsive">
			<div class="panel-heading">
				<asp:Label ID="lblTitle" runat="server" Text="Thêm mới tin tức"></asp:Label>
			</div>
			<div class="padding-md alert-info">
				<div class="row">
					<div class="col-md-12 col-sm-12">
						<asp:Button ID="btnAdd_T" runat="server" CssClass="btn btn-sm btn-success" Text="Thêm mới" OnClientClick="UpdateEditor();" OnClick="btnAdd_Click"></asp:Button>
						<asp:Button ID="btnUpdate_T" runat="server" CssClass="btn btn-sm btn-success" Text="Cập nhật" OnClientClick="UpdateEditor();" OnClick="btnAdd_Click" Visible="false"></asp:Button>
						<button type="reset" class="btn btn-sm btn-danger"><i class="fa fa-refresh fa-lg"></i> Nhập lại</button>
						<a class="btn btn-sm btn-primary" href="NewsList.aspx"><i class="fa fa-ban fa-lg"></i> Hủy bỏ</a>
					</div>
					<!-- /.col -->
				</div>
				<!-- /.row -->
			</div>
			<!-- /.padding-md -->
			<div class="padding-md clearfix">
				<div class="form-horizontal no-margin">
					<div class="form-group">
						<label class="col-lg-2 control-label">Nhóm tin tức</label>
						<div class="col-lg-10">
							<select id="ddlGroup" runat="server" class="form-control">
							</select>
							<asp:RequiredFieldValidator ID="rfvGroup" runat="server" ControlToValidate="ddlGroup" Display="Dynamic" ErrorMessage="Vui lòng chọn giá trị" SetFocusOnError="True"></asp:RequiredFieldValidator>
						</div>
						<!-- /.col -->
					</div>
					<!-- /form-group -->
					<div class="form-group">
						<label class="col-lg-2 control-label">Tiêu đề tin tức</label>
						<div class="col-lg-10">
							<input type="text" id="txtName" runat="server" class="form-control input-sm" data-required="true"/>
							<asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="Vui lòng nhập giá trị" SetFocusOnError="True"></asp:RequiredFieldValidator>
						</div>
						<!-- /.col -->
					</div>
					<!-- /form-group -->
					<div class="form-group">
						<label class="col-lg-2 control-label">Hình ảnh</label>
						<div class="col-lg-8">
							<div class="input-group">
								<input type="text" id="txtImage" runat="server" class="form-control input-sm" data-required="true"/>
								<span class="input-group-btn">
									<input id="btnImgImage" type="button" class="btn btn-default btn-sm" onclick="BrowseServer('ctl00_MainContent_txtImage', 'Images');" value="Browse Server" />
								</span>
							</div>
						</div>
						<div class="col-lg-2">
							<asp:Image ID="imgImage" runat="server" class="btn btn-default btn-sm" ImageAlign="Middle" Width="100px" ImageUrl="/img/noimageavailable.png" />
						</div>
						<!-- /.col -->
					</div>
					<!-- /form-group -->
					<div class="form-group">
						<label class="col-lg-2 control-label">Mô tả</label>
						<div class="col-lg-10">
							<textarea id="txtContent" runat="server" class="form-control" rows="3"></textarea>
						</div>
						<!-- /.col -->
					</div>
					<!-- /form-group -->
					<div class="form-group">
						<label class="col-lg-2 control-label">Chi tiết</label>
						<div class="col-lg-10">
							<FCKeditorV2:FCKeditor ID="fckDetail" runat="server" Height="300" />
						</div>
						<!-- /.col -->
					</div>
					<!-- /form-group -->
					<div class="form-group">
						<label class="col-lg-2 control-label">Hiển thị trang chủ</label>
						<div class="col-lg-10">
							<label class="label-checkbox">
								<input id="chkPriority" runat="server" type="checkbox" checked="checked" />
								<span class="custom-checkbox"></span>
								Hiển thị trang chủ
							</label>
						</div>
						<!-- /.col -->
					</div>
					<!-- /form-group -->
                    <div class="form-group">
						<label class="col-lg-2 control-label">Dịch vụ</label>
						<div class="col-lg-10">
							<select id="ddlService" runat="server" multiple="true" class="form-control chzn-select">
							</select>
						</div>
						<!-- /.col -->
					</div>
					<!-- /form-group -->
					<div class="form-group">
						<label class="col-lg-2 control-label">Keywords</label>
						<div class="col-lg-10">
							<textarea id="txtKeywords" runat="server" class="form-control" rows="3"></textarea>
						</div>
						<!-- /.col -->
					</div>
					<!-- /form-group -->
					<div class="form-group">
						<label class="col-lg-2 control-label">Description</label>
						<div class="col-lg-10">
							<textarea id="txtDescription" runat="server" class="form-control" rows="3"></textarea>
						</div>
						<!-- /.col -->
					</div>
					<!-- /form-group -->
					<div class="form-group">
						<label class="col-lg-2 control-label">Thứ tự</label>
						<div class="col-lg-10">
							<input type="text" id="txtOrd" runat="server" class="form-control input-sm" data-required="true"/>
							<asp:RangeValidator ID="rvOrder" runat="server" ErrorMessage="Vui lòng nhập 1 số!" ControlToValidate="txtOrd" MaximumValue="999999" MinimumValue="0" SetFocusOnError="true" Type="Integer"></asp:RangeValidator>
						</div>
						<!-- /.col -->
					</div>
					<!-- /form-group -->
					<div class="form-group">
						<label class="col-lg-2 control-label">Trạng thái</label>
						<div class="col-lg-10">
							<label class="label-checkbox">
								<input id="chkActive" runat="server" type="checkbox" checked="checked" />
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
						<a class="btn btn-sm btn-primary" href="NewsList.aspx"><i class="fa fa-ban fa-lg"></i> Hủy bỏ</a>
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
