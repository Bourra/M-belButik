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
    }
}
