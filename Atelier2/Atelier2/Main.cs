using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atelier2
{
    public partial class Main : Form
    {

        // Membres privés
        private string nomFichier = string.Empty;

        private bool desModificationsOntEteRealisees = false;
        public Main()
        {
            InitializeComponent();
            mainNotifyIcon.Icon = Properties.Resources._2edwl7q;
            // Paramétrage de l'icone de la fenêtre
            this.Icon = Properties.Resources._2edwl7q;
            this.restaurerLaFenêtreToolStripMenuItem.Enabled = false;
        }

        private void SauverFichier(string NomDuFichier)
        {
            // Indique que tout est sauvegardé (s'il n'y a pas un bogue ...)
            desModificationsOntEteRealisees = false;
            // Utilisation d'un écrivain public !
            using (System.IO.StreamWriter streamWriter
            = new System.IO.StreamWriter(NomDuFichier, false))
            {
                // Balayage de l'ensemble des lignes de la table
                for (int i = 0; i < (mainBindingSource.DataSource as DataTable).Rows.Count; i++)
                {
                    // Concaténation de la ligne de texte
                    streamWriter.WriteLine(
                    string.Concat(
                    (mainBindingSource.DataSource as DataTable).Rows[i]["Id"], ";"
                    , (mainBindingSource.DataSource as DataTable).Rows[i]["Entreprise"], ";"
                    , (mainBindingSource.DataSource as DataTable).Rows[i]["Contact"], ";"
                    , (mainBindingSource.DataSource as DataTable).Rows[i]["Titre"], ";"
                    , (mainBindingSource.DataSource as DataTable).Rows[i]["Adresse"], ";"
                    , (mainBindingSource.DataSource as DataTable).Rows[i]["Ville"], ";"
                    , (mainBindingSource.DataSource as DataTable).Rows[i]["Region"], ";"
                    , (mainBindingSource.DataSource as DataTable).Rows[i]["CodePostal"], ";"
                    , (mainBindingSource.DataSource as DataTable).Rows[i]["Pays"], ";"
                    , (mainBindingSource.DataSource as DataTable).Rows[i]["Telephone"], ";"
                    , (mainBindingSource.DataSource as DataTable).Rows[i]["Telecopie"], ";"
                    , (mainBindingSource.DataSource as DataTable).Rows[i]["CA"]
                    == System.DBNull.Value ?
                    "0" :
                    (mainBindingSource.DataSource as DataTable).Rows[i]["CA"].ToString()));
                }
            }

        }

        private DataTable OuvrirFichier(string NomDuFichier)
        {
            // Indique que tout est sauvegardé
            desModificationsOntEteRealisees = false;
            // definition de la variable de retour
            DataTable result = null;
            // Definition et assignation des variables
            string ligneLu = string.Empty;

            Boolean estPremiereLigne = true;

            
            using (System.IO.StreamReader sr =
            new System.IO.StreamReader(NomDuFichier))
            {
                do
                {
                    // Pour chaque ligne lu
                    ligneLu = sr.ReadLine();
                    // si c'est la première ligne lue,
                    // alors créé la table de donnée
                    if (estPremiereLigne && ligneLu != null)
                    {
                        result = CreerTable();
                        estPremiereLigne = false;
                    }
                    // Si la ligne de données n'est pas nulle,
                    // alors ajoute la ligne à la table de données
                    if (ligneLu != null)
                        AjouterLigneATable(ligneLu, result);
                } while (ligneLu != null);
            }


            // renvoi de la valeur
            return result;
        }

        private void AjouterLigneATable(string LigneLue, DataTable TableDeDonnees)
        {
            int index = 0;
            // Découper la ligne en fonction du caractère de séparation
            string[] valeursLues = LigneLue.Split(new char[] { ';' });
            // Crée une nouvelle ligne de données
            DataRow ligneDeDonnees = TableDeDonnees.NewRow();
            // Pour toute les valeurs, met à jour le ligne de données
            foreach (string valeur in valeursLues)
            {
                switch (index++)
                {
                    case 0:
                        ligneDeDonnees["Id"] = valeur.Trim();
                        break;
                    case 1:
                        ligneDeDonnees["Entreprise"] = valeur.Trim();
                        break;
                    case 2:
                        ligneDeDonnees["Contact"] = valeur.Trim();
                        break;
                    case 3:
                        ligneDeDonnees["Titre"] = valeur.Trim();
                        break;
                    case 4:
                        ligneDeDonnees["Adresse"] = valeur.Trim();
                        break;
                    case 5:
                        ligneDeDonnees["Ville"] = valeur.Trim();
                        break;
                    case 6:
                        ligneDeDonnees["Region"] = valeur.Trim();
                        break;
                    case 7:
                        ligneDeDonnees["CodePostal"] = valeur.Trim();
                        break;
                    case 8:
                        ligneDeDonnees["Pays"] = valeur.Trim();
                        break;
                    case 9:
                        ligneDeDonnees["Telephone"] = valeur.Trim();
                        break;
                    case 10:
                        ligneDeDonnees["Telecopie"] = valeur.Trim();
                        break;
                    case 11:
                        ligneDeDonnees["CA"] = valeur.Trim();
                        break;
                    default:
                        ligneDeDonnees[string.Format("Colonne {0}", index)]
                        = valeur.Trim();
                        break;
                }
            }
            TableDeDonnees.Rows.Add(ligneDeDonnees);

        }

        private DataTable CreerTable()
        {
            DataTable result = new DataTable("Coach");

            
            result.Columns.Add(new DataColumn("Id", typeof(string)));
            result.Columns.Add(new DataColumn("Entreprise", typeof(string)));
            result.Columns.Add(new DataColumn("Contact", typeof(string)));
            result.Columns.Add(new DataColumn("Titre", typeof(string)));
            result.Columns.Add(new DataColumn("Adresse", typeof(string)));
            result.Columns.Add(new DataColumn("Ville", typeof(string)));
            result.Columns.Add(new DataColumn("Region", typeof(string)));
            result.Columns.Add(new DataColumn("CodePostal", typeof(string)));
            result.Columns.Add(new DataColumn("Pays", typeof(string)));
            result.Columns.Add(new DataColumn("Telephone", typeof(string)));
            result.Columns.Add(new DataColumn("Telecopie", typeof(string)));
            result.Columns.Add(new DataColumn("CA", typeof(int)));

            // Définition de la méthode de réponse en cas de changement
            result.RowChanged += new DataRowChangeEventHandler(result_RowChanged);

            return result;
        }

        private void result_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            desModificationsOntEteRealisees = true;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void quitterLapplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void maximiserLaFenêtreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void restaurerLaFenêtreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void minimiserLaFenêtreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Main_SizeChanged(object sender, EventArgs e)
        {
            // Grise les menus en fonction de l'état de la fenêtre
            this.maximiserLaFenêtreToolStripMenuItem.Enabled =
            !(this.WindowState == FormWindowState.Maximized);
            this.minimiserLaFenêtreToolStripMenuItem.Enabled =
            !(this.WindowState == FormWindowState.Minimized);
            this.restaurerLaFenêtreToolStripMenuItem.Enabled =
            !(this.WindowState == FormWindowState.Normal);
        }

        private void nouveauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainBindingSource.DataSource = CreerTable();
            mainBindingNavigator.BindingSource = mainBindingSource;
            mainDataGridView.DataSource = mainBindingNavigator.BindingSource;
        }

        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileOpen =
                new System.Windows.Forms.OpenFileDialog())
                {
                fileOpen.Filter = "Fichiers coach|*.coach";
                fileOpen.InitialDirectory = @"c:\";
                if (fileOpen.ShowDialog() == DialogResult.OK)
                {
                    // Charge le fichier de données dans la source des bindings
                    mainBindingSource.DataSource =
                    OuvrirFichier(fileOpen.FileName);
                    // Configure la navigation
                    mainBindingNavigator.BindingSource = mainBindingSource;
                    // Configure la grille de données sur la même source
                    // que la source de navigation
                    mainDataGridView.DataSource
                    = mainBindingNavigator.BindingSource;
                    // Mémorise le nom du fichier
                    nomFichier = fileOpen.FileName;
                    // Indique le nom du fichier dans le titre
                    this.Text
                    = string.Concat("Editeur du Coach C#", " - ", nomFichier);
                }
            }
        }

        private void enregistrerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Si le nom du fichier est n'existe pas (i.e. est vide)
            if (nomFichier == string.Empty)
            {
                // route l'appel vers la sauvegarde avec selection du nom
                this.enregistrerSousToolStripMenuItem_Click(sender, e);
            }
            else
            {
                // Sauvegarde les informations
                SauverFichier(nomFichier);
            }
            
        }

        private void enregistrerSousToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (SaveFileDialog fileSave = new SaveFileDialog())
            {
                fileSave.Filter = "Fichiers coach|*.coach";
                fileSave.InitialDirectory = @"c:\";
                if (fileSave.ShowDialog() == DialogResult.OK)
                {
                    // Mémorise le nom du fichier
                    nomFichier = fileSave.FileName;
                    // Sauvegarde les informations
                    SauverFichier(nomFichier);
                    // Indique le nom du fichier dans le titre
                    this.Text
                    = string.Concat("Editeur du Coach C#", " - ", nomFichier);
                }
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {

            // Test si des modification ont été apportées
            if (desModificationsOntEteRealisees)
            {
            if (MessageBox.Show("Des modifications ont été réalisées. Voulezvousquitter sans les sauvegarder ?", "Confirmation",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            == DialogResult.Cancel)
            // Annulation de la sortie
            e.Cancel = true;
            }
        }

        private void mainDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Affiche le message d'erreur
            MessageBox.Show(e.Exception.Message);
            // Create the source, if it does not already exist.
            if (!System.Diagnostics.EventLog.SourceExists("Coach C#"))
            {
                System.Diagnostics.EventLog.CreateEventSource("Coach C#",
                "Application");
            }
            // Create an EventLog instance and assign its source.
            System.Diagnostics.EventLog myLog =
            new System.Diagnostics.EventLog();
            myLog.Source = "Coach C#";
            // Write an informational entry to the event log.
            myLog.WriteEntry(e.Exception.Message);
        }
    }
}
