using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{

    juegos Juego = new juegos();
    List<juegos> Juegos = new List<juegos>();
    jornadas jornada = new jornadas();
    List<jornadas> Jornadas = new List<jornadas>();  
    respuestas respuesta = new respuestas();
    List<respuestas> Respuestas = new List<respuestas>();
    
    protected void Page_Load(object sender, EventArgs e)
    {

        HttpCookie cogeCookie = Request.Cookies.Get("Usuario");
        HttpCookie addCookie = new HttpCookie("Usuario", "NO_USER");
        if (cogeCookie == null)
        {
            Response.Cookies.Add(addCookie);
            cogeCookie = addCookie;
            Response.Redirect("Login.aspx");
        }
        else
        {
            Response.Cookies.Set(cogeCookie);
            if (cogeCookie.Value.ToString() == "NO_USER")
            {
                Response.Redirect("Login.aspx");
            }
     


            lblUsuario.InnerText =  cogeCookie.Value.ToString();

            //DataTable u = Conexion.SqlExecute("select * from  ")

            if (IsPostBack)
            {

            }
            else
            {
          
              //  mGridLlenarQ();
            }

            //mGridEnviadaQ();
            mGridEnJuegoQ();
            mGridAcumuladoQ();
        }










     
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        HttpCookie cogeCookie = Request.Cookies.Get("Usuario");
        HttpCookie addCookie = new HttpCookie("Usuario", "NO_USER");
        if (cogeCookie == null)
        {
            Response.Cookies.Add(addCookie);
            cogeCookie = addCookie;
            Response.Redirect("Login.aspx");
        }
        else
        {
            Response.Cookies.Set(cogeCookie);
            if (cogeCookie.Value.ToString() == "NO_USER")
            {
                Response.Redirect("Login.aspx");
            }

            MiQuieniela();
        }
    }

        void InicializarDatos()
    {

        string q = "<li><button class='mui-btn'>Jornada 1</button></li>";
        ListaJornadas.InnerHtml = q;

    }
    void MiQuieniela(string CveTorneo ="A19",int CveJornada =0)
    {
        Juego = new juegos(CveTorneo);
        Juegos = new List<juegos>();
        jornada = new jornadas(CveTorneo);
        Jornadas = new List<jornadas>();  ;
        respuesta = new respuestas();
        Respuestas = new List<respuestas>(); ;
        List<juegos> _Juegos = new List<juegos>();
        List<jornadas> _Jornadas = new List<jornadas>();
        List<respuestas> _Respuestas = new List<respuestas>();


        HttpCookie _user = Request.Cookies.Get("Usuario");

        bool captura = false;
        bool capturada = false;
        string qhtml = "";


        respuesta = new respuestas(CveTorneo,0,_user.Value.ToString(),0);
        Respuestas = respuesta.GetRespuestas();
        Jornadas = jornada.GetJornadas();
        Juegos = Juego.GetJuegos();

        int qselected = 0;
        foreach (jornadas jor in Jornadas)
        {


            if (DateTime.Now.AddHours(1.0) >= jor.jor_ini_captura && DateTime.Now.AddHours(1.0) <= jor.jor_fin_captura)
             captura = true; 
            else
            captura = false;
            //Titjornadas
            //ListaJornadas
            _Juegos = Juegos.FindAll(x => x.jue_jornada == jor.jor_clave).ToList<juegos>();
            _Respuestas = Respuestas.FindAll(x => x.res_jornada == jor.jor_clave).ToList<respuestas>();
            if (_Respuestas.Count > 0)
                capturada = true;
            else
                capturada = false;

            if (DateTime.Now.AddHours(1.0) >= jor.jor_inicia && DateTime.Now.AddHours(1.0) <= jor.jor_fin)
                jornada = jor;




            qhtml =  qhtml + "<li><asp:Button id='J"+ jor.jor_clave + "' class='mui-btn' OnClientClick=\"llamadoclickjornada('" + jor.jor_clave + "')\"   />Jornada " + jor.jor_clave + " (" + ((capturada) ? "Enviada" : "No enviada") + ")</li>";
            //qhtml = "<li><asp:Button id=\"J1\"    runat=\"server\" class='mui-btn'  />Jornada 1 (no enviada) </li>";

            if (jornada.jor_clave == 0)
                TitJornada.InnerText = " No hay quiniela disponible";

            if (jornada.jor_clave != 0 &&  captura)
            {
                TitJornada.InnerText = "Jornada " + jornada.jor_clave.ToString() + "  (No enviada)";
                JornadaPLlenar(_Juegos);
            }
            if (jornada.jor_clave != 0 && capturada)
            {
                TitJornada.InnerText = "Jornada " + jornada.jor_clave.ToString() + "  (Enviada)";
                JornadaLlena(_Respuestas, _Juegos);
            }


        }
        ListaJornadas.InnerHtml = qhtml;
       
        /*

                      <tr>	   
                        <td><center>1</center></td>
                        <td><center><img src='img/NECAXA.png'/>
                            <br /> NECAXA
                            <br />
                            <div class='mui-select' >
                                   <select  runat='server' style='max-width:100px;'  >
                                        <option>0</option>
                                        <option>1</option>
                                        <option>2</option>
                                  </select>
                              </div>
                            </center></td>
                         <td>

                            </td>

                              <td>VS</td>
                             <td><center><img src='img/BRAVOS.png'/>
                                 <br />BRAVOS
                                 <br />
                                 <div class='mui-select' >
                                   <select  runat='server' style='max-width:100px;''  >
                                        <option>0</option>
                                        <option>1</option>
                                        <option>2</option>
                                  </select>
                              </div>

                                 </center></td>
                    </tr>
         
         */
    }
    void JornadaLlena(List<respuestas> rRespuestas, List<juegos> jJuegos)
    {
        string t = "";
        string qhtml = $@"
		<table class='mui-table'>
                <thead>
		        <tr>
                          
			              <th colspan='5'><center>Fecha hora envío: { rRespuestas.FirstOrDefault().res_envio.ToString() } </center></th>
			              
			        </tr>
			        <tr>
                          <th style='width:5px'></th>
			              <th colspan='2'><center>Local</center></th>
			              <th colspan='2'><center>Visitante</center></th>
			        </tr>
		      </thead>
           <tbody> 
                        ";
        foreach(respuestas r in rRespuestas)
        {
            juegos juego = jJuegos.Find(x =>  x.jue_clave == r.res_juego );
            qhtml = qhtml + $@"

                     <tr>	   
                        <td><center>{ juego.jue_clave }</center></td>
                        <td><center><img src='img/{ juego.jue_local }.png'/>
                            <br /> { juego.jue_local }
                            <br />{r.res_gol_local.ToString() }
                            </center></td>
                         <td colspan='2'>VS</td>                            
                             <td><center><img src='img/{ juego.jue_visita }.png'/>
                                 <br />{ juego.jue_visita }
                                 <br />{r.res_gol_visita.ToString() }
                              </div>

                                 </center></td>
                    </tr>
        ";

        }
        qhtml = qhtml + $@" </tbody> </table>";

        LLenarQ.InnerHtml = qhtml;
        btnGuardar.Visible = false;
    }
    void JornadaPLlenar(List<juegos> jJuegos)
    {
        string t = "";

        
        string head = $@"

                <table class='mui-table'>
                <thead>
		        <tr>
                          
			              <th colspan='5'><center>Fecha hora captura: de  { jornada.jor_ini_captura } a { jornada.jor_fin_captura } </center></th>
			              
			        </tr>
			        <tr>
                          <th style='width:5px'></th>
			              <th colspan='2'><center>Local</center></th>
			              <th colspan='2'><center>Visitante</center></th>
			        </tr>
		      </thead>
           <tbody> 

        

        
            
        ";


        string body = $@" ";

        foreach(juegos j in jJuegos)
        {
            body = body + $@"

                   <tr>	   
                        <td><center>{j.jue_clave }</center></td>
                        <td><center><img src='img/{ j.jue_local }.png'/>
                            <br /> { j.jue_local }
                            <br />
                            <div class='mui-select' >
                                   <select  runat='server' name='L{ j.jue_clave}' style='max-width:100px;'  >
                                    { opcionesGoles() }
                                  </select>
                              </div>
                            </center></td>
                         <td>

                            </td>

                              <td>VS</td>
                             <td><center><img src='img/{ j.jue_visita }.png'/>
                                 <br />{ j.jue_visita }
                                 <br />
                                 <div class='mui-select' >
                                   
                                   <select  runat='server' name='V{ j.jue_clave}' style='max-width:100px;'  >
                                        { opcionesGoles() }
                                    </select>
                              </div>

                                 </center></td>
                    </tr>        ";

        }

        string foot = $@"
                </tbody> </table>
        ";
        LLenarQ.InnerHtml = head+body+foot;



    }
    string JornadaPendiente()
    {
        return "";
    }
    string opcionesGoles()
    {
        return $@"
                                        <option>0</option>
                                        <option>1</option>
                                        <option>2</option>
                                        <option>3</option>
                                        <option>4</option>
                                        <option>5</option>
                                        <option>6</option>
                                        <option>7</option>
                                        <option>8</option>
                                        <option>9</option>
                                        <option>10</option>
                                        <option>11</option>
                                        <option>12</option>
                                        <option>13</option>
                                        <option>14</option>
                                        <option>15</option>
                                        <option>16</option>
                                        <option>17</option>
                                        <option>18</option>
                                        <option>19</option>
                                        <option>20</option>
                                        <option>21</option>
                                        <option>22</option>
                                        <option>23</option>
                                        <option>24</option>
                                        <option>25</option>
                                        <option>26</option>    
                                        <option>27</option>    
                                        <option>28</option>    
                                        <option>29</option>    
                                        <option>30</option>    
                                        <option>31</option>    
                                        <option>32</option>    
                                        <option>33</option>    
                                        <option>34</option>    
                                        <option>35</option>    
                                        <option>36</option>    
                                        <option>37</option>    
                                        <option>38</option>    
                                        <option>39</option>    
                                        <option>40</option>    
                                        <option>41</option>    
                                        <option>42</option>    
                                        <option>43</option>    
                                        <option>44</option>    
                                        <option>45</option>    
                                        <option>46</option>    
                                        <option>47</option>    
                                        <option>48</option>    
                                        <option>49</option>    
                                        <option>50</option>
            ";
    }
    void mGridLlenarQ()
    {
        DataTable e = Conexion.SqlExecute("select  * from juegos where jue_torneo = 'A19' and jue_jornada ='1' order by jue_clave asc ");
        String q = $@"
        
		<table class='mui-table'>
                <thead>
			        <tr>
                          <th style='width:5px'></th>
			              <th colspan='2'><center>Local</center></th>
			              <th colspan='2'><center>Visitante</center></th>
			        </tr>
		      </thead>

           <tbody> 
		   ";

        foreach(DataRow r in e.Rows)
        {

            /*
            <tr>	   
                <td><center>1</center></td>
                <td><center>NECAXA</center></td>
                 <td>
                            <div class='mui-select' >
                                   <select  runat='server'>
                                        <option>0</option>
                                        <option>1</option>
                                        <option>2</option>
                                  </select>
                              </div>
                    </td>

                      <td>
                            <div class='mui-select' >
                                   <select  runat='server'>
                                        <option>0</option>
                                        <option>1</option>
                                        <option>2</option>
                                  </select>
                              </div>
                    </td>
                     <td><center>BRAVOS</center></td>
            </tr>
            <tr>	   
                <td></td>
                <td><div class='mui-select' >
                                   <select  runat='server'>
                                        <option>0</option>
                                        <option>1</option>
                                        <option>2</option>
                                  </select>
                              </div></td>
                 <td>

                    </td>

                      <td>
      
                    </td>
                     <td>                      <div class='mui-select' >
                                   <select  runat='server'>
                                        <option>0</option>
                                        <option>1</option>
                                        <option>2</option>
                                  </select>
                              </div></td>
            </tr>
              */
            q = q + $@"
                    <tr>	            
                        <td><center>{  r["jue_clave"].ToString() }</center></td>
			            <td><center>{  r["jue_local"].ToString() }</center></td>
		                <td>
                            <div class='mui-select' >
                                   <select id ='L{r["jue_clave"].ToString() }' name='L{ r["jue_clave"].ToString() }' runat='server'>
                                        <option>0</option>
                                        <option>1</option>
                                        <option>2</option>
                                        <option>3</option>
                                        <option>4</option>
                                        <option>5</option>
                                        <option>6</option>
                                        <option>7</option>
                                        <option>8</option>
                                        <option>9</option>
                                        <option>10</option>
                                        <option>11</option>
                                        <option>12</option>
                                        <option>13</option>
                                        <option>14</option>
                                        <option>15</option>
                                        <option>16</option>
                                        <option>17</option>
                                        <option>18</option>
                                        <option>19</option>
                                        <option>20</option>
                                        <option>21</option>
                                        <option>22</option>
                                        <option>23</option>
                                        <option>24</option>
                                        <option>25</option>
                                        <option>26</option>    
                                        <option>27</option>    
                                        <option>28</option>    
                                        <option>29</option>    
                                        <option>30</option>    
                                        <option>31</option>    
                                        <option>32</option>    
                                        <option>33</option>    
                                        <option>34</option>    
                                        <option>35</option>    
                                        <option>36</option>    
                                        <option>37</option>    
                                        <option>38</option>    
                                        <option>39</option>    
                                        <option>40</option>    
                                        <option>41</option>    
                                        <option>42</option>    
                                        <option>43</option>    
                                        <option>44</option>    
                                        <option>45</option>    
                                        <option>46</option>    
                                        <option>47</option>    
                                        <option>48</option>    
                                        <option>49</option>    
                                        <option>50</option>
                                    </select>
                              </div>
                    </td>
                    <td><div class='mui-select' >
			                        <select id ='V{ r["jue_clave"].ToString() }' name='V{ r["jue_clave"].ToString() }'  runat='server'>
                                        <option>0</option>
                                        <option>1</option>
                                        <option>2</option>
                                        <option>3</option>
                                        <option>4</option>
                                        <option>5</option>
                                        <option>6</option>
                                        <option>7</option>
                                        <option>8</option>
                                        <option>9</option>
                                        <option>10</option>
                                        <option>11</option>
                                        <option>12</option>
                                        <option>13</option>
                                        <option>14</option>
                                        <option>15</option>
                                        <option>16</option>
                                        <option>17</option>
                                        <option>18</option>
                                        <option>19</option>
                                        <option>20</option>
                                        <option>21</option>
                                        <option>22</option>
                                        <option>23</option>
                                        <option>24</option>
                                        <option>25</option>
                                        <option>26</option>
                                        <option>27</option>
                                        <option>28</option>
                                        <option>29</option>
                                        <option>30</option>
                                        <option>31</option>
                                        <option>32</option>
                                        <option>33</option>
                                        <option>34</option>
                                        <option>35</option>
                                        <option>36</option>
                                        <option>37</option>
                                        <option>38</option>
                                        <option>39</option>
                                        <option>40</option>
                                        <option>41</option>
                                        <option>42</option>
                                        <option>43</option>
                                        <option>44</option>
                                        <option>45</option>
                                        <option>46</option>
                                        <option>47</option>
                                        <option>48</option>
                                        <option>49</option>
                                        <option>50</option>

			                        </select>
			                    </div>
			                 </td>
			              <td>
                          <center>{ r["jue_visita"].ToString() }</center>
                          </td>
			</tr>
                        ";
        }
        q = q + "</tbody></table>";

        LLenarQ.InnerHtml = q;

           
    }

    void mGridEnviadaQ()
    {
        HttpCookie _user = Request.Cookies.Get("Usuario");

        DataTable e = Conexion.SqlExecute("SELECT res_torneo,res_jornada,res_juego,jue_local,res_gol_local,res_gol_visita,jue_visita,res_envio,res_usuario FROM respuestas,juegos"
                                            +" where res_torneo = jue_torneo"
                                            +" and res_jornada = jue_jornada"
                                            +" and res_juego = jue_clave and res_torneo = 'A19' AND RES_JORNADA='1' AND RES_USUARIO = '" +_user.Value.ToString() + "' order by res_juego asc ");


        if(e.Rows.Count > 0)
        {
            String q = $@"
		    <table class='mui-table'>
                    <thead>
			            <tr>
                              <th style='width:5px'></th>
			                  <th colspan='2'><center>Local</center></th>
			                  <th colspan='2'><center>Visitante</center></th>
			            </tr>
		          </thead>

               <tbody> 
		   ";

            foreach (DataRow r in e.Rows)
            {
                q = q + $@"
                    <tr>	            
                        <td><center>{  r["res_juego"].ToString() }</center></td>
			            <td><center>{  r["jue_local"].ToString() }</center></td>
		                <td>{  r["res_gol_local"].ToString() }</td>
                        <td>{  r["res_gol_visita"].ToString() }</td>
			            <td> <center>{ r["jue_visita"].ToString() }</center>
                          </td>
			        </tr>
                        ";
            }
            q = q + "</tbody></table>";

            LLenarQ.InnerHtml = q;
            btnGuardar.Visible = false;

        }




    }

    void mGridEnJuegoQ()
    {
        DataTable d = Conexion.SqlExecute("select  * from vwUsuarioXJornada where jornada='2'  order by juego asc, envio asc ");
        string JuegoTmp = "";
        string head = "";
        string body = "";
        string foot = "";
        string final = "";
        String q = "<h1>Jornada 2</h1> ";
        foreach (DataRow r in d.Rows)
        {
            if (r["juego"].ToString() != JuegoTmp)
            {
                final = final + head + body + foot;
                head = "";
                body = "";
                foot = "";
                head = $@" 
		                    <table class='mui-table'>
                                <thead>
			                        <tr>
			                              <th><center>{ r["local"].ToString() }</center></th>
                                            <th>{ r["RL"].ToString() }</th>
                                            <th>-</th>
                                            <th>{ r["RV"].ToString() }</th>
			                              <th><center>{ r["visita"].ToString() }</center></th>
			                        </tr>
		                      </thead>
                           <tbody> 
                            <tr>	            
                                <td colspan='4'>{  r["estadio"].ToString() + " " + r["fecha"].ToString() }</td>
			                    <td> <center>{ r["estatus"].ToString() }</center></td>
			                </tr>   
                            <tr>	            
                                <td> <center>Usuario</center></td>
                                <td> <center></center></td>
                                <td> <center></center></td>
                                <td> <center></center></td>
                                <td> <center>Puntos</center></td>
			                </tr>   




                   ";
                
                foot =  "</tbody></table> <br/>";
                JuegoTmp = r["juego"].ToString();

            }

            body = body + $@"

                       <tr>	            
                                <td> { r["usuario"].ToString() }</td>
                                <td> <center>{ r["QL"].ToString() }</center></td>
                                <td> <center>-</center></td>
                                <td> <center>{ r["QV"].ToString() }</center></td>
                                <td> <center>{ r["puntos"].ToString() }</center></td>
			                </tr>   
                  
                ";

        }
        final =  final + head + body + foot ;
        EnJuegoQ.InnerHtml = final;
       // ScriptManager.RegisterStartupScript(this, GetType(), "llamada js", "iniciarswipe();", true);
    }

    void mGridAcumuladoQ()
    {
        string q = "select * from vwPuntajeXQuiniela where jornada='2' order by posicion asc";
        DataTable d = Conexion.SqlExecute(q);
        string final = "";



        final = $@"
		                    <table class='mui-table'>
                                <thead>
			                        <tr>
			                              <th>No.</th>
                                            <th>Usuario</th>
                                            <th>Pts.</th>
                                            <th>Dif.</th>
			                              <th>Envio</th>
			                        </tr>
		                      </thead>
                           <tbody> ";
        foreach (DataRow r in d.Rows)
        {

 
                final = final + $@"
                       <tr>	            
                                <td><center>{ r["posicion"].ToString() }</center></td>
                                <td>{ r["usuario"].ToString() }</td>
                                <td>{ r["puntos"].ToString() }</td>
                                <td>{ r["diferencia"].ToString() }</td>
                                <td>{ r["envio"].ToString() }</td>
			           </tr>   

                   ";
           
        }

        final = final + "</tbody></table>";
        GeneralQ.InnerHtml = final;


    }



    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        HttpCookie _user = Request.Cookies.Get("Usuario");

        DataTable d = Conexion.SqlExecute("select  * from juegos where jue_torneo = 'A19' and jue_jornada ='1' order by jue_clave asc ");
        string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string inserts = "";
        foreach (DataRow r in d.Rows)
        {
            inserts = inserts + " insert into respuestas select 'A19','2','"+ r["jue_clave"].ToString() + "','"+ _user.Value.ToString() + "','" + Request.Form["L" + r["jue_clave"].ToString()] + "','" + Request.Form["V" + r["jue_clave"].ToString()] + "','"+fecha+"';  ";

        }
        Conexion.SqlExecute(inserts);
        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Quiniela Enviada');", true);

        MiQuieniela();
    }
    /*
    protected void Jornada_Click(object sender, EventArgs e)
    {
        
        Button b = (Button)sender;
        string Jornada = b.ID.Replace("J","");


    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    */


    protected void btnJornada_Click(object sender, EventArgs e)
    {
        Button b = (Button)sender;
        string Jornada = b.Text;
        Jornada = Jornada + "k";
    }
}