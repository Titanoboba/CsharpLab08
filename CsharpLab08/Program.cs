using System;
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

        // десериализуем объект
        using (FileStream fs = new FileStream("animal.xml", FileMode.OpenOrCreate))
        {
            Lion? _lion = xmlSerializer.Deserialize(fs) as Lion;
            Console.WriteLine($"Name: {_lion?.Name}  Country: {_lion?.Country} Hide: {_lion?.HideFromOtherAnimals} WhatAnimeal: Animal : {_lion?.WhatAnimal}");
        }

    }
}
