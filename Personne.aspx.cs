using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class Personne : System.Web.UI.Page
{
    public static string statut = ""; 
    protected void Page_Load(object sender, EventArgs e)
    {
       /* (IsPostBack)
        {
            DropDownList1.Items.Add("Medecin");
            DropDownList1.Items.Add("Patient");
            DropDownList1.Items.Add("Utilisateur");

            DropDownList2.Items.Add("Masculin");
            DropDownList2.Items.Add("Femin");

            DropDownList3.Items.Add("simple user");
            DropDownList3.Items.Add("Admin");


        } */

        Label6.Visible = false;
        Label7.Visible = false;
        Label8.Visible = false;
        Label9.Visible = false;
        Label10.Visible = false;
        TextBox4.Visible = false;
        TextBox5.Visible = false;
        TextBox6.Visible = false;
        TextBox8.Visible = false;
        TextBox9.Visible = false;
        Label5.Visible = false;
        TextBox3.Visible = false;


    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        Personne.statut = DropDownList1.SelectedItem.ToString();
        if (Personne.statut == "Medecin")
        {
            Label6.Visible = false;
            Label7.Visible = false;
            Label8.Visible = false;
            Label9.Visible = false;
            Label10.Visible = false;
            TextBox4.Visible = false;
            TextBox5.Visible = false;
            TextBox6.Visible = false;
            TextBox8.Visible = false;
            TextBox9.Visible = false;
            Label5.Visible = true;
            TextBox3.Visible = true;


        }


        if (Personne.statut == "Patient")
        {
            Label5.Visible = false;
            Label9.Visible = false;
            Label10.Visible = false;
            TextBox3.Visible = false;
            TextBox6.Visible = false;
            TextBox9.Visible = false;
            Label6.Visible = true;
            Label7.Visible = true;
            Label8.Visible = true;
            TextBox4.Visible = true;
            TextBox5.Visible = true;
            TextBox8.Visible = true;
            


        }


        if (Personne.statut == "Utilisateur")
        {

            Label5.Visible = false;
            Label6.Visible = false;
            Label7.Visible = false;
            Label8.Visible = false;
            TextBox3.Visible = false;
            TextBox4.Visible = false;
            TextBox5.Visible = false;
            TextBox8.Visible= false;
            Label9.Visible = true;
            Label10.Visible = true;
            TextBox9.Visible = true;
            TextBox6.Visible = true;

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string chaine = "Data source = TUTU; initial catalog = clinique; uid = bunso; pwd = Guy1021999; integrated Security=true";
        SqlConnection n = new SqlConnection(chaine);
        n.Open();
        if (Personne.statut == "Medecin")
        {
            string per = "insert into Personne (idPersonne,nom,prenom,statut) values(" + TextBox7.Text + ",'" + TextBox1.Text + "','" + TextBox2.Text + "','" + statut + "')";
            SqlCommand perAdd = new SqlCommand(per, n);
            perAdd.ExecuteNonQuery();
            Response.Write("enregistrer personne");
            n.Close();
            n.Open();
            string med = "insert into Medecin(personneMed,specialite) values(" + TextBox7.Text + ",'" + TextBox3.Text + "') ";
            perAdd = new SqlCommand(med, n);
            perAdd.ExecuteNonQuery();

        }

        string chaine1 = "Data source = TUTU; initial catalog = clinique; uid = bunso; pwd = Guy1021999; integrated Security=true";
        SqlConnection n1 = new SqlConnection(chaine1);
        n1.Open();
        if (Personne.statut == "Patient")
        {
            string per = "insert into Personne (idPersonne,nom,prenom,statut) values(" + TextBox7.Text + ",'" + TextBox1.Text + "','" + TextBox2.Text + "','" + statut + "')";
            SqlCommand perAdd = new SqlCommand(per, n1);
            perAdd.ExecuteNonQuery();
            Response.Write("enregistrer personne");
            n1.Close();
            n1.Open();
            string pat = "insert into Patient(personne,poids,temperature,genre) values(" + TextBox7.Text + ",'" + TextBox4.Text + "','"+ TextBox5.Text+"','"+ TextBox8.Text+"') ";
            perAdd = new SqlCommand(pat, n1);
            perAdd.ExecuteNonQuery();

        }

        string chaine2 = "Data source = TUTU; initial catalog = clinique; uid = bunso; pwd = Guy1021999; integrated Security=true";
        SqlConnection n2 = new SqlConnection(chaine2);
        n2.Open();
        if (Personne.statut == "Utilisateur")
        {
            string per = "insert into Personne (idPersonne,nom,prenom,statut) values(" + TextBox7.Text + ",'" + TextBox1.Text + "','" + TextBox2.Text + "','" + statut + "')";
            SqlCommand perAdd = new SqlCommand(per, n2);
            perAdd.ExecuteNonQuery();
            Response.Write("enregistrer personne");
            n2.Close();
            n2.Open();
            string pat = "insert into Utilisateur(personneUser,password,profile) values(" + TextBox7.Text + ",'" + TextBox6.Text + "','" + TextBox9.Text+ "') ";
            perAdd = new SqlCommand(pat, n2);
            perAdd.ExecuteNonQuery();

        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {

    }
}