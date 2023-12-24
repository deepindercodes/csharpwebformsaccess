using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class view : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Int32 id = Convert.ToInt32(Request["id"]);

        DbConn objMDB = new DbConn();

        OleDbConnection objdbconn = new OleDbConnection(objMDB.DbConnection());

        OleDbDataAdapter objda = new OleDbDataAdapter("SELECT * FROM tblarticles WHERE id=" + id + "", objdbconn);

        DataTable objdt = new DataTable();

        objda.Fill(objdt);

        litarticletitle.Text = objdt.Rows[0]["articletitle"].ToString();
        litarticleauthor.Text = objdt.Rows[0]["articleauthor"].ToString();
        litarticlebody.Text = objdt.Rows[0]["articlebody"].ToString();
        litarticlecreatedonutc.Text = objdt.Rows[0]["createdonUTC"].ToString();

        if (objdt.Rows[0]["articleimage"].ToString()!="")
        {
            divimage.Visible = true;
            imgarticle.ImageUrl = objdt.Rows[0]["articleimage"].ToString();
        }

        Page.Title = litarticletitle.Text;
    }
}