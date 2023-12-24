using System;
using System.Data;
using System.Data.OleDb;

public partial class addnewarticle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        diverror.Visible = false;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string articletitle = txtarticletitle.Text;
        string articleauthor = txtarticleauthor.Text;
        string articlebody = txtarticlebody.Text;
        string articleimage = hdnarticleimage.Value;
        bool articleExists = false;

        DbConn objMDB = new DbConn();

        OleDbConnection objdbconn = new OleDbConnection(objMDB.DbConnection());

        OleDbDataAdapter objda = new OleDbDataAdapter("SELECT id FROM tblarticles WHERE articletitle=@articletitle", objdbconn);
        objda.SelectCommand.Parameters.Add(new OleDbParameter("@articletitle", articletitle));

        DataTable objdt = new DataTable();
        objda.Fill(objdt);

        if (objdt.Rows.Count > 0)
        {
            articleExists = true;
        }

        if (articleExists)
        {
            lblerror.Text = "Article Already Exists.";
            diverror.Visible = true;
        }
        else
        {
            objdbconn.Open();

            OleDbCommand comm = new OleDbCommand("INSERT INTO tblarticles (articletitle,articleauthor,articlebody,articleimage,status,createdonUTC) VALUES (@articletitle,@articleauthor,@articlebody,@articleimage,'E','" + DateTime.UtcNow.ToString() + "');", objdbconn);
            comm.Parameters.Add(new OleDbParameter("@articletitle", articletitle));
            comm.Parameters.Add(new OleDbParameter("@articleauthor", articleauthor));
            comm.Parameters.Add(new OleDbParameter("@articlebody", articlebody));
            comm.Parameters.Add(new OleDbParameter("@articleimage", articleimage));
            comm.ExecuteNonQuery();

            objdbconn.Close();

            Response.Write("<script type='text/javascript'>parent.newArticleAdded();</script>");
            Response.End();

        }

    }
}