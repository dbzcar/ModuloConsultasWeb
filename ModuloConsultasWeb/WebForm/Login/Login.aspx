<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ModuloConsultasWeb.WebForm.Login.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">

      		<div class="form-group">
        		<label for="username">Nombre de usuario:</label>
        		<%--<asp:TextBox CssClass="form-control" ID="ttxtUsername" runat="server"></asp:TextBox>--%>
                <input runat="server" class="form-control" id="txtUsername" type="text" name="username" placeholder="Nombre Usuario">

    	   </div>
        
    		<div class="form-group">
        		<label for="username">Contraseña:</label>
                <asp:TextBox CssClass="form-control" ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
    	   </div>

    		<div class="form-group">
                <a href="#">Olvidé mi contraseña</a>
                <asp:Button CssClass="btn btn-primary" ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
    	   </div>

</asp:Content>
