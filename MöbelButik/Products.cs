using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Console.WriteLine(item.ProduktNamn + "\t" + item.Pris);
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
    }
}
