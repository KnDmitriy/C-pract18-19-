namespace pract_18_19;
class Program
{
    static int[] GetSplittedIntDate(string date) { //date фармата dd.mm.yyyy
        char[] div = {'.'};
        string[] splittedDate = date.Split(div);
        int[] splittedIntDate = new int[3];
        splittedIntDate[0] = int.Parse(splittedDate[0]) ;
        splittedIntDate[1] = int.Parse(splittedDate[1]);
        splittedIntDate[2] = int.Parse(splittedDate[2]);
        return splittedIntDate;
    }
    static void Main(string[] args)
    {
         using (StreamReader fileIn = new StreamReader(@"/Users/DmitryKonorov/StudyProjectsC#_3d_semester/pract_18-19/input.txt"))
        {
            using (StreamWriter fileOut = new StreamWriter(@"/Users/DmitryKonorov/StudyProjectsC#_3d_semester/pract_18-19/output_pract_18-19.txt", false))
            {
                char[] div1 = { '\n', '\t', '\v', '\r' };
                char[] div2 = { '|' };
                char[] div3 = {'-'};
                string[] ageRange = fileIn.ReadLine().Split(div3);
                byte lowAgeBound = byte.Parse(ageRange[0]);
                byte upperAgeBound = byte.Parse(ageRange[1]);
                string line = fileIn.ReadToEnd();
                string[] personsInString = line.Split(div1, StringSplitOptions.RemoveEmptyEntries);
                Person[] persons = new Person[personsInString.Length];
                for (int i = 0; i < personsInString.Length; ++i)
                {
                    string[] specificationsOfPersonInString = personsInString[i].Split(div2, StringSplitOptions.RemoveEmptyEntries);
                    int[] splittedIntDate = GetSplittedIntDate(specificationsOfPersonInString[1]);
                    if(specificationsOfPersonInString.Length == 3)//person - абитуриент
                    {
                        persons[i] = new Entrant(specificationsOfPersonInString[0], splittedIntDate[0],
                            splittedIntDate[1], splittedIntDate[2], specificationsOfPersonInString[2]);
                    }
                    else if(specificationsOfPersonInString.Length == 4){
                        persons[i] = new Student(specificationsOfPersonInString[0], splittedIntDate[0],
                            splittedIntDate[1], splittedIntDate[2], specificationsOfPersonInString[2], 
                            byte.Parse(specificationsOfPersonInString[3]));
                    }
                    else if(specificationsOfPersonInString.Length == 5){
                        persons[i] = new Teacher(specificationsOfPersonInString[0], splittedIntDate[0],
                            splittedIntDate[1], splittedIntDate[2], specificationsOfPersonInString[2], 
                            specificationsOfPersonInString[3], byte.Parse(specificationsOfPersonInString[4]));
                    }
                    else {
                        Console.WriteLine("Неверно введены данные во входном файле для {0}-го человека", i);
                    }
                }
               
                var resPersons = from pers in persons
                                    where pers.GetAgeAtTheMoment() > lowAgeBound && pers.GetAgeAtTheMoment() < upperAgeBound
                                    select pers;

                foreach(var pers in persons){
                    pers.WritePersonInFile(fileOut);
                }
                fileOut.WriteLine();
                fileOut.WriteLine();
                fileOut.WriteLine();
                fileOut.WriteLine("{0}-{1}", lowAgeBound, upperAgeBound);
                foreach(var pers in resPersons){
                    pers.WritePersonInFile(fileOut);
                }
                
               
            }
        }
    }
}
