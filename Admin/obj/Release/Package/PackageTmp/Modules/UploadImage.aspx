<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPage.Master" AutoEventWireup="true" CodeBehind="UploadImage.aspx.cs" Inherits="Admin.Modules.UploadImage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<script type="text/javascript">
		var win;
		function OpenCenter(url, name, w, h) {
			var left = (screen.width - w) / 2;
			var top = (screen.height - h) / 4;
			win = window.open(url, name, 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
			var pollTimer = window.setInterval(function () {
				if (win.closed !== false) { // !== is required for compatibility with Opera
					window.location.reload(true);
					window.clearInterval(pollTimer);
				}
			}, 200);
		}

	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div class="padding-md">
		<div id="pnView" class="panel panel-default table-responsive">
			<div class="panel-heading">
				Upload ảnh
		
			</div>
			<div class="padding-md alert-info">
				<div class="row">
					<div class="col-md-12 col-sm-12">
						<asp:LinkButton CssClass="btn btn-sm btn-info" ID="lbtUploadT" runat="server" OnClick="lbtUpload_Click"><i class="fa fa-upload fa-lg"></i> Upload</asp:LinkButton>
						<a href="javascript:void(0);" class="btn btn-sm btn-danger" onclick="OpenCenter('/scripts/ckfinder/ckfinder.html','CreateFolder','600', '600');"><i class="fa fa-folder-open fa-lg"></i>Tạo/Xóa thư mục</a>
						<asp:LinkButton CssClass="btn btn-sm btn-success" ID="lbtRefreshT" runat="server" OnClientClick="javascript:window.loacation.reload(true);"><i class="fa fa-refresh fa-lg"></i> Làm mới</asp:LinkButton>
					</div>
					<!-- /.col -->
				</div>
				<!-- /.row -->
			</div>
			<!-- /.padding-md -->
			<div class="padding-md clearfix">
				<div class="form-horizontal no-margin">
					<div class="form-group">
						<label class="col-lg-2 control-label">Thư mục upload</label>
						<div class="col-lg-10">
							<asp:TreeView ID="TreeView1" runat="server" ImageSet="Arrows" NodeIndent="15">
								<HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
								<NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px"
									NodeSpacing="0px" VerticalPadding="2px"></NodeStyle>
								<ParentNodeStyle Font-Bold="False" />
								<SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px"
									VerticalPadding="0px" />
							</asp:TreeView>
						</div>
						<!-- /.col -->
					</div>
					<!-- /form-group -->
					<div class="form-group">
						<label class="col-lg-2 control-label">Chọn ảnh</label>
						<div class="col-lg-10">
							<div class="upload-file">
							<asp:FileUpload ID="fupFiles" runat="server" AllowMultiple="true" CssClass="upload-demo" />
							<label data-title="Select file" for="<%=fupFiles.ClientID %>">
								<span data-title="No file selected..."></span>
							</label>
							</div>
						</div>
						<!-- /.col -->
					</div>
					<!-- /form-group -->
					<div class="form-group">
						<label class="col-lg-2 control-label">Kết quả Upload</label>
						<div class="col-lg-10">
							<asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
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
						<asp:LinkButton CssClass="btn btn-sm btn-info" ID="lbtUploadB" runat="server" OnClick="lbtUpload_Click"><i class="fa fa-upload fa-lg"></i> Upload</asp:LinkButton>
						<a href="javascript:void(0);" class="btn btn-sm btn-danger" onclick="OpenCenter('/scripts/ckfinder/ckfinder.html','CreateFolder','600', '600');"><i class="fa fa-folder-open fa-lg"></i>Tạo/Xóa thư mục</a>
						<asp:LinkButton CssClass="btn btn-sm btn-success" ID="lbtRefreshB" runat="server" OnClientClick="javascript:window.loacation.reload(true);"><i class="fa fa-refresh fa-lg"></i> Làm mới</asp:LinkButton>
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
