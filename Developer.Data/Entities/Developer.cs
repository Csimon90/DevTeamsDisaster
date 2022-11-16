public class Developer
{

    public Developer()
    {

    }
    //constructor
    public Developer(string firstName, string lastName, DeveloperType developerType, bool PluralSight)
    {
        FirstName = firstName;
        LastName = lastName;
        DeveloperType = developerType;
        HasPluralSight = HasPluralSight;
    }

    /*constructor
    public developer{string firstName, string lastName}
    {
        FirstName =firstName
        LastName =lastName
    }*/
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName
    {

        get
        {
            return $"{FirstName} {LastName}";
        }

    }


    public DeveloperType DeveloperType { get; set; }

    public bool HasPluralSight { get; set; }
}