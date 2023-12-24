using System;
using System.Data;
using System.Data.OleDb;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DbConn objMDB = new DbConn();

            OleDbConnection objdbconn = new OleDbConnection(objMDB.DbConnection());

            OleDbDataAdapter objda = new OleDbDataAdapter("SELECT * FROM tblarticles WHERE status='E' ORDER BY id", objdbconn);

            DataTable objdt = new DataTable();

            objda.Fill(objdt);

            if(objdt.Rows.Count>0)
            {
                reparticles.DataSource = objdt;
                reparticles.DataBind();
            }

        }
    }
}