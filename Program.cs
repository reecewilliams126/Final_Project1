// See https://aka.ms/new-console-template for more information
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

Console.WriteLine("Hello, World!");
Console.Clear();
string[] myStatement = File.ReadAllLines("income.txt");
List<string> bank = new List<string>();
List<decimal> gross = new List<decimal>();
List<decimal> net = new List<decimal>();
List<decimal> savings = new List<decimal>();
List<decimal> welfare = new List<decimal>();
List<decimal> housing = new List<decimal>();
List<decimal> needs = new List<decimal>();
List<decimal> disposibleIncome = new List<decimal>();
List<decimal> totalInForDate = new List<decimal>();
List<decimal> tottalOutForDate = new List<decimal>();
List<decimal> total = new List<decimal>();

foreach (string junk in myStatement)
{
    string[] tempStatement = junk.Split(";");
    bank.Add(tempStatement[0]);
    gross.Add(Convert.ToDecimal(tempStatement[1]));
    net.Add(Convert.ToDecimal(tempStatement[2]));
    savings.Add(Convert.ToDecimal(tempStatement[3]));
    welfare.Add(Convert.ToDecimal(tempStatement[4]));
    housing.Add(Convert.ToDecimal(tempStatement[5]));
    needs.Add(Convert.ToDecimal(tempStatement[6]));
    disposibleIncome.Add(Convert.ToDecimal(tempStatement[7]));
    totalInForDate.Add(Convert.ToDecimal(tempStatement[8]));
    tottalOutForDate.Add(Convert.ToDecimal(tempStatement[9]));
    total.Add(Convert.ToDecimal(tempStatement[10]));
}

Console.WriteLine("Is this a depoist or deduction?\n1. Deposit\n2. Deduction");
int dORd = Convert.ToInt32(Console.ReadLine());

