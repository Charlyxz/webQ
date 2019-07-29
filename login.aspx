<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Login</title>
    	<meta charset="utf-8">
		<meta http-equiv="X-UA-Compatible" content="IE=edge">
		<meta name="viewport" content="width=device-width, initial-scale=1">
    	<script src="js/q.js"></script>
        <script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
		<link href="css/mui.min.css" rel="stylesheet" type="text/css" />
		<script src="js/mui.min.js"></script>
</head>
<body>     
    
    <div class="mui-container" style="max-width: 800px; ">
      <div class="mui-panel">
        <h1>Quiniela PRSM</h1>
        
      </div>
    </div>


     <div class="mui-container" style="max-width: 800px; ">
        <center>
        <form id="frmRegistro" runat="server" class="mui-form" >
        <legend>Acceso</legend>
          <div class="mui-textfield">
            <input type="text" placeholder="Usuario" id="us_usuario" runat="server" />
          </div>
          <div class="mui-textfield">
            <input type="password" placeholder="Password" id="us_password" runat="server" />
          </div>
            <asp:Button ID="btnEntrar" runat="server" Text="Entrar" class="mui-btn mui-btn--primary" OnClick="btnEntrar_Click"/>
       
        </form> 
        </center>
     </div>
</body>
</html>
