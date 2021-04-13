<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="PageAdd.aspx.cs" Inherits="Admin.Modules.PageAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<script src="../Scripts/ckfinder/ckfinder.js"></script>
	<script type="text/javascript">
		$(document).ready(function () {
			if ($('#<%=ddlType.ClientID%>').val() === '0') {
				$('.page-link').show();
				$('.page-content').hide();
			}
			else {
				$('.page-link').hide();
				$('.page-content').show();
			}
			if ($('#<%=ddlLinkType.ClientID%>').val() === '0') {
				$('#<%=txtLink.ClientID%>').show();
				$('#<%=ddlLink.ClientID%>').hide();
			}
			else {
				$('#<%=txtLink.ClientID%>').hide();
				$('#<%=ddlLink.ClientID%>').show();
			}
			$('#<%=ddlType.ClientID%>').change(function () {
				if ($(this).val() === '0') {
					$('.page-link').show();
					$('.page-content').hide();
				}
				else {
					$('.page-link').hide();
					$('.page-content').show();
				}
			})
			$('#<%=ddlLinkType.ClientID%>').change(function () {
				if ($(this).val() === '0') {
					$('#<%=txtLink.ClientID%>').show();
					$('#<%=ddlLink.ClientID%>').hide();
				}
				else {
					$('#<%=txtLink.ClientID%>').hide();
					$('#<%=ddlLink.ClientID%>').show();
				}
			})
			$('#<%=ddlLink.ClientID%>').change(function () {
				var cate = $(this).find('option:selected').text().replace("■", "");
				cate = cate.substring(cate.lastIndexOf(".") + 1);
				$("#<%=txtName.ClientID%>").val(cate);
			})
		})
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div class="padding-md">
		<div id="pnView" class="panel panel-default table-responsive">
			<div class="panel-heading">
				<asp:Label ID="lblTitle" runat="server" Text="Thêm mới trang"></asp:Label>
			</div>
			<div class="padding-md alert-info">
				<div class="row">
					<div class="col-md-12 col-sm-12">
						<asp:Button ID="btnAdd_T" runat="server" CssClass="btn btn-sm btn-success" Text="Thêm mới" OnClientClick="UpdateEditor();" OnClick="btnAdd_Click"></asp:Button>
						<asp:Button ID="btnUpdate_T" runat="server" CssClass="btn btn-sm btn-success" Text="Cập nhật" OnClientClick="UpdateEditor();" OnClick="btnAdd_Click" Visible="false"></asp:Button>
						<button type="reset" class="btn btn-sm btn-danger"><i class="fa fa-refresh fa-lg"></i>Nhập lại</button>
						<a class="btn btn-sm btn-primary" href="PageList.aspx"><i class="fa fa-ban fa-lg"></i>Hủy bỏ</a>
					</div>
					<!-- /.col -->
				</div>
				<!-- /.row -->
			</div>
			<!-- /.padding-md -->
			<div class="padding-md clearfix">
				<div class="form-horizontal no-margin">
					<div class="form-group">
						<label class="col-lg-2 control-label">Tên trang</label>
						<div class="col-lg-10">
							<input type="text" id="txtName" runat="server" class="form-control input-sm" data-required="true" />
							<asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="Vui lòng nhập giá trị" SetFocusOnError="True"></asp:RequiredFieldValidator>
						</div>
						<!-- /.col -->
					</div>
					<!-- /form-group -->
					<div class="form-group">
						<label class="col-lg-2 control-label">Kiểu trang</label>
						<div class="col-lg-10">
							<select id="ddlType" runat="server" class="form-control">
								<option value="0">Trang liên kết</option>
								<option value="1">Trang nội dung</option>
							</select>
						</div>
						<!-- /.col -->
					</div>
					<!-- /form-group -->
					<div class="form-group page-link">
						<label class="col-lg-2 control-label">Liên kết</label>
						<div class="col-lg-10">
							<select id="ddlLinkType" runat="server" class="form-control">
								<option value="0">Nhập liên kết</option>
								<option value="1">Liên kết trang khác</option>
							</select>
							<br />
							<input type="text" id="txtLink" runat="server" class="form-control input-sm" value="/" />
							<select id="ddlLink" runat="server" class="form-control">
							</select>
						</div>
						<!-- /.col -->
					</div>
					<!-- /form-group -->
					<div class="form-group page-link">
						<label class="col-lg-2 control-label">Kiểu hiển thị</label>
						<div class="col-lg-10">
							<select id="ddlTarget" runat="server" class="form-control">
								<option value="_self">_self</option>
								<option value="_blank">_blank</option>
							</select>
						</div>
						<!-- /.col -->
					</div>
					<!-- /form-group -->
					<div class="form-group page-content">
						<label class="col-lg-2 control-label">Hình ảnh</label>
						<div class="col-lg-8">
							<div class="input-group">
								<input type="text" id="txtImage" runat="server" class="form-control input-sm" data-required="true"/>
								<span class="input-group-btn">
									<input id="btnImgImage" type="button" class="btn btn-default btn-sm" onclick="BrowseServer('ctl00_MainContent_txtImage', 'Advertise');" value="Browse Server" />
								</span>
							</div>
						</div>
						<div class="col-lg-2">
							<asp:Image ID="imgImage" runat="server" class="btn btn-default btn-sm" ImageAlign="Middle" Width="100px" ImageUrl="/uploads/images/DP%20008.jpg" />
						</div>
						<!-- /.col -->
					</div>
					<!-- /form-group -->
					<div class="form-group" style="display:none">
						<label class="col-lg-2 control-label">Nội dung</label>
						<div class="col-lg-10">
							<FCKeditorV2:FCKeditor ID="fckKeywords" runat="server" Height="300" />
						</div>
						<!-- /.col -->
					</div>
					<!-- /form-group -->
					<div class="form-group page-content">
						<label class="col-lg-2 control-label">Chi tiết</label>
						<div class="col-lg-10">
							<FCKeditorV2:FCKeditor ID="fckDetail" runat="server" Height="300" />
						</div>
						<!-- /.col -->
					</div>
					<!-- /form-group -->
					<div class="form-group">
						<label class="col-lg-2 control-label">Vị trí hiển thị</label>
						<div class="col-lg-10">
							<select id="ddlPosition" runat="server" multiple="true" class="form-control chzn-select">
								<option value="0">Menu trên</option>
								<option value="1">Menu giữa</option>
								<option value="2">Menu dưới</option>
								<option value="3">Giới thiệu</option>
								<option value="4">Giữa trang</option>
							</select>
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
							<input type="text" id="txtOrd" runat="server" class="form-control input-sm" data-required="true" />
							<asp:RangeValidator ID="rvOrder" runat="server" ErrorMessage="Vui lòng nhập 1 số!" ControlToValidate="txtOrd" MaximumValue="999999" MinimumValue="0" SetFocusOnError="true" Type="Integer"></asp:RangeValidator>
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
						<button type="reset" class="btn btn-sm btn-danger"><i class="fa fa-refresh fa-lg"></i>Nhập lại</button>
						<a class="btn btn-sm btn-primary" href="PageList.aspx"><i class="fa fa-ban fa-lg"></i>Hủy bỏ</a>
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
