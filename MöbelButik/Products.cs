using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace MöbelButik
{
    class Products
    {
        public static void GetProducts()
        {
            using (var db = new Models.möbelbutikContext())
            {
                var product = db.Produkts;
                foreach (var item in product)
                {
                    Console.WriteLine(item.Id + "\t" + item.ProduktNamn + "\t" + item.Pris);
                }
            }
        }

        public static void GetKitchenProducts()
        {
          

            using (var db = new Models.möbelbutikContext())
            {
                var result = from
                             Produkts in db.Produkts
                             where Produkts.KategoriId == 1
                             select new Queries { ProduktName = Produkts.ProduktNamn, ProduktPris = (double) Produkts.Pris, ProduktId = Produkts.Id };
                             //group Produkts by Produkts.ProduktNamn;

                foreach (var product in result)
                {
                    Console.WriteLine(product.ProduktId + "\t" + product.ProduktName + "\t" + product.ProduktPris );
                }
                

            }
        }

        public static void GetBedroomProducts()
        {


            using (var db = new Models.möbelbutikContext())
            {
                var result = from
                             Produkts in db.Produkts
                             where Produkts.KategoriId == 2
                             select new Queries { ProduktName = Produkts.ProduktNamn, ProduktPris = (double)Produkts.Pris, ProduktId = Produkts.Id };
                //group Produkts by Produkts.ProduktNamn;

                foreach (var product in result)
                {
                    Console.WriteLine(product.ProduktId + "\t" + product.ProduktName + "\t" + product.ProduktPris);
                }


            }
        }

        public static void GetLivingRoomProducts()
        {


            using (var db = new Models.möbelbutikContext())
            {
                var result = from
                             Produkts in db.Produkts
                             where Produkts.KategoriId == 3
                             select new Queries { ProduktName = Produkts.ProduktNamn, ProduktPris = (double)Produkts.Pris, ProduktId = Produkts.Id };
                //group Produkts by Produkts.ProduktNamn;

                foreach (var product in result)
                {
                    Console.WriteLine(product.ProduktId + "\t" + product.ProduktName + "\t" + product.ProduktPris);
                }


            }

           
        }

        public static int InsertProdukt()
        {
            var affectedRows = 0;

            var connString = "data source=.\\SQLEXPRESS; initial catalog=MöbelButik; persist security info=true; Integrated Security=true";
            var produkt = new Models.Produkt();
            produkt = AddProdukt();
            var sql = $"Insert into Produkt(Id, ProduktNamn, TillverkareId, KategoriId, Färg, Material, Pris) values('{produkt.Id}', '{produkt.ProduktNamn}', '{produkt.TillverkareId}', '{produkt.KategoriId}', '{produkt.Färg}', '{produkt.Material}', '{produkt.Pris}')";
       

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql);
                    Console.WriteLine("Din produkt blev tillagd");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

            return affectedRows;

        }

        public static Models.Produkt AddProdukt() 
        {

            
            
            Console.WriteLine("Skriv in id");
            int prduktId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Skriv in namn");
            string namn = Console.ReadLine();

            Console.WriteLine(
            "Skriv in tillverkarID\n" +
            "1 = Ikea \n" +
            "2 = Mio \n" +
            "3 = FCompany \n" +
            "4 = testTable");
            int tillVerkareID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(
            "Skriv in kategoriID\n" +
            "1 = kök \n" +
            "2 = Sovrum \n" +
            "3 = vardagsrum \n" +
            "4 = Badrum");
            int kategoriID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(
            "Skriv in materialID\n" +
            "1 = Trä \n" +
            "2 = Metall \n" +
            "3 = Plast \n" +
            "4 = Blandat\n" +
            "5 = Bomull");
            int materialID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(
            "Skriv in färgID\n" +
            "1 = Svart \n" +
            "2 = Brun \n" +
            "3 = Vit \n" +
            "4 = Blå\n" +
            "5 = Grön \n" +
            "6 = Gul \n" +
            "7 = Röd \n" +
            "8 = Ofärgat");
            int färgID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Skriv in pris (ex: 150.50)");
            //float pris = float.Parse(Console.ReadLine());
            bool result = float.TryParse(Console.ReadLine(), out float pris);

            var newProdukt = new Models.Produkt() 
            {   
                Id = prduktId, 
                ProduktNamn = namn, 
                TillverkareId = tillVerkareID,  
                KategoriId = kategoriID,
                Färg = färgID,
                Material = materialID,
                Pris = pris
            };

            return newProdukt;
        }

        public static int DeleteProdukt()
        {
            Console.WriteLine("Vilken produkt vill du ta bort? Skriv in id");
            var deleteId = Convert.ToInt32(Console.ReadLine());
            var affectedRows = 0;

            var connString = "data source=.\\SQLEXPRESS; initial catalog=MöbelButik; persist security info=true; Integrated Security=true";
            

            var sql = $" DELETE FROM Produkt WHERE id = {deleteId} ";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql);
                    Console.WriteLine("Din produkt blev tillagd");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

            return affectedRows;

        }
    }
}
