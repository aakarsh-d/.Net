// using System;
// using System.IO;

// try
// {
//     try
//     {
//         File.ReadAllText("transactions.txt");
//     }
//     catch (IOException ioEx)
//     {
//         throw new ApplicationException(
//             "Unable to load transaction data",
//             ioEx
//         );
//     }
// }
// catch (Exception ex)
// {
//     Console.WriteLine("Message: " + ex.Message);
//     Console.WriteLine("Root Cause: " + ex.InnerException.Message);
// }

public class BankAccount
{
    public decimal Balance { get; private set; }

    public BankAccount(decimal initialBalance)
    {
        if (initialBalance < 0)
            throw new ArgumentException(
                "Initial balance cannot be negative",
                nameof(initialBalance));

        Balance = initialBalance;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException(
                "Withdrawal amount must be greater than zero",
                nameof(amount));

        // if (amount > Balance)
        //     throw new InsufficientBalanceException(
        //         $"Cannot withdraw {amount:C}. Available balance: {Balance:C}");

        Balance -= amount;
    }

    public static void Main()
    {
        BankAccount bankAccount = new BankAccount(1000);
        bankAccount.Withdraw(-100);

        Console.WriteLine(bankAccount.Balance);
    }
}
