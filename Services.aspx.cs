using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class Services : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string chaine = "Data source = TUTU; initial catalog = clinique; uid = bunso; pwd = Guy1021999; integrated Security=true";
        SqlConnection n = new SqlConnection(chaine);
        n.Open();
        string requete ="insert into Services(nomServices) values ('"+TextBox1.Text+"')"; 
         
         SqlCommand perAdd = new SqlCommand(requete, n);
         perAdd.ExecuteNonQuery();
         Response.Write("enregistrer service");
         n.Close();
         n.Open();
    }
}