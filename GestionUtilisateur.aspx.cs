using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class GestionUtilisateur : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    string chaine = "Data source = TUTU; initial catalog = clinique; uid = bunso; pwd = Guy1021999; integrated Security=true";
    SqlConnection n = new SqlConnection(chaine);
    n.Open();

    string requete = "";
    if (!IsPostBack)
    {
        requete = "select idUtilisateur from utilisateur";
        SqlCommand com = new SqlCommand(requete, n);
        SqlDataReader dr = com.ExecuteReader();
        DropDownList1.Items.Clear();


        while (dr.Read())
        {
            DropDownList1.Items.Add(dr.GetInt32(0).ToString());
        }
        n.Close();

    }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int a = Int32.Parse(DropDownList1.SelectedItem.ToString());
        string chaine = "Data source = TUTU; initial catalog = clinique; uid = bunso; pwd = Guy1021999; integrated Security=true";
        SqlConnection n = new SqlConnection(chaine);

        n.Open();
        string requete = "";
        requete = "update utilisateur set profile = '" + TextBox3.Text + "', password = '" + TextBox4.Text + "' where idUtilisateur = '" + a + "'";
        SqlCommand com = new SqlCommand(requete, n);
        com.ExecuteNonQuery();
        n.Close();

        n.Open();
        requete = "update personne set nom = '" + TextBox1.Text + "', prenom = '" + TextBox2.Text + "' where (select personneUser from utilisateur where idUtilisateur = '" + a + "') = personne.idpersonne";
        SqlCommand com1 = new SqlCommand(requete, n);
        com1.ExecuteNonQuery();
        n.Close();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int a = Int32.Parse(DropDownList1.SelectedItem.ToString());
        string chaine = "Data source = TUTU; initial catalog = clinique; uid = bunso; pwd = Guy1021999; integrated Security=true";
        SqlConnection n = new SqlConnection(chaine);
        n.Open();

        string requete = "";
        requete = "select password, profile, nom, prenom from Utilisateur, Personne where utilisateur.idUtilisateur="+a+" and personne.idPersonne =utilisateur.personneUser";
        SqlCommand com = new SqlCommand(requete, n);

        SqlDataReader dr = com.ExecuteReader();
        //DropDownList1.Items.Clear();
        if (dr.Read())
        {
            TextBox1.Text = dr.GetString(2);
            TextBox2.Text = dr.GetString(3);
            TextBox3.Text = dr.GetString(1);
            TextBox4.Text = dr.GetString(0);
        }
        n.Close();
    }
}