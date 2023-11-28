// See https://aka.ms/new-console-template for more information
using C02EFC.Data;
using C02EFC.Models;
using Microsoft.EntityFrameworkCore;

ApplicationDbContext db = new ApplicationDbContext();
foreach(var x in db.Companies.ToList())
{
    Console.WriteLine(x.Name);
}
foreach (var x in db.Games.ToList())
{
    Console.WriteLine(x.GameId + " " + x.Name + " / " + x.Developer!.Name);
}
foreach (var x in db.Companies.Include(x => x.Games).ToList())
{
    Console.WriteLine(" " + x.Name);
    foreach (var y in x.Games!)
    {
        Console.WriteLine("  " + y.Name);
    }
}
foreach (var x in db.Games.OrderBy(x => x.Name).ToList())
{
    Console.WriteLine(x.GameId + " " + x.Name + " / " + x.Developer!.Name);
}
foreach (var x in db.Games.Where(x => x.Name.StartsWith("O")).ToList())
{
    Console.WriteLine(x.GameId + " " + x.Name + " / " + x.Developer!.Name);
}
// přidání
db.Games.Add(new Game { Name = "Morrowind", DeveloperId = 2});
db.SaveChanges();
foreach (var x in db.Games.ToList())
{
    Console.WriteLine(x.GameId + " " + x.Name + " / " + x.Developer!.Name);
}
// update
Game? mw = db.Games.Where(x => x.Name == "Morrowind").SingleOrDefault();
if (mw != null)
{
    mw.Name = "Fallout 3";
    db.SaveChanges();
}
foreach (var x in db.Games.ToList())
{
    Console.WriteLine(x.GameId + " " + x.Name + " / " + x.Developer!.Name);
}