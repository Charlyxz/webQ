<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registro.aspx.cs" Inherits="Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registro</title>
    	<meta charset="utf-8">
		<meta http-equiv="X-UA-Compatible" content="IE=edge">
		<meta name="viewport" content="width=device-width, initial-scale=1">

		<link href="css/mui.min.css" rel="stylesheet" type="text/css" />
		<script src="js/mui.min.js"></script>
</head>
<body>
     <div class="mui-container">
      <div class="mui-panel">
        <h1>Quiniela PRSM</h1>
        
      </div>
    </div>
    <div class="mui-container">
        <form id="frmRegistro" runat="server" class="mui-form">
        <legend>Registrar Participante</legend>
          <div class="mui-textfield">
            <input type="text" placeholder="Usuario" id="us_usuario" runat="server" />
          </div>
          <div class="mui-textfield">
            <input type="password" placeholder="Password" id="us_password" runat="server" />
          </div>
            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" class="mui-btn mui-btn--primary" OnClick="btnRegistrar_Click"/>
          <div class="mui-radio">
            <label>
              <input type="radio" runat="server"
                     name="rbtAcepto"
                     id="rbtAcepto"
                     value="option1"
                      />
              Acepto los términos y condiciones
            </label>
          </div>
     <div class="mui-container">
          <div class="mui-panel">
            <h1>Términos y condiciones de la Quiniela “Apertura 2019”</h1>
        
                Cláusulas
                <br/>
                PRIMERA.- Definiciones, Cualquier duda será resuelta por Carlos Juarez, en lo sucesivo denominado el “DOF” o “AMO” o “el patrón” y los demás personas se denomirán "Los Pariticpantes"
                <br/>
                SEGUNDA.- De las controversias, cualquier controversia que se llegue a dar antes, durante y después de cada TORNEO, JUEGO o PREMIACION entre "los participantes",  “el patrón” será encargado de la mediación la cual constará de una votación, tanto los participantes como las partes involucradas tendrán el mismo derecho a ejercer su opinión. El tiempo de gracia para la resolución serán de 2 horas a partir, hayan o no emitido su voto todos los participantes.
                <br/>
                TERCERA.-  De los y premios, todo sigue igual al torneo anterior. 

          </div>
        </div>
       </form>
     </div>
</body>
</html>
