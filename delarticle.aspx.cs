using System;
using System.Data.OleDb;

public partial class delarticle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Int32 id = Convert.ToInt32(Request["id"]);

        DbConn objMDB = new DbConn();

        OleDbConnection objdbconn = new OleDbConnection(objMDB.DbConnection());

        objdbconn.Open();

        OleDbCommand comm = new OleDbCommand("DELETE FROM tblarticles WHERE id=" + id + "", objdbconn);

        comm.ExecuteNonQuery();

        objdbconn.Close();

        Response.Redirect("/");
    }
}