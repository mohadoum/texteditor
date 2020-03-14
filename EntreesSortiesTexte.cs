using System;
using System.IO;
using System.Text;


namespace EditeurFichier
{
    public static class EntreesSortiesTexte
    {
        public static string LireTexte(string nomDuFichier)
        {
            if(nomDuFichier != String.Empty)
            {
                if(File.Exists(nomDuFichier))
                {
                    return File.ReadAllText(nomDuFichier);
                }
            }

            return String.Empty;
        }

        public static void EcrireTexte(string nomDuFichier, string contenuPourFichier)
        {
            if(File.Exists(nomDuFichier))
            {
                File.WriteAllText(nomDuFichier, contenuPourFichier);
            }
        }

        public static string FiltrerTexte(string nomDuFichier)
        {
            if(File.Exists(nomDuFichier))
            {
             
                StringBuilder contenuFichier = new StringBuilder();
                int codeCaractere;
                StreamReader fluxFichier = new StreamReader(nomDuFichier);
                while((codeCaractere = fluxFichier.Read()) != -1)
                {
                    switch((char)codeCaractere)
                    {
                        case '"':
                            contenuFichier.Append("&quot;");
                            break;
                        case '&':
                            contenuFichier.Append("&amp;");
                            break;
                        case '\'':
                            contenuFichier.Append("&apos;");
                            break;
                        case '<':
                            contenuFichier.Append("&lt;");
                            break;
                        case '>':
                            contenuFichier.Append("&gt;");
                            break;
                        case '{':
                            contenuFichier.Append("&acg;");
                            break;
                        case '}':
                            contenuFichier.Append("&acd;");
                            break;
                        case '$':
                            contenuFichier.Append("&dol;");
                            break;
                        case '(':
                            contenuFichier.Append("&parg;");
                            break;
                        case ')':
                            contenuFichier.Append("&pard;");
                            break;
                        default:
                            contenuFichier.Append((char)codeCaractere);
                            break;
                        
                    }
                }
                return contenuFichier.ToString();

            }
            else
            {
                return String.Empty;
            }
             
        }
    }
}

