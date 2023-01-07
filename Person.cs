namespace pract_18_19;
abstract public class Person:IComparable
{
    internal string lastName, faculty;
    internal DateOnly dateOfBirth;
    abstract public void ShowInfoAboutPerson();
    abstract public void WritePersonInFile(StreamWriter fileOut);
    public int GetAgeAtTheMoment()
    {
        int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
        int dob = int.Parse(dateOfBirth.ToString("yyyyMMdd"));
        int age = (now - dob) / 10000;//отбрасываем последние 4 цифры числа
        return age;   
    }
    public int CompareTo(object obj) {
        Person person = (Person) obj;
        if(this.dateOfBirth == person.dateOfBirth)
        {
            return 0;
        }
        else
        {
            if (this.dateOfBirth > person.dateOfBirth){
                return 1;
            }
            else {
                return -1;
            }
        }
    }
    public static bool operator ==(Person a, Person b)
    {
        return (a.dateOfBirth.CompareTo(b)==0);
    }
    
    public static bool operator !=(Person a, Person b)
    {
        return (a.dateOfBirth.CompareTo(b)!=0);
    }
    public static bool operator <(Person a, Person b)
    {
        return (a.dateOfBirth.CompareTo(b) == -1);
    }
    public static bool operator >(Person a, Person b)
    {
        return (a.dateOfBirth.CompareTo(b) == 1);
    }
    
}