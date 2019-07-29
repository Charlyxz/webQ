<%@ Page Title="Inicio" Language="C#"  AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

	<title>Quiniela
	</title>
	<head >
	
	    <meta charset="utf-8">
		<meta http-equiv="X-UA-Compatible" content="IE=edge">
		<meta name="viewport" content="width=device-width, initial-scale=1">
	<script src="js/q.js"></script>
        <script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
		<link href="css/mui.min.css" rel="stylesheet" type="text/css" />
		<script src="js/mui.min.js"></script>
	

	</head>

	<body>
        <form id="frmRegistro" runat="server" class="mui-form" >
         
        <div class="mui-appbar">
            <!--<div class="mui-container" >
                    
            </div> !-->

      <table width="100%">
                <tr style="vertical-align:middle;">
                  <td class="mui--appbar-height"><h2>Quiniela sin nombre</h2></td>
                  <td class="mui--appbar-height" align="right">  <div class="mui--text-light mui--text-title" id="lblUsuario" runat="server"></div></td>
                </tr>
  </table>

</div>
           <center>
            <div class="mui-container-fluid"  style="max-width: 800px; "> 
                <div class="mui-panel">
                        <ul class="mui-tabs__bar mui-tabs__bar--justified">
                            <li class="mui--is-active"><a data-mui-toggle="tab" data-mui-controls="pane-justified-1">Mi quiniela</a></li>
                            <li><a data-mui-toggle="tab" data-mui-controls="pane-justified-2">En juego</a></li>
                            <li><a data-mui-toggle="tab" data-mui-controls="pane-justified-3">General</a></li>
                        </ul>
                </div>
            </div>

            
            <div class="mui-tabs__pane mui--is-active" id="pane-justified-1" style="max-width: 800px;   "> 
             <div class='mui-container-fluid'>
                <div class="mui-dropdown">
                  <button class="mui-btn mui-btn--primary" data-mui-toggle="dropdown" id="TitJornada" runat="server">
                    Jornada 1 (no enviada )
                    <span class="mui-caret"></span>
                  </button>
                  <ul class="mui-dropdown__menu mui-dropdown__menu--right" id="ListaJornadas" runat="server">
                        <li><asp:Button id='J1' text="juego de prueba" runat='server'  class='mui-btn' style='width:100%;color:black;'  /></li>
             



                  </ul>
                </div>


                        <div class="mui-panel" id="LLenarQ" runat="server">

                        </div>
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar respuestas" class="mui-btn mui-btn--primary" OnClick="btnGuardar_Click" />
                 <asp:Button id='btnJornada' text="" visible="false" runat='server' OnClick="btnJornada_Click" OnClientClick="llamadoclickjornada('1')" />
            </div>
  
            </div>
          

            <div class="mui-tabs__pane" id="pane-justified-2">
                    <div class='mui-container' >


                        <div class="mui-panel" id="EnJuegoQ" runat="server">

                        </div>
                    </div>
            </div>
            <div class="mui-tabs__pane" id="pane-justified-3">
            
            <div class='mui-container'>
                  <div class="mui-panel" id="GeneralQ" runat="server"></div>
            </div>
            
            
            
            </div>
               </center>



     

            

         </form>
        
	</body>
</html>