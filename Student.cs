namespace pract_18_19;
public class Student:Entrant
{
    byte course;
    public Student(string lastName, int day, int month, int year, string faculty, byte course) {
        this.lastName = lastName;
        this.faculty = faculty;
        this.course = course;
        this.dateOfBirth = new DateOnly(year, month, day);
    }
    public override void ShowInfoAboutPerson()
    {
        Console.WriteLine("Студент {0}", lastName);
        Console.WriteLine("Дата рождения: {0}", dateOfBirth.ToString("dd.MM.yyyy"));
        Console.WriteLine("Факультет: {0}", faculty);
        Console.WriteLine("{0} курс", course);
        Console.WriteLine();
    }
    public override void WritePersonInFile(StreamWriter fileOut)
    {
        fileOut.WriteLine("Студент {0}", lastName);
        fileOut.WriteLine("Дата рождения: {0}", dateOfBirth.ToString("dd.MM.yyyy"));
        fileOut.WriteLine("Факультет: {0}", faculty);
        fileOut.WriteLine("{0} курс", course);
        fileOut.WriteLine();
    }
}