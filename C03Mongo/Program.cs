// See https://aka.ms/new-console-template for more information
using C03Mongo.Helpers;
using C03Mongo.Models;

MongoCRUD db = new MongoCRUD("playground");
//Address myAddress = new Address { Street = "XXXXXXXXXXXXX", Municipality="Hradec Králové", ZipCode=40041};
//db.Create("contacts", myAddress);
//Person ps1 = new Person { Firstname = "Xaver", HomeAddress = myAddress };
//db.Create("contacts", ps1);
Address? x = db.Read<Address>("contacts", Guid.Parse("354bd67e-d2d5-4f4f-ac91-3b3cb0440208"));
Console.WriteLine(x);
if (x != null)
{
    Console.WriteLine(x.Street);
}

List<Address> adr = db.List<Address>("contacts");
foreach (Address adr2 in adr)
{
    Console.WriteLine(adr2.Id + " " + adr2.Street);
}

db.Upsert<Address>("contacts", Guid.Parse("354bd67e-d2d5-4f4f-ac91-3b3cb0440208"), new Address {Id = Guid.Parse("354bd67e-d2d5-4f4f-ac91-3b3cb0440208"), Street = "YYYYYY", Municipality = "Pardubice" });

adr = db.List<Address>("contacts");
foreach (Address adr2 in adr)
{
    Console.WriteLine(adr2.Id + " " + adr2.Street);
}

db.Delete<Address>("contacts", Guid.Parse("354bd67e-d2d5-4f4f-ac91-3b3cb0440208"));

adr = db.List<Address>("contacts");
foreach (Address adr2 in adr)
{
    Console.WriteLine(adr2.Id + " " + adr2.Street);
}

Console.WriteLine("END");