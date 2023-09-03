using Bank.Gui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Enums;
using SampleHierarchies.Enums;
using Bank.Services;

namespace Bank.Gui
{

    public sealed class LoginScreen : Screen
    {
        private DataService _dataService = new DataService();
        public override void Show()
        {

            while (true)
            {

                Console.Clear();
                Console.WriteLine("MBank");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Login acc");
                Console.WriteLine("2. Create acc");
                Console.WriteLine("Please enter your choice:");

                string? choiceAsString = Console.ReadLine();

                // Validate choice
                try
                { 
                    LoginScreenChoices? choice = (LoginScreenChoices)int.Parse(choiceAsString);
                    switch (choice)
                    {
                        case LoginScreenChoices.Login:
                            Login();
                            Console.ReadLine();
                            break;
                        case LoginScreenChoices.CreateAcc:
                            CreateAcc();
                            Console.ReadLine();
                            break;
                        case LoginScreenChoices.Exit:
                            Console.WriteLine("Goodbye.");
                            Console.ReadLine();
                            return;
                    }
                }
                catch (FormatException) { Console.WriteLine("Invalid choice. Try again."); }
            }
        }
        private void Login()
        {
            _dataService.LoadData();
            Console.Read();
            while (true)
            {
                Console.Clear();
                Console.Write("Login: ");
                Console.ReadLine();
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Login acc");
                Console.WriteLine("2. Create acc");
                Console.WriteLine("Please enter your choice:");

                string? choiceAsString = Console.ReadLine();

                // Validate choice
                try
                {
                    LoginScreenChoices? choice = (LoginScreenChoices)int.Parse(choiceAsString);
                    switch (choice)
                    {
                        case LoginScreenChoices.Login:
                            Login();
                            Console.ReadLine();
                            break;
                        case LoginScreenChoices.CreateAcc:
                            //MakeDeposit();
                            Console.ReadLine();
                            break;
                        case LoginScreenChoices.Exit:
                            Console.WriteLine("Goodbye.");
                            Console.ReadLine();
                            return;
                    }
                }
                catch (FormatException) { Console.WriteLine("Invalid choice. Try again."); }
            }
        }

        private void CreateAcc()
        {
            while (true)
            {
                try
                {
                    Console.Write("Write your name and surname: ");
                    string? owner = Console.ReadLine();
                    if (owner == "" | owner != null) throw new Exception(nameof(ArgumentNullException));
                    Console.Write("Create your password: ");
                    string? passwrd = Console.ReadLine();
                    if (owner == "" | owner != null) throw new Exception(nameof(ArgumentNullException));

                }
                catch (FormatException) { Console.WriteLine("Invalid input. Try again."); }
            }

        }
    }
}
