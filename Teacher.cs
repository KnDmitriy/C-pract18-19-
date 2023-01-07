namespace pract_18_19;
public class Teacher:Person 
{
    private string post;
    private byte expirience;//в годах
    public Teacher(string lastName, int day, int month, int year, string faculty, string post, byte expirience){
        this.lastName = lastName;
        this.dateOfBirth = new DateOnly(year, month, day);
        this.faculty = faculty;
        this.post = post;
        this.expirience = expirience;

    }
    public override void ShowInfoAboutPerson() {
        Console.WriteLine("Преподаватель {0}", lastName);
        Console.WriteLine("Факультет: {0}", faculty);
        Console.WriteLine("Дата рождения: {0}", dateOfBirth.ToString("dd.MM.yyyy"));
        Console.WriteLine("Должность: {0}", post);
        Console.WriteLine("Стаж {0} лет", expirience);
        Console.WriteLine();
    }
    public override void WritePersonInFile(StreamWriter fileOut)
    {
        fileOut.WriteLine("Преподаватель {0}", lastName);
        fileOut.WriteLine("Факультет: {0}", faculty);
        fileOut.WriteLine("Дата рождения: {0}", dateOfBirth.ToString("dd.MM.yyyy"));
        fileOut.WriteLine("Должность: {0}", post);
        fileOut.WriteLine("Стаж {0} лет", expirience);
        fileOut.WriteLine();
    }

}