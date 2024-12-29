using System;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.Serialization;
using Lab07;

class Programm
{

    public static void Main()
    {
        Lion lion = new Lion("Russia", false, "myLion");

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Lion));
        using (TextWriter myWriter = new StreamWriter("animal.xml"))
        {
            xmlSerializer.Serialize(myWriter, lion);
        }
        Console.WriteLine("Serialisation finished. Object is saved to animal.xml.");
    }
}