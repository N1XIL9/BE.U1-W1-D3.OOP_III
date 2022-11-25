using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BE.U1_W1_D3.OOP_III
{
    internal static class Utente
    {
        private static string _username;

        public static string UserName
        {
            get { return _username; }
            set { _username = value; }
        }

        private static bool _login;

        public static bool LogIn
        {
            get { return _login; }
            set { _login = false; }
        }

        private static string _password;

        public static string Password
        {
            get { return _password; }
            set { _password = value; }
        }


        public static DateTime dataAccesso { get; set; }

        public static DateTime dataUscita { get; set; }

        public static List<DateTime> listaAccessi { get; set; } = new List<DateTime>();


        public static void Menu()
        {
            Console.WriteLine("=============================================================================");
            Console.WriteLine("======= B E N V E N U T O  N E L L A  T U A  A R E A  P R I V A T A =========");
            Console.WriteLine("=============================================================================");
            Console.WriteLine("");


            Console.WriteLine("=========================== O P E R A Z I O N I =============================");
            Console.WriteLine("");
            Console.WriteLine("SCEGLI L'OPERAZIONE DA EFFETTUARE:");
            Console.WriteLine("");
            Console.WriteLine("1. LOGIN");
            Console.WriteLine("2. LOGOUT");
            Console.WriteLine("3. VERIFICA DATA DI LOGIN");
            Console.WriteLine("4. LISTA DEGLI ACCESSI");
            Console.WriteLine("5. ESCI");
            Console.WriteLine("");

            int scelta = int.Parse(Console.ReadLine());
            try
            {
                if (scelta == 1)
                {
                    Login();
                }
                else if (scelta == 2)
                {
                    LogOut();

                }
                else if (scelta == 3)
                {
                    VerificaData();

                }
                else if (scelta == 4)
                {
                    ListaAccessi();

                }
                else if (scelta == 5)
                {
                    Esci();
                }
                else
                {
                    Console.WriteLine("HAI SELEZIONATO UNA VOCE NON VALIDA");
                    Menu();
                }
            }
            catch (Exception ex)
            { Console.WriteLine($"Errore: {ex.Message}"); }
        }

        public static void Login()
        {
            Console.WriteLine("INSERISCI LA TUA USERNAME");
            string userName = Console.ReadLine();
           

            Console.WriteLine("INSERISCI LA TUA PASSWORD");
            string password = Console.ReadLine();
           
            Console.WriteLine("CONFERMA LA TUA PASSWORD");
            string confermaPassword = Console.ReadLine();

            _username = userName;
            _password = password;

            if (userName == UserName && password == Password && confermaPassword == Password)
            {
                _login = true;
                Console.WriteLine("DATI INSERITI CON SUCCESSO");
                dataAccesso = DateTime.Now;
                listaAccessi.Add(dataAccesso);
                Menu();
                Console.WriteLine("");
               


            }
            else
            {
                Console.WriteLine("HAI INSERITO DATI INCORRETTI, RIPROVA");
                Console.WriteLine("");

                Menu();
            }
        }

        public static void LogOut()
        {
            if (LogIn == false)
            {
                Console.WriteLine("NON SEI LOGGATO, EFFETTUA IL LOGIN");
                Console.WriteLine("");
                Console.WriteLine("");

                Menu();

            }
            else
            {
                _login = false;
                Console.WriteLine("LOGOUT EFFETTUATO");
                dataUscita = DateTime.Now;
                Console.WriteLine("");
                Console.WriteLine("");
                Menu();

            }
        }

        public static void VerificaData()
        {
            if (_login)
            {
                Console.WriteLine($"HAI EFFETTUATO L'ACCESSO IL: {dataAccesso}");
                Console.WriteLine("");                

                Menu();

            }else
            {
                Console.WriteLine("ATTENZIONE!! NON TI SEI ANCORA LOGGATO.");
                Console.WriteLine("");
                
                Menu();
            }
        }

        public static void ListaAccessi()
        {
            if (listaAccessi.Count == 0)
            {
                Console.WriteLine("NON CI SONO ACCESSI REGISTRATI!");
            }
            else
            {
                    Console.WriteLine("ECCO LA TUA LISTA ACCESSI:");
                foreach (DateTime item in listaAccessi)
                {
                    Console.WriteLine("");                  
                    Console.WriteLine(item);
                    Console.WriteLine("");
                    
                }
            }
                Menu();
        }


        public static void Esci()
        {
            Console.WriteLine("========= D I S C O N N E S S I O N E  ========");
            Thread.Sleep(2000);

            Environment.Exit(0);
        }       
    }    
}
