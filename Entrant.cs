namespace pract_18_19;
public class Entrant:Person 
{
    
    public Entrant() {
        lastName = "";
        faculty = "";
    }
    public Entrant(string lastName, int day, int month, int year, string faculty) {
        this.lastName = lastName;
        this.faculty = faculty;
        this.dateOfBirth = new DateOnly(year, month, day);
    }
    
    public override void ShowInfoAboutPerson()
    {
        Console.WriteLine("Абитуриент {0}", lastName);
        Console.WriteLine("Факультет: {0}", faculty);
        Console.WriteLine("Дата рождения: {0}", dateOfBirth.ToString("dd.MM.yyyy"));
        Console.WriteLine();
    }
    public override void WritePersonInFile(StreamWriter fileOut)
    {
        fileOut.WriteLine("Абитуриент {0}", lastName);
        fileOut.WriteLine("Факультет: {0}", faculty);
        fileOut.WriteLine("Дата рождения: {0}", dateOfBirth.ToString("dd.MM.yyyy"));
        fileOut.WriteLine();
    }
}
