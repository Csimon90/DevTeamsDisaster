using static System.Console;
using System;

public class Program_UI
{
    private readonly DeveloperRepository _gRepo = new DeveloperRepository();

    public void Run()
    {
        SeedData();
        RunApplication();
    }

    private void RunApplication()
    {
        Clear();
        bool isRunning = true;
        while (isRunning)
        {
            WriteLine("Welcome To Komodo Developer Teams\n" +
                "Please Make A Selection\n" +
                "1. Add Developer To Database\n" +
                "2. See All Developers\n" +
                "3. See A Developer\n" +
                "4. Update Existing Developer Data\n" +
                "5. Delete Existing Developer Data\n" +
                "0. Exit Application\n");

            string userInput = ReadLine();

            switch (userInput)
            {
                case "1":
                case "One":
                case "one":
                case "ONE":
                    AddDeveloperToDatabase();
                    break;
                case "2":
                    SeeAllDevelopers();
                    break;
                case "3":
                    SeeADeveloper();
                    break;
                case "4":
                    UpdateExistingDeveloperData();
                    break;
                case "5":
                    DeleteExistingDeveloperData();
                    break;
                case "0":
                    isRunning = ExitApplication();
                    break;
                default:
                    WriteLine("Invalid Selection, Please try again.");
                    PressAnyKeyToContinue();
                    break;
            }
        }

    }

    private bool ExitApplication()
    {
        Clear();
        WriteLine("Thanks for using Komodo DevTeams.");
        PressAnyKeyToContinue();
        return false;
    }

    private void DeleteExistingDeveloperData()
    {
        Clear();
        WriteLine("Please input an Existing Developer Id:");
        int userInput = int.Parse(ReadLine());
        Developer Developer = _gRepo.GetDeveloperData(userInput);
        if (Developer is null)
        {
            WriteLine($"Sorry the developer with the id: {userInput} doesn't exist.");
        }
        else
        {
            if (_gRepo.DeleteDeveloperData(Developer.Id))
            {
                WriteLine("SUCCESS!");
            }
            else
            {
                WriteLine("FAIL!");
            }
        }
        ReadKey();
    }

    private void UpdateExistingDeveloperData()
    {
        Clear();
        WriteLine("Please input an Existing Developer Id:");
        int userInput = int.Parse(ReadLine());
        Developer Developer = _gRepo.GetDeveloperData(userInput);
        if (Developer is null)
        {
            WriteLine($"Sorry the developer with the id: {userInput} doesn't exist.");
        }
        else
        {
            Developer updatedDeveloper = new Developer();

            WriteLine("Please enter the Developer's First Name.");
            updatedDeveloper.FirstName = ReadLine();

            WriteLine("Please enter the Developer's Last Name.");
            updatedDeveloper.LastName = ReadLine();

            WriteLine("Please input a the Developer's Type\n" +
            "0. BackEnd\n" +
            "1. FrontEnd\n" +
            "2. Manager\n");

            userInput = int.Parse(ReadLine());
            updatedDeveloper.DeveloperType = (DeveloperType)userInput;

            WriteLine("Does this developer have PluralSight? y/n");

            string userInputHKA = ReadLine();
            if (userInputHKA == "Y".ToLower())
            {
                updatedDeveloper.HasPluralSight = true;
            }
            else
            {
                updatedDeveloper.HasPluralSight = false;
                WriteLine("Developer Must sign up for PluralSight before beginning work duties.");
                
            }

            if (_gRepo.UpdateDeveloperData(Developer.Id, updatedDeveloper))
            {
                WriteLine("Update was successful! ^_^");
            }
            else
            {
                WriteLine("Update was unsuccessful. Check your entry and try again. ");
            }
        }
        ReadKey();
    }

    private void SeeADeveloper()
    {
        Clear();
        WriteLine("== Developer Listing ==");
        WriteLine("Please input an Existing Developer Id:");
        int userInput = int.Parse(ReadLine());
        Developer Developer = _gRepo.GetDeveloperData(userInput);
        DisplayDeveloperData(Developer);
        ReadKey();
    }

    private void SeeAllDevelopers()
    {
        Clear();
        WriteLine("== Developer Listing ==");
        //grab all the Developers in our Db
        List<Developer> DevelopersInDb = _gRepo.GetAllDeveloperData();
        //loop through and display Developer data
        foreach (Developer d in DevelopersInDb)
        {
            DisplayDeveloperData(d);
        }
        ReadLine();
    }

    private void DisplayDeveloperData(Developer d)
    {
        WriteLine($"FullName: {d.FullName}\n" +
                $"DeveloperType: {d.DeveloperType}\n" +
                $"Has PluralSight: {d.HasPluralSight}\n" +
                "------------------------------------------\n");
    }

    private void AddDeveloperToDatabase()
    {
        Clear();
        Developer Developer = new Developer();

        WriteLine("Please enter the Developer's First Name.");
        Developer.FirstName = ReadLine();

        WriteLine("Please enter the Developer's Last Name.");
        Developer.LastName = ReadLine();

        WriteLine("Please input a the Developers Type\n" +
        "0. Manager\n" +
        "1. FrontEnd\n" +
        "2. BackEnd\n");

        int userInput = int.Parse(ReadLine());
        Developer.DeveloperType = (DeveloperType)userInput;

        WriteLine("Does this Developer have PluralSight? y/n");

        string userInputHKA = ReadLine();
        if (userInputHKA == "Y".ToLower())
        {
            Developer.HasPluralSight = true;
        }
        else
        {
            
            Developer.HasPluralSight = false;
            {
            WriteLine("Developer must sign up for PluralSight before beginning work duties.");
            }
        }

        //the form is filled out, so we need to add the Developer to the Db
        if (_gRepo.AddDeveloperToDatabase(Developer))
        {
            WriteLine($"{Developer.FullName} was added to the Database!");
        }
        else
        {
            WriteLine("Sorry, Invalid Database Operation.");
        }

        ReadLine();
    }

    private void PressAnyKeyToContinue()
    {
        WriteLine("Press any Key to Continue.");
        ReadKey();
    }

    private void SeedData()
    {
        //create some data and store it in the Db
        Developer DeveloperA = new Developer("Bill", "Esquire", DeveloperType.FrontEnd, false);
        Developer DeveloperB = new Developer("Ted", "Theodore Reagan", DeveloperType.BackEnd, false);
        Developer DeveloperC = new Developer("Stripe", "...", DeveloperType.Manager, true);

        //add them to db...
        _gRepo.AddDeveloperToDatabase(DeveloperA);
        _gRepo.AddDeveloperToDatabase(DeveloperB);
        _gRepo.AddDeveloperToDatabase(DeveloperC);
    }
}
