using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class Consultation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string chaine = "Data source = TUTU; initial catalog = clinique; uid = bunso; pwd = Guy1021999; integrated Security=true";
        SqlConnection n = new SqlConnection(chaine);
        n.Open();
        string requete ="";
            requete = "select idpatient, nom, prenom from patient, personne where patient.personne = personne.idPersonne";
        SqlCommand com = new SqlCommand(requete, n);
        SqlDataReader dr = com.ExecuteReader();

        while (dr.Read())
        {
            DropDownList2.Items.Add(dr.GetInt32(0) + " " + dr.GetString(1) + " " + dr.GetString(2));

        }
        n.Close();
        n.Open();

        requete = "select idMedecin,nom,prenom from medecin,personne where medecin.personneMed=personne.idPersonne";
        SqlCommand com1 = new SqlCommand(requete, n);
        SqlDataReader dr1 = com1.ExecuteReader();

        while (dr1.Read())
        {
            DropDownList1.Items.Add(dr1.GetInt32(0) + " " + dr1.GetString(1) + " " + dr1.GetString(2));
           }
        n.Close();
        n.Open();


        requete = "select idService, nomServices from services";
        SqlCommand com2 = new SqlCommand(requete, n);
        SqlDataReader dr2 = com2.ExecuteReader();

        while (dr2.Read())
        {
            DropDownList3.Items.Add(dr2.GetInt32(0) + " " + dr2.GetString(1));
        }
        n.Close();
      
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click1(object sender, EventArgs e)
    {

        string chaine2= "Data source = TUTU; initial catalog = clinique; uid = bunso; pwd = Guy1021999; integrated Security=true";
        SqlConnection n2 = new SqlConnection(chaine2);
        n2.Open();


        string drop1 =DropDownList1.SelectedItem.ToString();
        string drop2 = DropDownList2.SelectedItem.ToString();
        string drop3 = DropDownList3.SelectedItem.ToString();


        string[] med = drop1.Split(' ');
        string[] pat = drop2.Split(' ');
        string[] serv = drop3.Split(' ');
        string date = DateTime.Now.ToShortTimeString();





        string requete = "insert into consultation(patient,service,medecin,dateConsultation) values (" + pat[0] + "," + serv[0] + "," + med[0] + ",'" + date + "')";

        SqlCommand perAdd = new SqlCommand(requete, n2);
        perAdd.ExecuteNonQuery();
        Response.Write("enregistrer consultation avec success");
        n2.Close();
    }
    protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
}