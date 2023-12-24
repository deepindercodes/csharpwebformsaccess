using System;
using System.Data;
using System.Data.OleDb;

public partial class editarticle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Int32 id = Convert.ToInt32(Request["id"]);

            DbConn objMDB = new DbConn();

            OleDbConnection objdbconn = new OleDbConnection(objMDB.DbConnection());

            OleDbDataAdapter objda = new OleDbDataAdapter("SELECT * FROM tblarticles WHERE id=" + id + "", objdbconn);

            DataTable objdt = new DataTable();

            objda.Fill(objdt);

            txtarticletitle.Text = objdt.Rows[0]["articletitle"].ToString();
            txtarticleauthor.Text = objdt.Rows[0]["articleauthor"].ToString();
            txtarticlebody.Text = objdt.Rows[0]["articlebody"].ToString();
            hdnarticleimage.Value = objdt.Rows[0]["articleimage"].ToString();

        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Int32 id = Convert.ToInt32(Request["id"]);

        string articletitle = txtarticletitle.Text;
        string articleauthor = txtarticleauthor.Text;
        string articlebody = txtarticlebody.Text;
        string articleimage = hdnarticleimage.Value;

        DbConn objMDB = new DbConn();

        OleDbConnection objdbconn = new OleDbConnection(objMDB.DbConnection());

        objdbconn.Open();

        OleDbCommand comm = new OleDbCommand("UPDATE tblarticles SET articletitle='" + articletitle + "',articleauthor='" + articleauthor + "',articlebody='" + articlebody + "',articleimage='" + articleimage + "',modifiedonUTC='" + DateTime.UtcNow.ToString() + "' WHERE id=" + id + "", objdbconn);
        comm.ExecuteNonQuery();

        objdbconn.Close();

        Response.Write("<script type='text/javascript'>parent.ArticleEdited();</script>");
        Response.End();
    }
}