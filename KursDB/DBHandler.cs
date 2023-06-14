using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KursDB
{
    internal class DBHandler
    {
        public void createKurs(string name, int raumnummer)
        {
            using (Context context = new Context())
            {
                Kurs k = new Kurs()
                {
                    Name = name,
                    Raumnummer = raumnummer
                };
                context.Kurs.Add(k);
                context.SaveChanges();
            }
        }

        public void deleteKurs(string name)
        {
            using (Context context = new Context())
            {
                var kursIdtoRemove = context.Kurs
                     .Where(k => k.Name == name)
                     .Select(k => k.KursID)
                     .First();

                Kurs kursToRemove = context.Kurs.Find(kursIdtoRemove);
                context.Kurs.Remove(kursToRemove);
                context.SaveChanges();
            }
        }

        public void createStudent(string name, string email, string kursName) 
        {
            using(Context context = new Context()) 
            {
                var kurs = context.Kurs.FirstOrDefault(k => k.Name == kursName);
                if (kurs != null)
                {
                    Studenten student = new Studenten()
                    {
                        Name = name,
                        Email = email,
                        KursID = kurs.KursID
                    };

                    context.Studenten.Add(student);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Kurs {0} nicht gefunden", kursName);
                }
            }
        }

        public void deleteStudent(string name)
        {
            using (Context context = new Context())
            {
                var studentIdToDelete = context.Studenten.FirstOrDefault(s => s.Name == name);

                context.Studenten.Remove(studentIdToDelete);
                context.SaveChanges();

            }
        }

        public void updateStudent(string name, string attributeToChange, string newValue)
        {

            using (Context context = new Context()) 
            {
                var studentToChange = context.Studenten.FirstOrDefault(s => s.Name == name);

                if (studentToChange != null)
                {
                    switch (attributeToChange) 
                    {
                        case "Name":
                            studentToChange.Name = newValue; 
                            break;
                        case "email":
                            studentToChange.Email = newValue;
                            break;
                        case "Kurs":
                            var kurs = context.Kurs.FirstOrDefault(k => k.Name == newValue);

                            if (kurs != null) 
                            {
                                studentToChange.KursID = kurs.KursID;

                            }
                            else
                            {
                                Console.WriteLine("Der angegebene Kurs wurde nicht gefunden.");
                            }
                            break;
                        default:
                            Console.WriteLine("Unbekanntes Attribut: " + attributeToChange);
                            return;
                    }

                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Student {0} wurde nicht gefunden!", studentToChange);
                }
            }
        }

        public void getAttributeNames()
        {
            var studentType = typeof(Studenten);
            var properties = studentType.GetProperties();

            foreach (var property in properties)
            {
                Console.WriteLine(property.Name);
            }
        }

    }
}
