namespace Assignment4_Scorecard
{   class Student
    {
        public string Name { get; set; }
        public int RollNo { get; set; }
        public int Maths { get; set; }
        public int Science { get; set; }
        public int English { get; set; }
        public int Language { get; set; }
        public int SocialStudies { get; set; }
        public int TotalMarks { get; set; }

        public bool IsPassed()
        {
            return (Maths >= 35 && Science >= 35 && English >= 35 && Language >= 35 && SocialStudies >= 35);
        }

    }

    class ScoreCard
    {
        Student[] students;
        public void EnterDetails()
        {
            Console.Write("Enter the number of students: ");
            int num = Convert.ToInt16(Console.ReadLine());

            students = new Student[num];

            for (int i = 0; i < num; i++)
            {
                Console.WriteLine($"Enter Details for Student {i + 1}");
                Console.WriteLine("Enter Student Name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Roll No");
                int rollno = Convert.ToInt16(Console.ReadLine());  
                Console.WriteLine("Enter Marks for below:");
                Console.WriteLine("Maths");
                int maths = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Science");
                int science = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("English");
                int english = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Language");
                int lang = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("SocialStudies");
                int sst = Convert.ToInt16(Console.ReadLine());
                int total = maths + science + english + lang + sst;
                students[i] = new Student() { RollNo = rollno, Name = name, Maths = maths, Science = science, English = english, Language = lang, SocialStudies = sst, TotalMarks = total };
            }
        }

        public void ViewDetails()
        {
            int sum = 0;
            int max = 0;
            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine($"Roll No: {students[i].RollNo} Name: {students[i].Name}");
                Console.WriteLine($"Math: {students[i].Maths}, Science: {students[i].Science}, English: {students[i].English}, Language: {students[i].Language}, SST: {students[i].SocialStudies}");
                Console.WriteLine($"Total Marks: {students[i].TotalMarks}");

            }
            // Top scorer in the class
            int maxMarks = 0;
            string topScorerName = "";
            int topScorerRollNo = 0;

            foreach (Student student in students)
            {
                if (student.TotalMarks > maxMarks)
                {
                    maxMarks = student.TotalMarks;
                    topScorerName = student.Name;
                    topScorerRollNo = student.RollNo;
                }
            }
            Console.WriteLine($"\nTop Scorer - Name: {topScorerName} ,Roll No.: {topScorerRollNo}, Total Marks: {maxMarks}");

            // Average marks in each subject
            double avgMath = 0, avgScience = 0, avgEnglish = 0, avgLanguage = 0, avgSST = 0;

            foreach (Student student in students)
            {
                avgMath += student.Maths;
                avgScience += student.Science;
                avgEnglish += student.English;
                avgLanguage += student.Language;
                avgSST += student.SocialStudies;
            }

            avgMath = (avgMath/students.Length);
            avgScience = (avgScience/students.Length);
            avgEnglish = (avgEnglish/students.Length);
            avgLanguage = (avgLanguage/students.Length);
            avgSST = (avgSST/students.Length);

            Console.WriteLine($"\nAverage Marks in each Subject - \nMath    \t:{avgMath:F2}\nScience\t\t:{avgScience:F2}\nEnglish\t\t:{avgEnglish:F2}\nLanguage\t:{avgLanguage:F2}\nSocial Studies\t:{avgSST:F2}");

            // Number of students who have cleared the examination            
            Console.WriteLine("\nStudents who have cleared the examination:");
            foreach (Student student in students)
            {
                if (student.Maths >= 35 && student.Science >= 35 && student.English >= 35 && student.Language >= 35 && student.SocialStudies >= 35)
                {
                    Console.WriteLine($"Name : {student.Name} ,Roll No : {student.RollNo}");
                }
            }

            // Display the number of students who failed
            int failedStudents = 0;
            for (int i = 0; i < students.Length; i++)
            {
                if (!students[i].IsPassed())
                {
                    failedStudents++;
                }
            }

            Console.WriteLine("\nNumber of students who need to mandatorily repeat the examination: {0}", failedStudents);
            Console.WriteLine("\nDetails of students who need to mandatorily repeat the examination:");
            Console.WriteLine("RollNo\tName");
            for (int i = 0; i < students.Length; i++)
            {
                if (!students[i].IsPassed())
                {
                    Console.WriteLine("{0}\t{1}", students[i].RollNo, students[i].Name);
                }
            }
            Console.WriteLine();
        }

        public void StudentGrade()
        {
            string Grade = "A";
            foreach (Student student in students)
            {
                double studentAverage = 0;
                studentAverage = student.TotalMarks / 5;
                if (studentAverage >= 95)
                {
                    Grade = "A";
                }
                else if (studentAverage >= 80)
                {
                    Grade = "B";
                }
                else if (studentAverage >= 70)
                {
                    Grade = "C";
                }
                else if (studentAverage >= 60)
                {
                    Grade = "D";
                }
                else if (studentAverage >= 50)
                {
                    Grade = "E";
                }
                else
                {
                    Grade = "F";
                }
            }
            Console.WriteLine();
        }

        public void GradeCard(int roll)
        {
            Console.WriteLine("ScoreCard");
            foreach (Student student in students)
            {
                if (roll == student.RollNo)
                {
                    Console.WriteLine($"Name of the student: :{student.Name}");
                    Console.WriteLine($"Roll Number          :{student.RollNo}");
                    Console.WriteLine($"Math Marks           :{student.Maths}");
                    Console.WriteLine($"Science Marks        :{student.Science}");
                    Console.WriteLine($"English Marks        :{student.English}");
                    Console.WriteLine($"Language Marks       :{student.Language}");
                    Console.WriteLine($"Social Marks         :{student.SocialStudies}");
                    Console.WriteLine($"Total Marks Obtained :{student.TotalMarks}");
                    string Grade = "A";
                    double studentAverage = 0;
                    studentAverage = student.TotalMarks / 5;
                    if (studentAverage >= 95)
                    {
                        Grade = "A";
                    }
                    else if (studentAverage >= 80)
                    {
                        Grade = "B";
                    }
                    else if (studentAverage >= 70)
                    {
                        Grade = "C";
                    }
                    else if (studentAverage >= 60)
                    {
                        Grade = "D";
                    }
                    else if (studentAverage >= 50)
                    {
                        Grade = "E";
                    }
                    else
                    {
                        Grade = "F";
                    }
                    Console.WriteLine($"Grade Achived    \t:{Grade}");
                }

            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ScoreCard t = new ScoreCard();
            t.EnterDetails();
            t.ViewDetails();
            t.StudentGrade();
            Console.WriteLine("Enter a Roll Number:");
            int roll = Convert.ToInt16(Console.ReadLine());
            t.GradeCard(roll);
        }
    }
}