using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace spe.main
{
    class Identity
    {

        #region Types
        
        public enum EnumSexe
        {
            Masculin = 0,
            Feminin = 1
        }

        #endregion

        #region Attributs

        #region Attributs.Privés

        private Random Random = new Random();
        private char[] __speciaux = { '~', '!', '@', '#', '$', '%', '^', '*', '(', ')', '_', '-', '+', '=', '{', '}', '[', ']', '|', ':', ';', '"', ',', '?' };
        private char[] __entiers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private char[] __majuscules = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        private char[] __majusculesConsonnes = { 'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Z' };
        private char[] __majusculesVoyelles = { 'A', 'E', 'I', 'O', 'U', 'Y' };
        private char[] __minuscules = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        private char[] __minusculesConsonnes = { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z' };
        private char[] __minusculesVoyelles = { 'a', 'e', 'i', 'o', 'u', 'y' };

        #endregion

        #region Attributs.Publiques

        public DateTime DateNaissance { get; set; }
        public EnumSexe Sexe { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string AdresseMail { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        #endregion

        #endregion

        #region Constructeurs

        /// <summary>
        /// 
        /// </summary>
        public Identity()
        {
            DateNaissance = getDateNaissance(18, 80);
            Sexe = (Random.Next(2) == 0) ? EnumSexe.Masculin : EnumSexe.Feminin;
            Nom = getNom(5 + Random.Next(10));
            Prenom = getPrenom();
            AdresseMail = Prenom.ToLower() + "." + Nom.ToLower() + "@unimedia.fr";
            Login = getLogin();
            Password = getPassword();
        }

        #endregion

        #region Fonctions

        #region Fonctions.Publiques

        /// <summary>
        /// 
        /// </summary>
        /// <param name="__file"></param>
        public void save(string __file = "")
        {
            if (__file == "")
            {
                __file = String.Format("../../output/identity.{0:yyyyMMddHHmmss}.txt", DateTime.Now);
            }
            StreamWriter __sr = new StreamWriter(__file, false);
            __sr.WriteLine(String.Format("DateNaissance : {0}", DateNaissance));
            string __temp = (Sexe == EnumSexe.Masculin) ? "Masculin" : "Feminin";
            __sr.WriteLine(String.Format("Sexe : {0}", __temp));
            __sr.WriteLine(String.Format("Nom : {0}", Nom));
            __sr.WriteLine(String.Format("Prenom : {0}", Prenom));
            __sr.WriteLine(String.Format("AdresseMail : {0}", AdresseMail));
            __sr.WriteLine(String.Format("Login : {0}", Login));
            __sr.WriteLine(String.Format("Password : {0}", Password));
            __sr.Close();
            __sr.Dispose();
        }

        #endregion

        #region Fonctions.Privés

        /// <summary>
        /// 
        /// </summary>
        /// <param name="__longueur"></param>
        /// <returns></returns>
        private string getNom(int __longueur)
        {
            string __nom = "";
            while (__nom.Length < __longueur)
            {
                if (__nom.Length % 2 == 0)
                {
                    __nom += __majusculesConsonnes[Random.Next(__majusculesConsonnes.Length)];
                }
                else
                {
                    __nom += __majusculesVoyelles[Random.Next(__majusculesVoyelles.Length)];
                }
            }

            return __nom;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="__longueur"></param>
        /// <returns></returns>
        private string getPrenomAleatoire(int __longueur)
        {
            string __prenom = "";
            if (Random.Next(10) % 2 == 0)
            {
                __prenom += __majusculesConsonnes[Random.Next(__majusculesConsonnes.Length)];
            }
            else
            {
                __prenom += __majusculesVoyelles[Random.Next(__majusculesVoyelles.Length)];
            }
            while (__prenom.Length < __longueur)
            {
                if (__prenom.Length % 2 == 0)
                {
                    __prenom += __minusculesConsonnes[Random.Next(__minusculesConsonnes.Length)];
                }
                else
                {
                    __prenom += __minusculesVoyelles[Random.Next(__minusculesVoyelles.Length)];
                }
            }

            return __prenom;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string getPrenom()
        {
            string __prenom = getPrenomAleatoire(5 + Random.Next(10));
            // http://meilleursprenoms.com
            int __page = 1;
            int __pageMax = Random.Next(5);
            List<string> __prenoms = new List<string>();
            WebClient __wc = new WebClient();
            bool __trouve = true;
            while (__trouve && __page <= __pageMax)
            {
                __trouve = false;
                string __source = __wc.DownloadString(String.Format("http://meilleursprenoms.com/stats/topannee.php3?annee={0}&page={1}", DateNaissance.Year, __page));
                List<string> __valeurs = new List<string>();
                getListeFromModele(__source, "<table width=\"300\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\">[*]</table>", ref __valeurs, true);
                if (__valeurs.Count == 1)
                {
                    __source = __valeurs[0];
                    getListeFromModele(__source, "<td class=\"mpfont\">[*]</td>", ref __valeurs, true);
                    if (__valeurs.Count == 3)
                    {
                        __source = (Sexe == EnumSexe.Masculin) ? __source = __valeurs[1] : __source = __valeurs[2];
                        getListeFromModele(__source, "<a href=\"/stats/prenom.php3/[*]\">", ref __valeurs, false);
                        __prenoms.AddRange(__valeurs);
                        __trouve = true;
                        __page++;
                    }
                }
            }
            __wc.Dispose();
            if (__prenoms.Count > 0)
            {
                __prenom = __prenoms[Random.Next(__prenoms.Count)];
            }
            
            return __prenom;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="__ageMin"></param>
        /// <param name="__ageMax"></param>
        /// <returns></returns>
        private DateTime getDateNaissance(int __ageMin, int __ageMax)
        {
            DateTime __dateNaissance = DateTime.Now;
            __dateNaissance = __dateNaissance.AddYears(-__ageMin - Random.Next(__ageMax - __ageMin));
            int __signe = (Random.Next(10) % 2 == 0) ? 1 : -1;
            __dateNaissance = __dateNaissance.AddDays(__signe * Random.Next(365));
            __signe = (Random.Next(10) % 2 == 0) ? 1 : -1;
            __dateNaissance = __dateNaissance.AddHours(__signe * Random.Next(24));
            __signe = (Random.Next(10) % 2 == 0) ? 1 : -1;
            __dateNaissance = __dateNaissance.AddMinutes(__signe * Random.Next(60));
            __signe = (Random.Next(10) % 2 == 0) ? 1 : -1;
            __dateNaissance = __dateNaissance.AddSeconds(__signe * Random.Next(60));
            __signe = (Random.Next(10) % 2 == 0) ? 1 : -1;
            __dateNaissance = __dateNaissance.AddMilliseconds(__signe * Random.Next(1000));

            return __dateNaissance;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string getLogin()
        {
            string __login = "";
            string __loginTemp = "";
            __loginTemp += __majuscules[Random.Next(__majuscules.Length)];
            __loginTemp += __majuscules[Random.Next(__majuscules.Length)];
            __loginTemp += __majuscules[Random.Next(__majuscules.Length)];
            __loginTemp += __majuscules[Random.Next(__majuscules.Length)];
            __loginTemp += __minuscules[Random.Next(__minuscules.Length)];
            __loginTemp += __minuscules[Random.Next(__minuscules.Length)];
            __loginTemp += __minuscules[Random.Next(__minuscules.Length)];
            __loginTemp += __minuscules[Random.Next(__minuscules.Length)];
            while (__loginTemp != "")
            {
                int __index = Random.Next(__loginTemp.Length);
                __login += __loginTemp[__index];
                if (__index == 0)
                {
                    __loginTemp = __loginTemp.Substring(1);
                }
                else
                {
                    if (__index == __loginTemp.Length - 1)
                    {
                        __loginTemp = __loginTemp.Substring(0, __index);
                    }
                    else
                    {
                        __loginTemp = __loginTemp.Substring(0, __index) + __loginTemp.Substring(__index + 1);
                    }
                }
            }
            __login += __entiers[Random.Next(__entiers.Length)];
            __login += __entiers[Random.Next(__entiers.Length)];

            return __login;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string getPassword()
        {
            string __password = "";
            string __passwordTemp = "";
            int __nbre = 1;
            while (__nbre <= 3)
            {
                __passwordTemp += __majuscules[Random.Next(__majuscules.Length)]; __nbre++;
            }
            __nbre = 1;
            while (__nbre <= 3)
            {
                __passwordTemp += __minuscules[Random.Next(__minuscules.Length)]; __nbre++;
            }
            __nbre = 1;
            while (__nbre <= 2)
            {
                __passwordTemp += __entiers[Random.Next(__entiers.Length)]; __nbre++;
            }
            __nbre = 1;
            while (__nbre <= 2)
            {
                __passwordTemp += __speciaux[Random.Next(__speciaux.Length)]; __nbre++;
            }
            while (__passwordTemp != "")
            {
                int __index = Random.Next(__passwordTemp.Length);
                __password += __passwordTemp[__index];
                if (__index == 0)
                {
                    __passwordTemp = __passwordTemp.Substring(1);
                }
                else
                {
                    if (__index == __passwordTemp.Length - 1)
                    {
                        __passwordTemp = __passwordTemp.Substring(0, __index);
                    }
                    else
                    {
                        __passwordTemp = __passwordTemp.Substring(0, __index) + __passwordTemp.Substring(__index + 1);
                    }
                }
            }

            return __password;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="__source"></param>
        /// <param name="__modele"></param>
        /// <param name="__liste"></param>
        /// <param name="__avec"></param>
        private void getListeFromModele(string __source, string __modele, ref List<string> __liste, bool __avec)
        {
            __liste.Clear();
            string __debut = "";
            string __fin = "";
            int __index = __modele.IndexOf("[*]");
            if (__index != -1)
            {
                __debut = __modele.Substring(0, __index);
                __fin = __modele.Substring(__index + 3);
                string __valeur = "";
                int __indexDebut = 0;
                int __indexFin = 0;
                __indexDebut = __source.IndexOf(__debut);
                if (__indexDebut != -1)
                {
                    __indexFin = __source.IndexOf(__fin, __indexDebut + __debut.Length);
                    while (__indexDebut != -1 && __indexFin != -1)
                    {
                        if (__avec)
                            __valeur = __source.Substring(__indexDebut, (__indexFin - __indexDebut) + __fin.Length);
                        else
                            __valeur = __source.Substring(__indexDebut + __debut.Length, __indexFin - __indexDebut - __debut.Length);
                        __liste.Add(__valeur);
                        __indexDebut = __source.IndexOf(__debut, __indexFin + __fin.Length);
                        if (__indexDebut != -1)
                        {
                            __indexFin = __source.IndexOf(__fin, __indexDebut + __debut.Length);
                        }
                    }
                }
            }
        }

        #endregion

        #endregion

    }
}
