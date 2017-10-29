<%@ Page ValidateRequest="false" Language="C#" AutoEventWireup="true" MasterPageFile="admin.Master" CodeBehind="EditArticle.aspx.cs" Inherits="AdAndLifeWebsite.Admin.EditArticle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">

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
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentArea" runat="server">

    <h1>Редактирование статьи</h1>

	<%if (IsSaved)
		{ %>
	<div style="font-size:26px;color:green;margin:15px 0">Изменения сохранены</div>
	<% } %>

	<div style="font-size:26px;color:red;margin:15px 0"><%= ErrorMessage %></div>

	<div>
		Название статьи:
			<asp:TextBox runat="server" ID="ArticleName" Width="300" />
	</div>
	
	Текст статьи:
		<textarea runat="server" id="ArticleText">
		</textarea>



<%--    <div style="margin:15px 0;">
    <%foreach (var url in Article.GetImagesUrls())
        {
            Response.Write("<img style=\"width:100px\" src=\"" + url + "\" />");
        }
    %>
    </div>--%>

    <div style="margin:15px 0;">
	    Прежде чем использовать картинку на сайте, ее нужно загрузить тут. Допускается формат PNG или JPG.<br />
	    <asp:FileUpload ID="FileUpload1" runat="server" />
    </div>


	<asp:Button runat="server" Text="Сохранить" />

</asp:Content>
