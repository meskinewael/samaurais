using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace ConsoleApp1
{
   internal class Program
    {

        private static SamauraiDBcontext Context = new SamauraiDBcontext();
        static void Main(string[] args)
        {
          var response = Context.Database.EnsureCreated();
            // GetSamaurais("before add");

            //AddSamaurais("symon","usernumber45","meskieiuor");
            //AddToSpesificsRecord(10);
            //updateMassdata();
            Leftjoin(1);
           // AddData(1);
          //AddSamaurais();
          //AddSamaurais();

            // GetSamaurais("after add");
            //Queryfiltes();

            // UpdateSamaurai(2,"mrid","omar");
            // DeleteSmaurai(2);
            //Console.Write(response);
            //Console.ReadKey();
        }

        public static void Queryfiltes()

        {
            //var samurai = Context.Samaurais.Where(x =>x.Id == 1).FirstOrDefault();
            /* var samaurai = new Samaurais { Name = "ahmed" ,LastName = "meskine" ,Quotes = new List<Quote>
             {
                 new Quote {
                 Text = "waelres" }
             }
             };


             //var result = Context.Samaurais.Where(n =>n.Name == "wael" ).FirstOrDefault();
             Context.Samaurais.Add(samaurai);
             Context.SaveChanges();

             */

            var samurais = Context.Samaurais.OrderBy(n => n.Date).Where(n=>n.LastName=="meskine").ToList();
            foreach(var samurai in samurais )
             {
                Console.WriteLine(samurai.Name);



            }

            // Context.AddRange(samaurai,que);
          
           
      

        }

        public static void UpdateSamaurai(int id ,  string name , string lastname )
        {
            var updateCostemers = Context.Samaurais.Find(id);
            updateCostemers.Name = name;
            updateCostemers.LastName = lastname;
            Context.SaveChanges();
        }

        public static void DeleteSmaurai (int id)
        {

            var Deletesamaurai = Context.Samaurais.Find(id);
            Context.Remove(Deletesamaurai);
            Context.SaveChanges();   
                            



        }
        public static void AddSamaurais( string name , string lastname ,string email)
        {
            /*
            var date1 = new DateTime(1987, 05, 20, 17, 43, 30);
            var samourai10 = new Samaurais { Name = "olfa", LastName = "meskine", Date = date1,
                Quotes = new List<Quote> {
                    new Quote
                    {
                        Text = "waelres"
                    }
                }
            };

            DateTime now = DateTime.Now;

            var samourai1 = new Samaurais { Name = "ramzi", LastName = "meskine", Date = now,
                Quotes = new List<Quote> {

            new Quote
            {
                Text ="youaewelcome"
             }
            
            }
            
            };
            Context.Add(samourai10);
            Context.SaveChanges();
            */
            //if(ModelState.Is)

                     
            if (!(String.IsNullOrWhiteSpace(name) &&  String.IsNullOrWhiteSpace(lastname)))
            {

                var samurai = new Samaurais { Name = name, LastName = lastname, Email= email };
                Context.Add(samurai);
                Context.SaveChanges();


            }
            else
            {
                Console.WriteLine(String.IsNullOrWhiteSpace(name));
                Console.WriteLine(String.IsNullOrWhiteSpace(lastname));


            }
        }
        public static void GetSamaurais(string text)
        {
            var samurs = Context.Samaurais.ToList();
            Console.WriteLine($"{text}:samurs cout is", samurs.Count);
                foreach(var sam in samurs)
            {
                Console.WriteLine(sam.Name);
            }

        }

        public static void AddToSpesificsRecord(int id)
        {
            var sama = Context.Samaurais.Find(id);
            sama.Quotes.Add(new Quote { Text = "firstorfo" });
            Context.SaveChanges();

        }
        public static void updateMassdata()
        {
            var damaurais = Context.Samaurais.Skip(1).Take(3).ToList();
            /*foreach( var Data in damaurais)
            {
                Console.WriteLine(Data.Name);
                Console.WriteLine(Data.LastName);
            }
            */
            
            damaurais.ForEach(n=>n.Name = "ope");
            Context.SaveChanges();
            

        }
        public static void Leftjoin(int id)
        {
            var samaurais = Context.Samaurais.Where(n => n.Id == id).Include(n => n.Quotes).ToList();
            
            foreach(var sam in samaurais)
            {
                foreach(var samd in sam.Quotes)
                    {
                    Console.WriteLine(samd.Text);
                }


            }
            //Console.WriteLine(samaurais.Quotes.Text);

        }
        public static void AddData(int id)
        {
            var queste = new Quote { Text = "waelres2", SamauraisId = id };
            Context.Add(queste);
            Context.SaveChanges();
        
        }
        public static void ViewRows(int id)
        {

            var samaurais = Context.Samaurais.Where(n => n.Id == id).ToList();


        }

    }

}
