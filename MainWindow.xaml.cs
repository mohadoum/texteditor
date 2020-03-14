using System;
using System.Windows;
using Microsoft.Win32;

namespace EditeurFichier
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Nom du fichier à utiliser
        /// </summary>
        private string nomFichier = String.Empty;
        private string contenuOriginal = String.Empty;
        private bool changed = false;


        public MainWindow()
        {
            InitializeComponent();
         
            boutonEnregistrer.IsEnabled = false;
        }

        /// <summary>
        /// Ouvrir le fichier après la sélection par l'utilisateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoutonOuvrir_Click(object sender, RoutedEventArgs e)
        {
            // TODO - Mettre à jour la méthode BoutonOuvrir_Click 
            // Appel méthode LireNomFichier pour avoir le nom du fichier à charger           

            // Charger la zone de texte de l'éditeur avec le contenu du fichier
            if(this.nomFichier != String.Empty && this.contenuOriginal != editeur.Text)
            {
                MessageBoxResult re = MessageBox.Show("Enregistrement de votre fichier d'abord!", "Enregistrement", MessageBoxButton.YesNoCancel);
                if (re == MessageBoxResult.Yes)
                {
                    if (this.nomFichier != String.Empty)
                    {
                        EntreesSortiesTexte.EcrireTexte(this.nomFichier, editeur.Text);

                        boutonEnregistrer.IsEnabled = false;

                        MessageBox.Show("Vos modifications ont été enregistrées avec Succés!");
                    }
                    else
                    {
                        MessageBox.Show("Vous n'avez pas encore charger un fichier!");
                    }
                }else if (re == MessageBoxResult.No)
                {
                    editeur.Text = this.contenuOriginal;
                }
            }
            else
            {
                string result = LireNomFichier();
                if (result != String.Empty)
                {
                    this.nomFichier = result;
                    contenuOriginal = EntreesSortiesTexte.LireTexte(this.nomFichier);
                    /* editeur.Text = EntreesSortiesTexte.FiltrerTexte(this.nomFichier); */
                    editeur.Text = contenuOriginal;

                }
                else
                {
                    boutonEnregistrer.IsEnabled = false;
                    MessageBox.Show("Vous n'avez pas réussi à charger un fichier!");
                }
            }
            
         }

        // TODO - Implémenter une méthode pour lire le nom du fichier 
        // Ajouter une méthode LireNomFichier 
 

        // Enregistrer les données à nouveau dans le fichier
        private void BoutonEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            // TODO - Mettre à jour la méthode  BoutonEnregistrer_Click 
            // Enregistrer le contenu de la zone de texte de l'éditeur à nouveau dans le fichier
            if(this.nomFichier != String.Empty)
            {
                this.contenuOriginal = editeur.Text;
                EntreesSortiesTexte.EcrireTexte(this.nomFichier, editeur.Text);
       
                boutonEnregistrer.IsEnabled = false;
             
                MessageBox.Show("Vos modifications ont été enregistrées avec Succés!");
            }else
            {
                MessageBox.Show("Vous n'avez pas encore charger un fichier!");
            }
        }

        private string LireNomFichier()
        {
            string fnom = String.Empty;

            OpenFileDialog dlgOuvrirFichier = new OpenFileDialog(); // Créer instance. 
            dlgOuvrirFichier.InitialDirectory = @"C:\Souche51";
            dlgOuvrirFichier.DefaultExt = ".txt";
            dlgOuvrirFichier.Filter = "Texte Documents(.txt) | *.txt";
            dlgOuvrirFichier.Title = "Rechercher un fichier texte à ouvrir";   // Renseigner les 
            bool? resultat = dlgOuvrirFichier.ShowDialog(); // Afficher dialogue sélection. 

            if (resultat == true)
            {
                fnom = dlgOuvrirFichier.FileName;
            }
            return fnom;
        }


        private void editeur_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (this.nomFichier != String.Empty)
            {
                if(this.contenuOriginal != editeur.Text)
                    boutonEnregistrer.IsEnabled = true;
                else
                {
                    boutonEnregistrer.IsEnabled = false;
                }
            }

        }
    }   
}
