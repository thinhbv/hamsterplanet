<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="Admin.Controls.Header" %>
<div class="brand">
	<span><%=project %></span>
	<span class="text-toggle">Admin</span>
</div>
<!-- /brand -->
<button type="button" class="navbar-toggle pull-left" id="sidebarToggle">
	<span class="icon-bar"></span>
	<span class="icon-bar"></span>
	<span class="icon-bar"></span>
</button>
<button type="button" class="navbar-toggle pull-left hide-menu" id="menuToggle">
	<span class="icon-bar"></span>
	<span class="icon-bar"></span>
	<span class="icon-bar"></span>
</button>
<ul class="nav-notification clearfix">
    <li class="profile">
        <a class="dropdown-toggle" href="https://www.dehun.com.vn" target="_blank">Trang chủ</a>
    </li>
	<li class="profile dropdown">
		<a class="dropdown-toggle" data-toggle="dropdown" href="#">Xin chào <strong><%=UserName %></strong>
			<span><i class="fa fa-chevron-down"></i></span>
		</a>
		<ul class="dropdown-menu">
			<li>
				<a class="clearfix" href="#">
					<div class="detail">
						<strong><%=Session["FullName"] %></strong>
						<p class="grey"><%=Session["Email"] %></p>
					</div>
				</a>
			</li>
			<li class="divider"></li>
			<li><a tabindex="-1" class="main-link logoutConfirm_open" href="#logoutConfirm"><i class="fa fa-lock fa-lg"></i> Đăng xuất</a></li>
		</ul>
	</li>
</ul>
