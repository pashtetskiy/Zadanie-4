using Bank.Data;
using System.ComponentModel.DataAnnotations;
using System.Runtime;
using Bank.Enums;

namespace Bank.Gui;

/// <summary>
/// Application main screen.
/// </summary>
public sealed class MainScreen : Screen
{
    #region Properties And Ctor
    private BankAccount? _bankAccount;

    /// <summary>
    /// Ctor.
    /// </summary>


    #endregion Properties And Ctor

    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Your available choices are:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Create bank account");
            Console.WriteLine("2. Balance");
            Console.WriteLine("3. Deposit money");
            Console.WriteLine("4. Withdraw money");
            Console.WriteLine("5. Get Account History");
            Console.WriteLine("Please enter your choice:");

            string? choiceAsString = Console.ReadLine();

            // Validate choice
            try
            {
                MainScreenChoices? choice = (MainScreenChoices)int.Parse(choiceAsString);
                switch (choice)
                {
                    case MainScreenChoices.CreateBankAccount:
                        CreateBankAccount();
                        Console.ReadLine();
                        break;
                    case MainScreenChoices.MakeDeposit:
                        MakeDeposit();
                        Console.ReadLine();
                        break;
                    case MainScreenChoices.DisplayBalance:
                        DisplayBalance();
                        Console.ReadLine();
                        break;
                    case MainScreenChoices.MakeWithdrawal:
                        MakeWithDrawal();
                        Console.ReadLine();
                        break;
                    case MainScreenChoices.GetAccountHistory:
                        GetAccountHistory();
                        Console.ReadLine();
                        break;
                    case MainScreenChoices.Exit:
                        Console.WriteLine("Goodbye.");
                        Console.ReadLine();
                        return;
                }
            }
            catch (FormatException) { Console.WriteLine("Invalid choice. Try again."); }
        }
    }

    #endregion // Public Methods

    #region Private Methods
    // Used to create a bank account
    private void CreateBankAccount()
    {
        Console.WriteLine("Choose our card: \n 0. Debit card \n 1. Interest Earning card");
        int? cardType = int.Parse(Console.ReadLine());
        if (cardType != 0 & cardType != 1)
        {
            throw new InvalidOperationException();
        }
        Console.WriteLine("Write owner name");
        string? onwerName = Console.ReadLine();
        if (onwerName != "" & onwerName.Length < 15)
        {
            onwerName = onwerName + new string(' ', 15 - onwerName.Length);
        }
        if (cardType == 0) _bankAccount = new BankAccount(onwerName, 0, 0);
        else if (cardType == 1) _bankAccount = new InterestEarningAccount(onwerName, 0);
    }
    // Method for depositing money
    private void MakeDeposit()
    {
        try
        {
            if (_bankAccount is null) throw new ArgumentNullException(nameof(_bankAccount), "Bank account not found");
            Console.WriteLine("Deposit: ");
            decimal? _amount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Write deposit note");
            string? _depositNote = Console.ReadLine();
            if (_depositNote is null) throw new ArgumentNullException(nameof(_bankAccount), "Note not found");
            _bankAccount.MakeDeposit(_amount, DateTime.Now, _depositNote);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Bank account not found");
        }

    }
    // Method for withdrawing funds
    private void MakeWithDrawal()
    {
        try
        {
            if (_bankAccount is null) throw new ArgumentNullException(nameof(_bankAccount), "Bank account not found");
            Console.WriteLine("Withdraw: ");
            decimal? _amount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Write withdraw note");
            string? _depositNote = Console.ReadLine();
            if (_depositNote is null) throw new ArgumentNullException(nameof(_bankAccount), "Note not found");
            _bankAccount.MakeWithdrawal(_amount, DateTime.Now, _depositNote);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Bank account not found");
        }
    }
    // Method to get the history of the acc
    private void GetAccountHistory()
    {
        try
        {
            if (_bankAccount is null) throw new ArgumentNullException(nameof(_bankAccount), "Bank account not found");
            Console.WriteLine(_bankAccount.GetAccountHistory());
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Bank account not found");
        }
    }
    // Method for displaying the balance
    private void DisplayBalance()
    {
        try
        {
            if (_bankAccount is null) throw new ArgumentNullException(nameof(_bankAccount), "Bank account not found");
            _bankAccount.DisplayBalance();
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Bank account not found");
        }
    }

    #endregion // Private Methods
}