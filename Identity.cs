using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace spe.main
{
    class Identity
    {
        private Random Random = new Random();
        private char[] __speciaux = { '~', '!', '@', '#', '$', '%', '^', '*', '(', ')', '_', '-', '+', '=', '{', '}', '[', ']', '|', ':', ';', '"', ',', '?' };
        private char[] __entiers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private char[] __majuscules = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        private char[] __majusculesConsonnes = { 'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Z' };
        private char[] __majusculesVoyelles = { 'A', 'E', 'I', 'O', 'U', 'Y' };
        private char[] __minuscules = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        private char[] __minusculesConsonnes = { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z' };
        private char[] __minusculesVoyelles = { 'a', 'e', 'i', 'o', 'u', 'y' };

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public string AdresseMail { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public Identity()
        {
            Nom = getNom(5 + Random.Next(10));
            Prenom = getPrenom(5 + Random.Next(10));
            DateNaissance = getDateNaissance(18, 18 + Random.Next(50));
            AdresseMail = Prenom.ToLower() + "." + Nom.ToLower() + "@unimedia.fr";
            Login = getLogin();
            Password = getPassword();
        }

        public void save(string __file = "")
        {
            if (__file == "")
            {
                __file = String.Format("../../output/identity.{0:yyyyMMddHHmmss}.txt", DateTime.Now);
            }
            StreamWriter __sr = new StreamWriter(__file, false);
            __sr.WriteLine(String.Format("Nom : {0}", Nom));
            __sr.WriteLine(String.Format("Prenom : {0}", Prenom));
            __sr.WriteLine(String.Format("DateNaissance : {0}", DateNaissance));
            __sr.WriteLine(String.Format("AdresseMail : {0}", AdresseMail));
            __sr.WriteLine(String.Format("Login : {0}", Login));
            __sr.WriteLine(String.Format("Password : {0}", Password));
            __sr.Close();
            __sr.Dispose();
        }

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

        private string getPrenom(int __longueur)
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

        private DateTime getDateNaissance(int __ageMin, int __ageMax)
        {
            DateTime __dateNaissance = DateTime.Now;
            __dateNaissance = __dateNaissance.AddYears(-__ageMin + Random.Next(__ageMax - __ageMin));
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

        private string getPassword()
        {
            string __password = "";
            string __passwordTemp = "";
            __passwordTemp += __majuscules[Random.Next(__majuscules.Length)];
            __passwordTemp += __majuscules[Random.Next(__majuscules.Length)];
            __passwordTemp += __majuscules[Random.Next(__majuscules.Length)];
            __passwordTemp += __minuscules[Random.Next(__minuscules.Length)];
            __passwordTemp += __minuscules[Random.Next(__minuscules.Length)];
            __passwordTemp += __minuscules[Random.Next(__minuscules.Length)];
            __passwordTemp += __entiers[Random.Next(__entiers.Length)];
            __passwordTemp += __entiers[Random.Next(__entiers.Length)];
            __passwordTemp += __speciaux[Random.Next(__speciaux.Length)];
            __passwordTemp += __speciaux[Random.Next(__speciaux.Length)];
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

    }
}
