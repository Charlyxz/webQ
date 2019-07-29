using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for juegos
/// </summary>
public class juegos
{
        string  jue_torneo;
        public int jue_jornada;
        public int jue_clave;
        public string jue_local;
        public string jue_visita;
        public string jue_estadio;
        public decimal jue_porc_local;
        public decimal jue_porc_visita;
        public decimal jue_poc_empate;
        public int jue_gol_local;
        public int jue_gol_visita;
        public DateTime jue_fecha;
        public string jue_status;
    public juegos()
    {

        jue_torneo = "";
        jue_jornada = 0;
        jue_clave = 0;
        jue_local = "";
        jue_visita = "";
        jue_estadio = "";
        jue_porc_local = 0;
        jue_porc_visita = 0;
        jue_poc_empate = 0;
        jue_gol_local = 0;
        jue_gol_visita = 0;
        jue_fecha = DateTime.Now;
        jue_status = "";


    }
    public juegos(string CveTorneo="",int CveJornada=0)
    {

        jue_torneo = CveTorneo;
        jue_jornada = CveJornada;
        jue_clave = 0;
        jue_local = "";
        jue_visita = "";
        jue_estadio = "";
        jue_porc_local = 0;
        jue_porc_visita = 0;
        jue_poc_empate = 0;
        jue_gol_local = 0;
        jue_gol_visita = 0;
        jue_fecha = DateTime.Now;
        jue_status = "";


    }
    public List<juegos> GetJuegos()
    {
        List<juegos> rJuegos = new List<juegos>();
        string query = "select * from juegos where jue_torneo = '" + this.jue_torneo + "'  ";
        if (jue_jornada != 0)
            query = query + "  and jue_jornada= '" + this.jue_jornada.ToString() + "' "; 
        if (jue_clave != 0)
            query = query + " and jue_clave = '" + this.jue_clave.ToString() + "' ";

        DataTable res = Conexion.SqlExecute(query);
        foreach (DataRow dr in res.Rows)
        {
            juegos j = new juegos();
            j.jue_torneo = dr["jue_torneo"].ToString();
            j.jue_jornada = (int)dr["jue_jornada"];
            j.jue_clave = (int)dr["jue_clave"];
            j.jue_local = dr["jue_local"].ToString();
            j.jue_visita = dr["jue_visita"].ToString();
            j.jue_estadio = dr["jue_estadio"].ToString();
            j.jue_porc_local = (decimal)dr["jue_porc_local"];
            j.jue_porc_visita = (decimal)dr["jue_porc_visita"];
            j.jue_poc_empate = (decimal)dr["jue_poc_empate"];
            j.jue_gol_local = (int)dr["jue_gol_local"];
            j.jue_gol_visita = (int)dr["jue_gol_visita"];
            j.jue_fecha = DateTime.Now;
            j.jue_status = dr["jue_status"].ToString();
            rJuegos.Add(j);
        }

        return rJuegos;
    }




}