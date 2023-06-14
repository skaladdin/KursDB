// See https://aka.ms/new-console-template for more information
using KursDB;


DBHandler dbh = new DBHandler();

Console.WriteLine("Wollen Sie einen Kurs erstellen? (j/n)");
char createKurs = Char.Parse(Console.ReadLine());

if (createKurs == 'j')
{
    Console.WriteLine("Bitte Kursnamen eingeben: ");
    string kursNameToDelete = Console.ReadLine();

    Console.WriteLine("Bitte Raumnummer eingeben: ");
    int raumnummer = Int32.Parse(Console.ReadLine());

    dbh.createKurs(kursNameToDelete, raumnummer);
}

Console.WriteLine("Wollen Sie einen Kurs löschen? (j/n)");
char deleteKurs = Char.Parse(Console.ReadLine());

if (deleteKurs == 'j')
{
    Console.WriteLine("welchen Kurs wollen Sie löschen?");
    string kursToDelete = Console.ReadLine();
    dbh.deleteKurs(kursToDelete);
    Console.WriteLine("{0} wurde gelöscht!", kursToDelete);
}

Console.WriteLine("Wollen Sie einen Student erstellen? (j/n)");

char createStudent = Char.Parse(Console.ReadLine());

if (createStudent == 'j')
{
    Console.WriteLine("Bitte Name des Studenten eingeben: ");
    string studentName = Console.ReadLine();

    Console.WriteLine("Bitte E-Mail eingeben: ");
    string email = Console.ReadLine();

    Console.WriteLine("Bitte Kurs Namen eingeben: ");
    string kursName = Console.ReadLine();

    dbh.createStudent(studentName, email, kursName);
}

Console.WriteLine("Wollen Sie einen Student löschen? (j/n)");

char deleteStudent = Char.Parse(Console.ReadLine());

if (deleteStudent == 'j')
{
    Console.WriteLine("Bitte Name des zu löschenden Studenten eingeben: ");
    string studentNameToDelete = Console.ReadLine();

    dbh.deleteStudent(studentNameToDelete);

}

Console.WriteLine("Wollen Sie die Angaben eines Studenten ändern? (j/n)");
char updateStudent = Char.Parse(Console.ReadLine());


if (updateStudent == 'j')
{
    Console.WriteLine("Welchen Student möchten Sie anpassen? ");
    string studentToUpdate = Console.ReadLine();

    dbh.getAttributeNames();
    Console.WriteLine("Welches Attribut möchten Sie anpassen? ");
    string attributeToChange = Console.ReadLine();

    Console.WriteLine("Sie möchten {0} ändern, welcher Wert soll {0} annehmen?", attributeToChange);
    string newValue = Console.ReadLine();

    dbh.updateStudent(studentToUpdate, attributeToChange, newValue);

}


Console.WriteLine("Danke und bis zum näschten Mal!");

