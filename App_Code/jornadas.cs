using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for jornadas
/// </summary>
public class jornadas
{
    public string jor_torneo;
    public int jor_clave;
    public DateTime jor_inicia;
    public DateTime jor_fin;
    public DateTime jor_ini_captura;
    public DateTime jor_fin_captura;
    public jornadas()
    {

        jor_torneo = "";
        jor_clave = 0;
        jor_inicia = DateTime.Now;
        jor_fin = DateTime.Now;
        jor_ini_captura = DateTime.Now;
        jor_fin_captura = DateTime.Now;
        //
        // TODO: Add constructor logic here
        //
    }
    public jornadas(string CvTorneo)
    {

        jor_torneo = CvTorneo;
        jor_clave = 0;
        jor_inicia = DateTime.Now;
        jor_fin = DateTime.Now;
        jor_ini_captura = DateTime.Now;
        jor_fin_captura = DateTime.Now;
    }
    public jornadas(string CvTorneo,int CvJornada)
    {

        jor_torneo = CvTorneo;
        jor_clave = CvJornada;
        jor_inicia = DateTime.Now;
        jor_fin = DateTime.Now;
        jor_ini_captura = DateTime.Now;
        jor_fin_captura = DateTime.Now;

    }
   public  List<jornadas> GetJornadas()
    {
        DataTable jor = Conexion.SqlExecute("select * from jornadas where jor_torneo = '" + jor_torneo + "' ");
        List<jornadas> rJornadas = new List<jornadas>();
        foreach (DataRow dr in jor.Rows)
        {
            jornadas j = new jornadas();
            j.jor_clave = (int)dr["jor_clave"];
            j.jor_torneo = this.jor_torneo;
            j.jor_inicia = (DateTime) dr["jor_inicia"];
            j.jor_fin = (DateTime)dr["jor_fin"];
            j.jor_ini_captura = (DateTime)dr["jor_ini_captura"];
            j.jor_fin_captura = (DateTime)dr["jor_fin_captura"];
            rJornadas.Add(j);        }


        return rJornadas;
    }

    public jornadas GetJornada(string cvTorneo,int CvJornada)
    {
        DataTable jor = Conexion.SqlExecute("select * from jornadas where jor_torneo = '" + jor_torneo + "'  and jor_Clave='"+CvJornada.ToString()+"' ");
        jornadas j = new jornadas();
        foreach (DataRow dr in jor.Rows)
        {
           
            j.jor_clave = (int)dr["jor_clave"];
            j.jor_torneo = cvTorneo;
            j.jor_inicia = (DateTime)dr["jor_inicia"];
            j.jor_fin = (DateTime)dr["jor_fin"];
            j.jor_ini_captura = (DateTime)dr["jor_ini_captura"];
            j.jor_fin_captura = (DateTime)dr["jor_fin_captura"];
            
        }


        return j;
    }


}