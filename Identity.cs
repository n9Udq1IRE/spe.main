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
            Nom = getNom(9);
            Prenom = getPrenom(9);
            DateNaissance = getDateNaissance(30, 40);
            AdresseMail = Prenom.ToLower() + "." + Nom.ToLower() + "@unimedia.fr";
            Login = getLogin(9);
            Password = getPassword(9);
            save();
        }

        private void save()
        {
            StreamWriter __sr = new StreamWriter(String.Format("identity.{0:yyyyMMddHHmmss}.txt", DateTime.Now), false);
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

        private string getLogin(int __longeur)
        {
            string __login = "";
            while (__login.Length < __longeur)
            {
                switch (Random.Next(3))
                {
                    case 0:
                        __login += __majuscules[Random.Next(__majuscules.Length)];;
                        break;
                    case 1:
                        __login += __minuscules[Random.Next(__minuscules.Length)];;
                        break;
                    case 2:
                        __login += __entiers[Random.Next(__entiers.Length)];;
                        break;
                }
            }

            return __login;
        }

        private string getPassword(int __longeur)
        {
            string __password = "";
            while (__password.Length < __longeur)
            {
                switch (Random.Next(3))
                {
                    case 0:
                        __password += __majuscules[Random.Next(__majuscules.Length)]; ;
                        break;
                    case 1:
                        __password += __minuscules[Random.Next(__minuscules.Length)]; ;
                        break;
                    case 2:
                        __password += __entiers[Random.Next(__entiers.Length)]; ;
                        break;
                }
            }

            return __password;
        }

    }
}
