public class DeveloperRepository
{
    //make a fake database -> List<T> to do so 
    private readonly List<Developer> _developerDb = new List<Developer>();

    // database counter gives new id number
    private int _count;

    // C    R   U   D

    //c

    public bool AddDeveloperToDatabase(Developer developer)
    {
        if (developer is null)
        {
            return false;
        }
        else
        {
            _count++;
            developer.Id = _count;
            _developerDb.Add(developer);
            return true;
        }
    }


    //R

    public List<Developer> GetAllDeveloperData()
    {
        return _developerDb;
    }

    //r
    //helpermethod
    public Developer GetDeveloperData(int developerId)
    {

        foreach (Developer d in _developerDb)
        {
            if (d.Id == developerId)
            {
                return d;

            }
        }
        return null;
    }

    //U update

    public bool UpdateDeveloperData(int developerId, Developer updatedDeveloperData)
    {
        //find developer in database
        Developer developerInDb = GetDeveloperData(developerId);

        //check to see if the developer exists

        if (developerInDb != null)
        {
            developerInDb.FirstName = updatedDeveloperData.FirstName;
            developerInDb.LastName = updatedDeveloperData.LastName;
            developerInDb.DeveloperType = updatedDeveloperData.DeveloperType;
            developerInDb.HasPluralSight = updatedDeveloperData.HasPluralSight;

            return true;
        }
        return false;
    }

    //d 

    public bool DeleteDeveloperData(int developerId)
    {
        //find developer in database
        Developer developerInDb = GetDeveloperData(developerId);

        //check to see if the developer actually exists
        if (developerInDb != null)
        {
            return _developerDb.Remove(developerInDb);
        }
        return false;
    }
}
