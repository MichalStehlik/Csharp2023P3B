// See https://aka.ms/new-console-template for more information
using C03Mongo.Helpers;
using C03Mongo.Models;

MongoCRUD db = new MongoCRUD("playground");
Address myAddress = new Address { Street = "XXXXXXXXXXXXX", Municipality="Hradec Králové", ZipCode=40041};
db.Create("contacts", myAddress);
Person ps1 = new Person { Firstname = "Xaver", HomeAddress = myAddress };
//db.Create("contacts", ps1);
//Address x = db.Read<Address>("contacts", "652654ac24bce8a4a427c477");
//Console.WriteLine(x.Street);
/*
List<Address> adr = db.List<Address>("contacts");
foreach (Address adr2 in adr)
{
    Console.WriteLine(adr2.Street);
}
*/