namespace Assignment4_Scorecard
{
    class Student
    {
        public int RollNo { get; set; }
        public string Name { get; set; }
        public int Math { get; set; }
        public int Science { get; set; }
        public int English { get; set; }
        public int Language { get; set; }
        public int SST { get; set; }
        public int Totalscore { get; set; }
        public double Averagescore { get; set; }
        public bool Iscleared;
        public char Grade;
    }

    class ScoreCard
    {
        int n = 0;
        Student[] students;
        public void AcceptDetails()
        {
            Console.WriteLine("Enter the number of students");
            n = Convert.ToInt16(Console.ReadLine());
            students = new Student[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter Details for Student {i + 1}");
                Console.WriteLine("Enter Roll No");
                int rollno = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Enter Student Name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Marks for Maths");
                int maths = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Enter Marks for Science");
                int science = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Enter Marks for English");
                int english = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Enter Marks for Language");
                int lang = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Enter Marks for SST");
                int sst = Convert.ToInt16(Console.ReadLine());
                int sum = maths + science + english + lang + sst;
                int average = sum / 5;
                bool passstatus = false;
                if (maths >= 35 && science >= 35 && english >= 35 && lang >= 35 && sst >= 35)
                {
                    passstatus = true;
                }
                students[i] = new Student() { RollNo = rollno, Name = name, Math = maths, Science = science, English = english, Language = lang, SST = sst, Totalscore = sum, Averagescore = average, Iscleared = passstatus };
            }
        }

        public void Topscorer()
        {
            int topscore = 0;
            int topscoreindex = 0;
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].Totalscore > topscore)
                {
                    topscore = students[i].Totalscore;
                    topscoreindex = i;
                }
            }
            Console.WriteLine($"Top scorer: {students[topscoreindex].Name}, Roll No: {students[topscoreindex].RollNo}");

        }
        public void Passedstudents()
        {

            int passstudentindex = 0;
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].Iscleared)
                {

                    passstudentindex = i;
                    Console.WriteLine($"{students[passstudentindex].Name} with rollno {students[passstudentindex].RollNo} cleared the exam");
                }

            }
            // Console.WriteLine($"{students[passstudentindex].Name} with rollno {students[passstudentindex].RollNo} cleared the exam");
        }
        public void Grade()
        {
            char grade;
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].Averagescore > 95)
                {
                    grade = 'A';
                    students[i].Grade = grade;

                }
                else if (students[i].Averagescore >= 80 && students[i].Averagescore < 95)
                {
                    grade = 'B';
                    students[i].Grade = grade;

                }
                else if (students[i].Averagescore >= 70 && students[i].Averagescore < 80)
                {
                    grade = 'C';
                    students[i].Grade = grade;
                }
                else if (students[i].Averagescore >= 60 && students[i].Averagescore < 70)
                {
                    grade = 'D';
                    students[i].Grade = grade;
                }
                else if (students[i].Averagescore >= 50 && students[i].Averagescore < 60)
                {
                    grade = 'E';
                    students[i].Grade = grade;
                }
                else if (students[i].Averagescore < 50)
                {
                    grade = 'F';
                    students[i].Grade = grade;
                }
                Console.WriteLine($"{students[i].Name}----grade {students[i].Grade}------average {students[i].Averagescore}");


            }

        }
        public void repeatexam()
        {
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].Iscleared == false)
                {
                    Console.WriteLine($"{students[i].Name},{students[i].RollNo} Has to reappear the exam ");
                }

            }

        }
        public void scorecard()
        {
            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine($"                   {students[i].Name}    SCORECARD");
                Console.WriteLine($"Name:  {students[i].Name}");
                Console.WriteLine($"Rollno:  {students[i].RollNo}");
                Console.WriteLine($"Maths Marks:  {students[i].Math}");
                Console.WriteLine($"Science Marks:  {students[i].Science}");
                Console.WriteLine($"English Marks:  {students[i].English}");
                Console.WriteLine($"Language marks:  {students[i].Language}");
                Console.WriteLine($"Social Studies Marks:  {students[i].SST}");
                Console.WriteLine($"Totalmarks:  {students[i].Totalscore}");
                Console.WriteLine($"grade:  {students[i].Grade}");
            }

        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ScoreCard card = new ScoreCard();
            card.AcceptDetails();
            //card.ShowDetails();
            card.Topscorer();
            card.Passedstudents();
            card.repeatexam();
            card.Grade();

            card.scorecard();

        }
    }
}
