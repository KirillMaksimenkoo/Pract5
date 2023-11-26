using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Pract5
{
    public class Student:IComparable
    {

        string name = "";
        string sname = "";
        string fname = "";
        int year = 0;
        string school = "";

        public Student(string Name, string Sname, string Fname, int year, string school)
        {
            this.name = Name;
            this.sname = Sname;
            this.fname = Fname;
            this.year = year;
            this.school = school;
        }

        public Student() {
            this.name = "Кирило";
            this.sname = "Максименко";
            this.fname = "Андрійович";
            this.year = 2005;
            this.school = "Ліцей Політ";
        }

        public string Name { get { return this.name; } set { this.name = value; } }
        public string Sname { get { return this.sname; } set { this.sname = value; } }
        public string Fname { get { return this.fname; } set { this.fname = value; } }
        public string School { get { return this.school; } set { this.school = value; } }
        public int Year { get { return this.year;}
        set { if (value > 0)
                    this.year = value; 
            }
        }
        

        public int CompareTo(object obj)
        {
            Student student = obj as Student;
            return year.CompareTo(student.Year);
        }
    }

    class SortByYear : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            if (x.Year < y.Year) return -1;
            if (x.Year > y.Year) return 1;
            return 0;
        }
    }


    public class Students
    {
        public List<Student> students = new List<Student>();
        XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));

        public void add(Student student)
        {
            students.Add(student);
        }

        public void remove(int i)
        {
            students.RemoveAt(i);
        }

        public void sort()
        {
            SortByYear sby = new SortByYear();
            students.Sort(sby);
        }

        public void writeFile(string FileName)
        {
            FileStream fstream = new FileStream(FileName, FileMode.Create,
                FileAccess.Write, FileShare.None);
            serializer.Serialize(fstream, students);
            fstream.Close();
        }

        public void readFile(string FileName)
        {
            FileStream fstream = new FileStream(FileName, FileMode.Open,
                FileAccess.Read, FileShare.None);
            students = serializer.Deserialize(fstream) as List<Student>;
            fstream.Close();
        }

    }

}
