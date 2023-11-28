// See https://aka.ms/new-console-template for more information
using C02EFC.Data;

ApplicationDbContext db = new ApplicationDbContext(@"Data Source=myGames.sqlite");
foreach(var x in db.Companies)
{

}
