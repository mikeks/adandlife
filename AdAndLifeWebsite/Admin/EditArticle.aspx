<%@ Page ValidateRequest="false" Language="C#" AutoEventWireup="true" CodeBehind="EditArticle.aspx.cs" Inherits="AdAndLifeWebsite.Admin.EditArticle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<script src="/tinymce/tinymce.min.js"></script>
	<script>

		tinymce.init({
			selector: 'textarea',
			height: 500,
			menubar: false,
			plugins: [
			  'advlist autolink lists link image charmap print preview anchor',
			  'searchreplace visualblocks code fullscreen',
			  'insertdatetime media table contextmenu paste code'
			],
			toolbar: 'undo redo | insert | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image',
			content_css: '//www.tinymce.com/css/codepen.min.css'
		});


	</script>
</head>
<body>
	<form id="form1" runat="server">
		<div>

		Название статьи: <asp:TextBox runat="server" ID="ArticleName" />
		</div>


		Текст статьи:
		<textarea runat="server" id="ArticleText">
<		</textarea>

		<asp:Button runat="server" Text="Сохранить" />

	</form>

</body>
</html>
