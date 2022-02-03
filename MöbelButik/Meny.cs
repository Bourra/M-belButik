using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MöbelButik
{
    class Meny
    {


        public static void MenyVal() // 3 val väljer om man är kund elle admin eller exit , 3 val
        {
            bool quit = false;
            while (quit != true)
            { 
                Console.WriteLine(
                    "1 = Kundmeny \n" +
                    "2 = admin meny \n" +
                    "3 = Exit \n" +
                    "Mata in ett nummer.");

                int val = Convert.ToInt32(Console.ReadLine());
                switch (val)
                {
                    case 1:
                        //tar dig till kund meny
                        KundMeny();
                        break;

                    case 2:
                        //tar dig till admin meny
                        AdminMeny();
                        break;

                    case 3:
                        //exit
                        quit = true;
                        break;

                }
            }

        }
       
        public static void KundMeny() 
        {
            Console.WriteLine(
            "1 = Visa alla produkter \n" +
            "2 = Visa köks produkter \n" +
            "3 = Visa Sovrums produkter \n" +
            "4 = Visa vardagrums produkter \n" +
            "5 = sök på en produkt \n" +
            "6 = gå tillbaka till huvud meny \n" +
            "Mata in ett nummer.");

            int val = Convert.ToInt32(Console.ReadLine());
            switch (val)
            {
                case 1:
                    //visa alla produkter
                    Products.GetProducts();
                    break;

                case 2:
                    //visa köksprodukter
                    Products.GetKitchenProducts();
                    break;

                case 3:
                    //visa sovrumprodukter
                    Products.GetBedroomProducts();
                    break;

                case 4:
                    //visa vardagsrummsprodukter
                    Products.GetLivingRoomProducts();
                    break;

                case 5:
                    //fritextsöskning produkter

                    break;

                case 6:
                    //tillbaka till huvud meny

                    break;

            }

        }

        public static void AdminMeny()
        {
            int val = Convert.ToInt32(Console.ReadLine());
            switch (val)
            {
                case 1:
                    //kunna lägga till produkt

                    break;

                case 2:

                    //kunna ta bort produkt
                    break;

                case 3:
                    //kunna ändra tabbell

                    break;

                case 4:
                    //tillbaka till huvud meny
                    break;

            }

        }

    }

}
