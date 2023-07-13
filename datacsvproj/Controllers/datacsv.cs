using datacsvproj.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;
namespace datacsvproj.Controllers
{
    
    public class datacsv : Controller
    {
        public IActionResult Index()
        {
            string fileName = "C:\\evoke\\datacsvproj\\test.csv";
            FileInfo fileInfo = new FileInfo(fileName);
            List<data> stuList = new List<data>();
            using (StreamReader r = fileInfo.OpenText())
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    string[] values = line.Split(",");
                    data data = new data()
                    {
                        Rno = int.Parse(values[0]),
                        name = values[1],
                        mark1 = int.Parse(values[2]),
                        mark2 = int.Parse(values[3]),
                        total = int.Parse(values[4])
                    };
                    stuList.Add(data);
                }
            }
            return View(stuList);
            //return View();
        }



        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(data data) {
            string details = "";
            string? nameOfFile = @"C:\evoke\datacsvproj\test.csv";
            FileInfo fi = new FileInfo(nameOfFile);
            //fi.AppendText(data.rollno);

            details += data.Rno + ",";
            details += data.name + ",";
            details += data.mark1 + ",";
            details += data.mark2 + ",";
            details += data.mark1 + data.mark2;
            using (StreamWriter sw = fi.AppendText())
            {
                // sw.WriteLine("student_details");
                sw.WriteLine(details);
            }
            return RedirectToAction("Index");
        }

        private static data getStudent(int id)
        {
            string fileName = "C:\\evoke\\datacsvproj\\test.csv";
            FileInfo fileInfo = new FileInfo(fileName);
            data data = new data();
            using (StreamReader r = fileInfo.OpenText())
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    string[] values = line.Split(",");
                    if (int.Parse(values[0]) == id)
                    {
                        data.Rno = int.Parse(values[0]);
                        data.name = values[1];
                        data.mark1 = int.Parse(values[2]);
                        data.mark2 = int.Parse(values[3]);
                        data.total = int.Parse(values[4]);
                        break;
                    }
                }
            }



            return data;
        }


        public IActionResult Edit(int id)
        {   
            data data = getStudent(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(data data)
        {
            string details = "";
            string? nameOfFile = "C:\\evoke\\datacsvproj\\test.csv";
            //FileInfo fi = new FileInfo(nameOfFile);
            //fi.AppendText(data.rollno);
            List<string> readText = new List<string>();    
            details += data.Rno + ",";
            details += data.name + ",";
            details += data.mark1 + ",";
            details += data.mark2 + ",";
            details += data.mark1 + data.mark2;
            StreamReader Textfile = new StreamReader(nameOfFile);
            string line;

            while ((line = Textfile.ReadLine()) != null)
            {
                Console.WriteLine(line);
                readText.Add(line);
            }
            Textfile.Close();
            using (StreamWriter writer = new StreamWriter(nameOfFile))
            {
                foreach(string s in readText)
                {
                    var ch = s.Split(",");
                    if (int.Parse(ch[0]) == data.Rno)
                    {
                        Console.WriteLine("hello");
                        writer.WriteLine(details);
                    }
                    else
                    {
                        writer.WriteLine(s);
                    }
                }
                
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            data dt = getStudent(Id);
            return View(dt);
        }

        [HttpPost]
        public IActionResult Delete(IFormCollection form)
        {
            String path = "C:\\evoke\\datacsvproj\\test.csv";
            List<String> lines = new List<String>();



            using (StreamReader reader = new StreamReader(path))
            {
                String line;



                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains(","))
                    {
                        String[] split = line.Split(',');



                        if (int.Parse(split[0]) != int.Parse(form["id"]))
                        {
                            line = String.Join(",", split);
                            lines.Add(line);
                        }
                    }



                }
            }



            using (StreamWriter writer = new StreamWriter(path, false))
            {
                foreach (String line in lines)
                    writer.WriteLine(line);
            }



            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            data student = getStudent(id);
            return View(student);
        }
    }
}

