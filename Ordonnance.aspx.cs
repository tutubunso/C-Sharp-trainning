using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using sharpPDF;

public partial class Ordonnance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

     string chaine = "Data source = TUTU; initial catalog = clinique; uid = bunso; pwd = Guy1021999; integrated Security=true";
        SqlConnection n = new SqlConnection(chaine);
        n.Open();
        if (!IsPostBack)
        {
            string requete = "";
            requete = "select idpatient, p.nom, pa.total from produit, commande where produit.commande = commande.idcommande";
            SqlCommand com = new SqlCommand(requete, n);
            SqlDataReader dr = com.ExecuteReader();

            while (dr.Read())
            {
                DropDownList1.Items.Add(dr.GetInt32(0) + " " + dr.GetString(1) + " " + dr.GetString(2));

            }
            n.Close();
            n.Open();


            requete = "select idpayement, montant_paye from paies";
            SqlCommand com2 = new SqlCommand(requete, n);
            SqlDataReader dr2 = com2.ExecuteReader();

            while (dr2.Read())
            {
                DropDownList2.Items.Add(dr2.GetInt32(0) + " " + dr2.GetString(1));
            }
            n.Close();
        }
      
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string servi = DropDownList2.SelectedItem.ToString();
        string[] ser = servi.Split(' ');

        string chaine = "Data source = TUTU; initial catalog = clinique; uid = bunso; pwd = Guy1021999; integrated Security=true";
        SqlConnection n = new SqlConnection(chaine);
        n.Open();

        pdfDocument d = new pdfDocument("Rapport", "guy");
        pdfPage p = d.addPage();
        //p.addImage();
        p.addText("Rapport sur les ptients dans un service",100,700,d.getFontReference(sharpPDF.Enumerators.predefinedFont.csCourierBold),16);

        string requete = "";
        requete = "select id, produit,montant_paye,retse, from paies, commandes,produitd where paies.commandes = commandes.idcommandes and commandes.idcommandest=produit.idproduit ";
        SqlCommand com = new SqlCommand(requete, n);
        SqlDataReader dr = com.ExecuteReader();


        d.createPDF(@"C:\Users\Thecie\Desktop\tutu\rapport.pdf");
        p.addText("Id ", 100, 600, d.getFontReference(sharpPDF.Enumerators.predefinedFont.csCourierBold), 11);
        p.addText("Produit ", 220, 600, d.getFontReference(sharpPDF.Enumerators.predefinedFont.csCourierBold), 11);
        p.addText("Montant paye", 320, 600, d.getFontReference(sharpPDF.Enumerators.predefinedFont.csCourierBold), 11);
        p.addText("Reste ", 450, 600, d.getFontReference(sharpPDF.Enumerators.predefinedFont.csCourierBold), 11);
       


        while (dr.Read())
        {
            p.addText(dr.GetString(0), 100, 580, d.getFontReference(sharpPDF.Enumerators.predefinedFont.csCourierBoldOblique), 11);
            p.addText(dr.GetString(1), 220, 580, d.getFontReference(sharpPDF.Enumerators.predefinedFont.csCourierBoldOblique), 11);
            p.addText(dr.GetString(2), 320, 580, d.getFontReference(sharpPDF.Enumerators.predefinedFont.csCourierBoldOblique), 11);
            p.addText(dr.GetString(3), 450, 580, d.getFontReference(sharpPDF.Enumerators.predefinedFont.csCourierBoldOblique), 11);
            p.addText(dr.GetString(4), 550, 580, d.getFontReference(sharpPDF.Enumerators.predefinedFont.csCourierBoldOblique), 11);

        
        }
        d.createPDF(@"C:\Users\Thecie\Desktop\tutu\rapport.pdf");


        n.Close();
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}