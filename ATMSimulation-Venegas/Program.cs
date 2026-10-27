// See https://aka.ms/new-console-template for more information
// Authentication & Account Status
int correctPin = 4821;
bool isCardBlocked = false;
bool isInternationalCard = true;
bool isVipCustomer = false;

// Account Balances & Limits
double accountBalance = 1250.00;
double dailyWithdrawalLimit = 500.00;
double dailyWithdrawnSoFar = 150.00;

// Transaction Inputs & Totals
int enteredPin;
double withdrawalAmount;
double totalFees = 0.00;

// Stage 1: Card & PIN Authentication
//1. Check if the card is blocked
if (isCardBlocked)
{
    Console.WriteLine("Your card is blocked. Please contact your bank.");
    return;
}

//2. Ask for the PIN and read it
Console.Write("Enter your 4-digit PIN: ");
enteredPin = int.Parse(Console.ReadLine());

//3. Check the PIN
if (enteredPin != correctPin)
{
    Console.WriteLine("Invalid PIN. Please try again.");
    return;
}

// Stage 2: Withdrawal Process
//1. Show the balance
Console.WriteLine($"Your current balance is: ${accountBalance:F2}");

//2. Ask for the amount to withdraw and read it
Console.Write("Enter the amount to withdraw: ");
withdrawalAmount = double.Parse(Console.ReadLine());

//3. Validate the withdrawal amount
if (withdrawalAmount <= 0)
{
    Console.WriteLine("Invalid withdrawal amount. Please enter a positive value.");
    return;
}

//4. Check if the withdrawal amount is valid 
if (withdrawalAmount % 20 != 0 && withdrawalAmount % 50 != 0)
{
    Console.WriteLine("Withdrawal amount must be in multiples of $20 or $50.");
    return;
}

//Stage 3: Daily Limits & Balance Validation
//range withdrawal limit = 500 - 150 = 350
double remainingDailyLimit = dailyWithdrawalLimit - dailyWithdrawnSoFar;
if (withdrawalAmount > remainingDailyLimit)
{
    Console.WriteLine($"Withdrawal amount exceeds your daily limit. You can withdraw up to ${remainingDailyLimit:F2} today.");
    return;
}

//basic balance check
if (withdrawalAmount > accountBalance)
{
    Console.WriteLine("Declined: insufficient funds.");
    return;
}
