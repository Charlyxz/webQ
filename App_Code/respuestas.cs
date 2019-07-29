using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for respuestas
/// </summary>
public class respuestas
{ 
    string res_torneo;
    public int res_jornada;
    public int res_juego;
    string res_usuario;
    public int res_gol_local;
    public int res_gol_visita;
    public DateTime res_envio;
    public respuestas()
    {
        res_torneo = "";
        res_jornada = 0;
        res_juego = 0;
        res_usuario = "";
        res_gol_local = 0;
        res_gol_visita = 0;
        res_envio = DateTime.Now;
    }

    public respuestas(string CvTorneo, int CvJornada = 0,string CvUsuario = "", int Cvjuego = 0)
    {
        res_torneo = CvTorneo;
        res_jornada = CvJornada;
        res_juego = Cvjuego;
        res_usuario = CvUsuario;
        res_gol_local = 0;
        res_gol_visita = 0;
        res_envio = DateTime.Now;
    }
    public List<respuestas> GetRespuestas()
    {
        string query = "select * from respuestas where res_torneo = '" + this.res_torneo + "'   ";

        if (this.res_jornada != 0)
            query = query + " and res_jornada= '" + this.res_jornada.ToString() + "'  ";
        if (this.res_juego != 0)
            query = query + " and res_juego = '"+ this.res_juego.ToString()+"' ";
        if (this.res_usuario != "")
            query = query + " and res_usuario = '" + this.res_usuario + "' ";

        List<respuestas> rRespuestas = new List<respuestas>();

        DataTable res = Conexion.SqlExecute(query);

        foreach(DataRow dr in res.Rows)
        {
            respuestas r = new respuestas();
            r.res_torneo = dr["res_torneo"].ToString();
            r.res_jornada = (int)dr["res_jornada"];
            r.res_juego = (int)dr["res_juego"];
            r.res_usuario = dr["res_usuario"].ToString();
            r.res_gol_local = (int)dr["res_gol_local"];
            r.res_gol_visita = (int)dr["res_gol_visita"];
            r.res_envio = (DateTime)dr["res_envio"];
            rRespuestas.Add(r);

        }
       
        return rRespuestas;
    }
    public void SetRespuestas(List<respuestas> res)
    {
        string query = "delete respuestas where res_torneo = '" + this.res_torneo + "' and res_jornada= '" + this.res_jornada + "'   ";
        if (this.res_usuario != "")
            query = query + " and res_usuario = '" + this.res_usuario + "' ";
        query = query + ";";





        string query2 = "";
        foreach (respuestas dr in res)
        {
            query2 = "insert into respuestas select ";
            query2 = query2+"'" + res_torneo+ "'";
            query2 = query2+",'"+ res_jornada + "'";
            query2 = query2+",'"+ res_juego.ToString() + "'";
            query2 = query2+",'"+ res_usuario + "'";
            query2 = query2+",'"+ res_gol_local.ToString() + "'";
            query2 = query2+",'"+ res_gol_visita.ToString() + "'";
            query2 = query2+",'"+ res_envio.ToString("yyyy-MM-dd HH:mm:ss") + "'";

            query = query + query2;
        }
        Conexion.SqlExecute(query);
    }

}