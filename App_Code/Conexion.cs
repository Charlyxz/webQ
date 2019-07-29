using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for Conexion
/// </summary>
public class Conexion
{
    /*
    public static string dbStringConn = "";
    public static string dbUser = "SARHWS";
    public static string dbPass = "soporte_1";
    public static string dbServer = "CJUAREZ\\SQL2012";
    public static string dbName = "Quiniela";
    */

    
    public static string dbStringConn = "workstation id=Quiniela.mssql.somee.com;packet size=4096;user id=charlymx_SQLLogin_1;pwd=7ysbtbqsav;data source=Quiniela.mssql.somee.com;persist security info=False;initial catalog=Quiniela";
    public static string dbUser = "charlymx_SQLLogin_1";
    public static string dbPass = "7ysbtbqsav";
    public static string dbServer = "Quiniela.mssql.somee.com";
    public static string dbName = "Quiniela";

 
    public Conexion()
    {

        dbStringConn = $@" Server={dbServer};Database={dbName};User Id={dbUser}; Password={dbPass}; ";
    }
    public static DataTable SqlExecute(string q = "")
    {
        DataTable dt = new DataTable();
        try
        {
            //dbStringConn = $@" Server={dbServer};Database={dbName};User Id={dbUser}; Password={dbPass}; ";
            System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection(dbStringConn);
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(q, cn);
            cn.Open();
           
            da.Fill(dt);
            cn.Close();
        }
        catch (Exception e)
        {
            dt = new DataTable();
        }

        return dt;

    }

}