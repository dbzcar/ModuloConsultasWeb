<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ModuloConsultasWeb.WebForm.Login.Login"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">

    <div class="container col-lg-8">
      		<div class="form-group">
        		<label for="username" class="col-form-label-lg">Nombre de usuario:</label>
                <input runat="server" class="form-control" id="txtUsername" type="text" name="username" placeholder="Nombre Usuario" required>

    	   </div>
        
    		<div class="form-group">
        		<label for="username" class="col-form-label-lg">Contraseña:</label>
                <input runat="server" class="form-control" id="txtPassword" type="password" name="username" placeholder="Contraseña" required>
    	        </div>

    		<div class="form-group">
                <a href="#">Olvidé mi contraseña</a>
                <asp:Button CssClass="btn btn-primary" ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
    	   </div>
        </div>

</asp:Content>