if (dORd == 1)//If it was a deposit
{   
    Console.WriteLine("Please input your gross paycheck amount.");
    Decimal grossInput = Convert.ToDecimal(Console.ReadLine());
    if (grossInput<0)
    {
        Console.WriteLine("You can't input a negative gross number.");
        Environment.Exit(0);
    }
    Console.WriteLine("Now input your net earnings");
    Decimal netInput = Convert.ToDecimal(Console.ReadLine());
    if (netInput<0)
    {
        Console.WriteLine("You can't input a negative net number.");
        Environment.Exit(0);
    }
    Console.WriteLine("Where did you deposit your check?\n1. UCCU\n2. Umpqua\n3. Got Cash");
    Decimal bankChoice = Convert.ToDecimal(Console.ReadLine());

    Decimal tax2 = grossInput - netInput;
    Debug.Assert(grossInput>=netInput,"Debug 1 not working");
    Decimal savings2 = netInput/2;
    Decimal welfare2 = netInput/10;
    Decimal housing2 = netInput/10;
    Decimal nessesities2 = netInput/4;
    Decimal disposibleIncome2 = netInput-(savings2+housing2+nessesities2+welfare2);
    Debug.Assert(savings2+welfare2+housing2+nessesities2+disposibleIncome2==netInput,"Debug 2 not working.");
    Debug.Assert(netInput>=0, "netInput is negative.");
    Debug.Assert(grossInput>=0, "grossInput is negative.");

    if (bankChoice == 1)//For UCCU
    {
        Console.WriteLine("UCCU");
        gross[0]=gross[0]+grossInput;
        net[0]=net[0]+netInput;
        savings[0]=savings[0]+savings2;
        welfare[0]=welfare[0]+welfare2;
        housing[0]=housing[0]+housing2;
        needs[0]=needs[0]+nessesities2;
        disposibleIncome[0]=disposibleIncome[0]+disposibleIncome2;
        totalInForDate[0]=totalInForDate[0]+netInput;
        total[0]=total[0]+netInput;
        tottalOutForDate[3]=tottalOutForDate[3]+tax2;
        total[3]=total[3]+tax2;

        List<string> fileLines = new List<string>();
        for (int i=0;i<bank.Count;i++)
        {
            string newString = $"{bank[i]};{gross[i]};{net[i]};{savings[i]};{welfare[i]};{housing[i]};{needs[i]};{disposibleIncome[i]};{totalInForDate[i]};{tottalOutForDate[i]};{total[i]}";
            fileLines.Add(newString);
            continue;
        }
        SaveToFile2(fileLines);
    }
    else if (bankChoice == 2)//For Umpqua
    {
        Console.WriteLine("Umpqua");
        int a = 1;
        gross[a]=gross[a]+grossInput;
        net[a]=net[a]+netInput;
        savings[a]=savings[a]+savings2;
        welfare[a]=welfare[a]+welfare2;
        housing[a]=housing[a]+housing2;
        needs[a]=needs[a]+nessesities2;
        disposibleIncome[a]=disposibleIncome[a]+disposibleIncome2;
        totalInForDate[a]=totalInForDate[a]+netInput;
        total[a]=total[a]+netInput;
        tottalOutForDate[3]=tottalOutForDate[3]+tax2;
        total[3]=total[3]+tax2;

        List<string> fileLines = new List<string>();
        for (int i=0;i<bank.Count;i++)
        {
            string newString = $"{bank[i]};{gross[i]};{net[i]};{savings[i]};{welfare[i]};{housing[i]};{needs[i]};{disposibleIncome[i]};{totalInForDate[i]};{tottalOutForDate[i]};{total[i]}";
            fileLines.Add(newString);
            continue;
        }
        SaveToFile2(fileLines);    
    }
    else if (bankChoice == 3) //Cash
    {
        Console.WriteLine("Cash");
        int a = 2;
        gross[a]=gross[a]+grossInput;
        net[a]=net[a]+netInput;
        savings[a]=savings[a]+savings2;
        welfare[a]=welfare[a]+welfare2;
        housing[a]=housing[a]+housing2;
        needs[a]=needs[a]+nessesities2;
        disposibleIncome[a]=disposibleIncome[a]+disposibleIncome2;
        totalInForDate[a]=totalInForDate[a]+netInput;
        total[a]=total[a]+netInput;
        tottalOutForDate[3]=tottalOutForDate[3]+tax2;
        total[3]=total[3]+tax2;

        List<string> fileLines = new List<string>();
        for (int i=0;i<bank.Count;i++)
        {
            string newString = $"{bank[i]};{gross[i]};{net[i]};{savings[i]};{welfare[i]};{housing[i]};{needs[i]};{disposibleIncome[i]};{totalInForDate[i]};{tottalOutForDate[i]};{total[i]}";
            fileLines.Add(newString);
            continue;
        }
        SaveToFile2(fileLines);    
    }
    else
    {
        Console.WriteLine("Please choose '1','2' or '3' next time");
    }
}
else if (dORd == 2)//If it was a deduction
{
    Console.WriteLine("Please input your amount of deductions");
    Decimal deduction = Convert.ToDecimal(Console.ReadLine());
    if (deduction<0)
    {
        Console.WriteLine("You can't put in a negative deduction, because then that would be a positive, dummy.");
        Environment.Exit(0);
    }
    Debug.Assert(deduction>0, "The deduction is negative");
    Console.WriteLine("Where did you withdraw this money?\n1. UCCU\n2. Umpqua\n3. Got Cash");
    int bankChoice = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Where did you take out the deductions?\n1. Savings\n2. Welfare\n3. Housing\n4. Needs\n5. Disposible Income");
    //decide what the deductions would be for (desposible income or rent, etc.)
    int usedMoney = Convert.ToInt32(Console.ReadLine());

    if (bankChoice == 1)//For UCCU
    {
        Console.WriteLine("UCCU");
        int a = 0;
        if (usedMoney == 1)//Savings
        {
            net[a]=net[a]-deduction;//UCCU
            savings[a]=savings[a]-deduction;
            tottalOutForDate[a]=tottalOutForDate[a]+deduction;
            total[a]=total[a]-deduction;
            savings[5]=savings[5]+deduction;
            tottalOutForDate[5]=tottalOutForDate[5]+deduction;
            total[5]=total[5]+deduction;

            List<string> fileLines = new List<string>();
            for (int i=0;i<bank.Count;i++)
            {
                string newString = $"{bank[i]};{gross[i]};{net[i]};{savings[i]};{welfare[i]};{housing[i]};{needs[i]};{disposibleIncome[i]};{totalInForDate[i]};{tottalOutForDate[i]};{total[i]}";
                fileLines.Add(newString);
                continue;
            }
            SaveToFile2(fileLines);
        }
        else if (usedMoney == 2)//Welfare
        {
            net[a]=net[a]-deduction;//UCCU
            welfare[a]=welfare[a]-deduction;
            tottalOutForDate[a]=tottalOutForDate[a]+deduction;
            total[a]=total[a]-deduction;
            welfare[5]=welfare[5]+deduction;
            tottalOutForDate[5]=tottalOutForDate[5]+deduction;
            total[5]=total[5]+deduction;

            List<string> fileLines = new List<string>();
            for (int i=0;i<bank.Count;i++)
            {
                string newString = $"{bank[i]};{gross[i]};{net[i]};{savings[i]};{welfare[i]};{housing[i]};{needs[i]};{disposibleIncome[i]};{totalInForDate[i]};{tottalOutForDate[i]};{total[i]}";
                fileLines.Add(newString);
                continue;
            }
            SaveToFile2(fileLines);
        }
        else if (usedMoney == 3)//Housing
        {
            net[a]=net[a]-deduction;//UCCU
            housing[a]=housing[a]-deduction;
            tottalOutForDate[a]=tottalOutForDate[a]+deduction;
            total[a]=total[a]-deduction;
            housing[5]=housing[5]+deduction;
            tottalOutForDate[5]=tottalOutForDate[5]+deduction;
            total[5]=total[5]+deduction;

            List<string> fileLines = new List<string>();
            for (int i=0;i<bank.Count;i++)
            {
                string newString = $"{bank[i]};{gross[i]};{net[i]};{savings[i]};{welfare[i]};{housing[i]};{needs[i]};{disposibleIncome[i]};{totalInForDate[i]};{tottalOutForDate[i]};{total[i]}";
                fileLines.Add(newString);
                continue;
            }
            SaveToFile2(fileLines);
        }
        else if (usedMoney == 4)//Needs
        {
            net[a]=net[a]-deduction;//UCCU
            needs[a]=needs[a]-deduction;
            tottalOutForDate[a]=tottalOutForDate[a]+deduction;
            total[a]=total[a]-deduction;
            needs[5]=needs[5]+deduction;
            tottalOutForDate[5]=tottalOutForDate[5]+deduction;
            total[5]=total[5]+deduction;

            List<string> fileLines = new List<string>();
            for (int i=0;i<bank.Count;i++)
            {
                string newString = $"{bank[i]};{gross[i]};{net[i]};{savings[i]};{welfare[i]};{housing[i]};{needs[i]};{disposibleIncome[i]};{totalInForDate[i]};{tottalOutForDate[i]};{total[i]}";
                fileLines.Add(newString);
                continue;
            }
            SaveToFile2(fileLines);
        }
        else if (usedMoney == 5)//Disposible Income
        {
            net[a]=net[a]-deduction;//UCCU
            disposibleIncome[a]=disposibleIncome[a]-deduction;
            tottalOutForDate[a]=tottalOutForDate[a]+deduction;
            total[a]=total[a]-deduction;
            disposibleIncome[5]=disposibleIncome[5]+deduction;
            tottalOutForDate[5]=tottalOutForDate[5]+deduction;
            total[5]=total[5]+deduction;

            List<string> fileLines = new List<string>();
            for (int i=0;i<bank.Count;i++)
            {
                string newString = $"{bank[i]};{gross[i]};{net[i]};{savings[i]};{welfare[i]};{housing[i]};{needs[i]};{disposibleIncome[i]};{totalInForDate[i]};{tottalOutForDate[i]};{total[i]}";
                fileLines.Add(newString);
                continue;
            }
            SaveToFile2(fileLines);
        }
        else
        {
            Console.WriteLine("Please choose one of the options next time.");
        }
    }
    else if (bankChoice == 2)//For Umpqua
    {
        Console.WriteLine("Umpqua");
        int a = 1;
        if (usedMoney == 1)//Savings
        {
            net[a]=net[a]-deduction;
            savings[a]=savings[a]-deduction;
            tottalOutForDate[a]=tottalOutForDate[a]+deduction;
            total[a]=total[a]-deduction;
            savings[5]=savings[5]+deduction;
            tottalOutForDate[5]=tottalOutForDate[5]+deduction;
            total[5]=total[5]+deduction;

            List<string> fileLines = new List<string>();
            for (int i=0;i<bank.Count;i++)
            {
                string newString = $"{bank[i]};{gross[i]};{net[i]};{savings[i]};{welfare[i]};{housing[i]};{needs[i]};{disposibleIncome[i]};{totalInForDate[i]};{tottalOutForDate[i]};{total[i]}";
                fileLines.Add(newString);
                continue;
            }
            SaveToFile2(fileLines);
        }
        else if (usedMoney == 2)//Welfare
        {
            net[a]=net[a]-deduction;
            welfare[a]=welfare[a]-deduction;
            tottalOutForDate[a]=tottalOutForDate[a]+deduction;
            total[a]=total[a]-deduction;
            welfare[5]=welfare[5]+deduction;
            tottalOutForDate[5]=tottalOutForDate[5]+deduction;
            total[5]=total[5]+deduction;

            List<string> fileLines = new List<string>();
            for (int i=0;i<bank.Count;i++)
            {
                string newString = $"{bank[i]};{gross[i]};{net[i]};{savings[i]};{welfare[i]};{housing[i]};{needs[i]};{disposibleIncome[i]};{totalInForDate[i]};{tottalOutForDate[i]};{total[i]}";
                fileLines.Add(newString);
                continue;
            }
            SaveToFile2(fileLines);
        }
        else if (usedMoney == 3)//Housing
        {
            net[a]=net[a]-deduction;
            housing[a]=housing[a]-deduction;
            tottalOutForDate[a]=tottalOutForDate[a]+deduction;
            total[a]=total[a]-deduction;
            housing[5]=housing[5]+deduction;
            tottalOutForDate[5]=tottalOutForDate[5]+deduction;
            total[5]=total[5]+deduction;

            List<string> fileLines = new List<string>();
            for (int i=0;i<bank.Count;i++)
            {
                string newString = $"{bank[i]};{gross[i]};{net[i]};{savings[i]};{welfare[i]};{housing[i]};{needs[i]};{disposibleIncome[i]};{totalInForDate[i]};{tottalOutForDate[i]};{total[i]}";
                fileLines.Add(newString);
                continue;
            }
            SaveToFile2(fileLines);
        }
        else if (usedMoney == 4)//Needs
        {
            net[a]=net[a]-deduction;
            needs[a]=needs[a]-deduction;
            tottalOutForDate[a]=tottalOutForDate[a]+deduction;
            total[a]=total[a]-deduction;
            needs[5]=needs[5]+deduction;
            tottalOutForDate[5]=tottalOutForDate[5]+deduction;
            total[5]=total[5]+deduction;

            List<string> fileLines = new List<string>();
            for (int i=0;i<bank.Count;i++)
            {
                string newString = $"{bank[i]};{gross[i]};{net[i]};{savings[i]};{welfare[i]};{housing[i]};{needs[i]};{disposibleIncome[i]};{totalInForDate[i]};{tottalOutForDate[i]};{total[i]}";
                fileLines.Add(newString);
                continue;
            }
            SaveToFile2(fileLines);
        }
        else if (usedMoney == 5)//Disposible Income
        {
            net[a]=net[a]-deduction;
            disposibleIncome[a]=disposibleIncome[a]-deduction;
            tottalOutForDate[a]=tottalOutForDate[a]+deduction;
            total[a]=total[a]-deduction;
            disposibleIncome[5]=disposibleIncome[5]+deduction;
            tottalOutForDate[5]=tottalOutForDate[5]+deduction;
            total[5]=total[5]+deduction;

            List<string> fileLines = new List<string>();
            for (int i=0;i<bank.Count;i++)
            {
                string newString = $"{bank[i]};{gross[i]};{net[i]};{savings[i]};{welfare[i]};{housing[i]};{needs[i]};{disposibleIncome[i]};{totalInForDate[i]};{tottalOutForDate[i]};{total[i]}";
                fileLines.Add(newString);
                continue;
            }
            SaveToFile2(fileLines);
        }
        else
        {
            Console.WriteLine("Please choose one of the options next time.");
        }
    }
    else if(bankChoice == 3) //Cash
    {
        Console.WriteLine("Cash");
        int a = 2;
        if (usedMoney == 1)//Savings
        {
            net[a]=net[a]-deduction;
            savings[a]=savings[a]-deduction;
            tottalOutForDate[a]=tottalOutForDate[a]+deduction;
            total[a]=total[a]-deduction;
            savings[5]=savings[5]+deduction;
            tottalOutForDate[5]=tottalOutForDate[5]+deduction;
            total[5]=total[5]+deduction;

            List<string> fileLines = new List<string>();
            for (int i=0;i<bank.Count;i++)
            {
                string newString = $"{bank[i]};{gross[i]};{net[i]};{savings[i]};{welfare[i]};{housing[i]};{needs[i]};{disposibleIncome[i]};{totalInForDate[i]};{tottalOutForDate[i]};{total[i]}";
                fileLines.Add(newString);
                continue;
            }
            SaveToFile2(fileLines);
        }
        else if (usedMoney == 2)//Welfare
        {
            net[a]=net[a]-deduction;
            welfare[a]=welfare[a]-deduction;
            tottalOutForDate[a]=tottalOutForDate[a]+deduction;
            total[a]=total[a]-deduction;
            welfare[5]=welfare[5]+deduction;
            tottalOutForDate[5]=tottalOutForDate[5]+deduction;
            total[5]=total[5]+deduction;

            List<string> fileLines = new List<string>();
            for (int i=0;i<bank.Count;i++)
            {
                string newString = $"{bank[i]};{gross[i]};{net[i]};{savings[i]};{welfare[i]};{housing[i]};{needs[i]};{disposibleIncome[i]};{totalInForDate[i]};{tottalOutForDate[i]};{total[i]}";
                fileLines.Add(newString);
                continue;
            }
            SaveToFile2(fileLines);
        }
        else if (usedMoney == 3)//Housing
        {
            net[a]=net[a]-deduction;
            housing[a]=housing[a]-deduction;
            tottalOutForDate[a]=tottalOutForDate[a]+deduction;
            total[a]=total[a]-deduction;
            housing[5]=housing[5]+deduction;
            tottalOutForDate[5]=tottalOutForDate[5]+deduction;
            total[5]=total[5]+deduction;

            List<string> fileLines = new List<string>();
            for (int i=0;i<bank.Count;i++)
            {
                string newString = $"{bank[i]};{gross[i]};{net[i]};{savings[i]};{welfare[i]};{housing[i]};{needs[i]};{disposibleIncome[i]};{totalInForDate[i]};{tottalOutForDate[i]};{total[i]}";
                fileLines.Add(newString);
                continue;
            }
            SaveToFile2(fileLines);
        }
        else if (usedMoney == 4)//Needs
        {
            net[a]=net[a]-deduction;
            needs[a]=needs[a]-deduction;
            tottalOutForDate[a]=tottalOutForDate[a]+deduction;
            total[a]=total[a]-deduction;
            needs[5]=needs[5]+deduction;
            tottalOutForDate[5]=tottalOutForDate[5]+deduction;
            total[5]=total[5]+deduction;

            List<string> fileLines = new List<string>();
            for (int i=0;i<bank.Count;i++)
            {
                string newString = $"{bank[i]};{gross[i]};{net[i]};{savings[i]};{welfare[i]};{housing[i]};{needs[i]};{disposibleIncome[i]};{totalInForDate[i]};{tottalOutForDate[i]};{total[i]}";
                fileLines.Add(newString);
                continue;
            }
            SaveToFile2(fileLines);
        }
        else if (usedMoney == 5)//Disposible Income
        {
            net[a]=net[a]-deduction;
            disposibleIncome[a]=disposibleIncome[a]-deduction;
            tottalOutForDate[a]=tottalOutForDate[a]+deduction;
            total[a]=total[a]-deduction;
            disposibleIncome[5]=disposibleIncome[5]+deduction;
            tottalOutForDate[5]=tottalOutForDate[5]+deduction;
            total[5]=total[5]+deduction;
            
            List<string> fileLines = new List<string>();
            for (int i=0;i<bank.Count;i++)
            {
                string newString = $"{bank[i]};{gross[i]};{net[i]};{savings[i]};{welfare[i]};{housing[i]};{needs[i]};{disposibleIncome[i]};{totalInForDate[i]};{tottalOutForDate[i]};{total[i]}";
                fileLines.Add(newString);
                continue;
            }
            SaveToFile2(fileLines);
        }
        else
        {
            Console.WriteLine("Please choose one of the options next time.");
        }
    }
    else
    {
        Console.WriteLine("Please choose '1','2' or '3' next time");
    }
}
else
{
    Console.WriteLine("That don't work.  Next time pick '1' or '2'");
}
LoadStatement();

static void SaveToFile2 (List<string> lineToSave)
{
    File.WriteAllLines("income.txt", lineToSave);
}

void LoadStatement ()
{
    Console.Clear();
    Console.WriteLine("Reece Williams' Income Statement:\nBank, Gross, Net, Saving, Welfare, Housing, Needs, Disp. Income, Total-In, Total-Out, Total");
    string[] newStatement = File.ReadAllLines("income.txt");
    foreach (string junk in newStatement)
    {
        Console.WriteLine(junk);
    }
}


//Console.WriteLine($"{bank[0]},{gross[0]}\n{bank[1]},{gross[1]}\n{bank[2]},{gross[2]}");