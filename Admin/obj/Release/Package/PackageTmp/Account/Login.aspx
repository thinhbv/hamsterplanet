<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Admin.Account.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="vi">
<head runat="server">
	<meta charset="utf-8">
	<title><%=project %> - Hệ thống quản trị thông tin</title>
	<meta name="viewport" content="width=device-width, initial-scale=1.0">
	<meta name="description" content="">
	<meta name="author" content="">
	<link rel="icon" href="/img/favicon.ico" sizes="32x32">

	<!-- Bootstrap core CSS -->
	<link href="/bootstrap/css/bootstrap.min.css" rel="stylesheet">

	<!-- Font Awesome -->
	<link href="/css/font-awesome.min.css" rel="stylesheet">

	<!-- Endless -->
	<link href="/css/endless.min.css" rel="stylesheet">
</head>
<body>
	<form id="form1" runat="server">
		<div class="login-wrapper">
			<div class="text-center">
				<h2 class="fadeInUp animation-delay8" style="font-weight: bold">
					<span class="text-success"><%=project %></span> <span style="color: #ccc; text-shadow: 0 1px #fff">Admin</span>
				</h2>
			</div>
			<div class="login-widget animation-delay1">
				<div class="panel panel-default">
					<div class="panel-heading clearfix">
						<div class="pull-left">
							<i class="fa fa-lock fa-lg"></i> Đăng nhập
						</div>
					</div>
					<div class="panel-body">
						<div class="form-group">
							<label>Tên đăng nhập</label>
							<input type="text" id="txtUserName" runat="server" placeholder="Tên đăng nhập" class="form-control input-sm bounceIn animation-delay2">
						</div>
						<div class="form-group">
							<label>Mật khẩu</label>
							<input type="password" id="txtPassword" runat="server" placeholder="Mật khẩu" class="form-control input-sm bounceIn animation-delay4">
						</div>
						<div class="col-lg-8">
							<asp:Label ID="lblMsg" runat="server" CssClass="control-label" Text="Đăng nhập không thành công" ForeColor="Red" Visible="false"></asp:Label>
						</div>
						<div class="col-lg-4">
							<asp:Button ID="btnLogin" runat="server" CssClass="btn btn-success btn-sm bounceIn animation-delay5 login-link pull-right" Text="Đăng nhập" OnClick="btnLogin_Click"></asp:Button>
						</div>
					</div>
				</div>
				<!-- /panel -->
			</div>
			<!-- /login-widget -->
		</div>
		<!-- /login-wrapper -->

		<!-- Le javascript
    ================================================== -->
	</form>
	<!-- Placed at the end of the document so the pages load faster -->

	<!-- Jquery -->
	<script src="/js/jquery-1.10.2.min.js"></script>

	<!-- Bootstrap -->
	<script src="/bootstrap/js/bootstrap.min.js"></script>

	<!-- Modernizr -->
	<script src='/js/modernizr.min.js'></script>

	<!-- Pace -->
	<script src='/js/pace.min.js'></script>

	<!-- Popup Overlay -->
	<script src='/js/jquery.popupoverlay.min.js'></script>

	<!-- Slimscroll -->
	<script src='/js/jquery.slimscroll.min.js'></script>

	<!-- Cookie -->
	<script src='/js/jquery.cookie.min.js'></script>

	<!-- Endless -->
	<script src="/js/endless/endless.js"></script>
</body>
</html>
