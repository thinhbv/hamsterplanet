<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeftMenu.ascx.cs" Inherits="Admin.Controls.LeftMenu" %>
<div class="size-toggle">
	<a class="btn btn-sm" id="sizeToggle">
		<span class="icon-bar"></span>
		<span class="icon-bar"></span>
		<span class="icon-bar"></span>
	</a>
	<a class="btn btn-sm pull-right logoutConfirm_open" href="#logoutConfirm">
		<i class="fa fa-power-off"></i>
	</a>
</div>
<!-- /size-toggle -->
<div class="main-menu">
	<ul>
		<li class="openable">
			<a href="#">
				<span class="menu-icon">
					<i class="fa fa-file-text fa-lg"></i>
				</span>
				<span class="text">Quản lý</span>
				<span class="menu-hover"></span>
			</a>
			<ul class="submenu">
				<li><a href="ConfigSystem.aspx"><span class="submenu-label">Cấu hình</span></a></li>
				<li><a href="UserList.aspx"><span class="submenu-label">Người dùng</span></a></li>
				<li><a href="PageList.aspx"><span class="submenu-label">Danh mục trang</span></a></li>
				<li><a href="AdvertiseList.aspx"><span class="submenu-label">Liên kết, Quảng cáo</span></a></li>
				<li><a href="ContactList.aspx"><span class="submenu-label">Liên hệ, Phản hồi</span></a></li>
			</ul>
		</li>
		<li class="openable">
			<a href="#">
				<span class="menu-icon">
					<i class="fa fa-tag fa-lg"></i>
				</span>
				<span class="text">Dịch vụ</span>
				<span class="menu-hover"></span>
			</a>
			<ul class="submenu">
				<li><a href="GroupServiceList.aspx"><span class="submenu-label">Nhóm dịch vụ</span></a></li>
				<li><a href="ServicesList.aspx"><span class="submenu-label">Danh sách dịch vụ</span></a></li>
				<li><a href="GroupImageList.aspx"><span class="submenu-label">Nhóm hình ảnh</span></a></li>
				<li><a href="ImagesList.aspx"><span class="submenu-label">Danh sách hình ảnh</span></a></li>
			</ul>
		</li>
        <li class="openable">
			<a href="#">
				<span class="menu-icon">
					<i class="fa fa-tag fa-lg"></i>
				</span>
				<span class="text">Sản phẩm</span>
				<span class="menu-hover"></span>
			</a>
			<ul class="submenu">
				<li><a href="GroupProductList.aspx"><span class="submenu-label">Nhóm sản phẩm</span></a></li>
				<li><a href="ProductList.aspx"><span class="submenu-label">Danh sách sản phẩm</span></a></li>
			</ul>
		</li>
		<li class="openable">
			<a href="#">
				<span class="menu-icon">
					<i class="fa fa-tag fa-lg"></i>
				</span>
				<span class="text">Tin tức</span>
				<span class="menu-hover"></span>
			</a>
			<ul class="submenu">
				<li><a href="GroupNewsList.aspx"><span class="submenu-label">Nhóm tin tức</span></a></li>
				<li><a href="NewsList.aspx"><span class="submenu-label">Danh sách tin tức</span></a></li>
			</ul>
		</li>
		<li class="openable">
			<a href="#">
				<span class="menu-icon">
					<i class="fa fa-tag fa-lg"></i>
				</span>
				<span class="text">Hỗ trợ trực tuyến</span>
				<span class="menu-hover"></span>
			</a>
			<ul class="submenu">
				<li><a href="SupportList.aspx"><span class="submenu-label">Thông tin hỗ trợ</span></a></li>
			</ul>
		</li>
		<li class="openable">
			<a href="#">
				<span class="menu-icon">
					<i class="fa fa-tag fa-lg"></i>
				</span>
				<span class="text">Chức năng khác</span>
				<span class="menu-hover"></span>
			</a>
			<ul class="submenu">
				<li><a href="UploadImage.aspx"><span class="submenu-label">Upload ảnh</span></a></li>
			</ul>
		</li>
	</ul>
</div>
<!-- /main-menu -->
