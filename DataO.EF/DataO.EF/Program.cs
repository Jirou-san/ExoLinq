using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DataO.EF
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Test1
            //Stock unStock = new Stock();

            //string connectionString = "Data Source=M2IPORT-5XXPNC2\\SQLEXPRESS; Initial Catalog=WideWorldImporters;" + "Integrated Security=true";
            //int IDStock = unStock.GetById(3, "WareHouse.StockItemHoldings", connectionString).StockItemID;
            //int QuantityOnHand = unStock.GetById(3, "WareHouse.StockItemHoldings", connectionString).QuantityOnHand;
            //string BinLocation = unStock.GetById(3, "WareHouse.StockItemHoldings", connectionString).BinLocation;
            //int LastStocktakeQuantity = unStock.GetById(3, "WareHouse.StockItemHoldings", connectionString).LastStocktakeQuantity;
            //decimal LastCostPrice = unStock.GetById(3, "WareHouse.StockItemHoldings", connectionString).LastCostPrice;
            //int ReorderLevel = unStock.GetById(3, "WareHouse.StockItemHoldings", connectionString).ReorderLevel;
            //int TargetStockLevel = unStock.GetById(3, "WareHouse.StockItemHoldings", connectionString).TargetStockLevel;
            //int LastEditedBy = unStock.GetById(3, "WareHouse.StockItemHoldings", connectionString).LastEditedBy;
            //DateTime LastEditedWhen = unStock.GetById(3, "WareHouse.StockItemHoldings", connectionString).LastEditedWhen;  
            //try
            //{
            //    Console.WriteLine("ID: "+IDStock.ToString() + " Quantité: "+QuantityOnHand.ToString()+
            //        " Location: " + BinLocation.ToString() + " Prix: " + LastCostPrice.ToString());

            //    Stock majStock = new Stock();
            //    majStock.QuantityOnHand = 99;
            //    majStock.UpdateDelete(3, "WareHouse.StockItemHoldings", connectionString, "UPD");



            //    Console.WriteLine("ID: " + IDStock.ToString() + " Quantité: " + QuantityOnHand.ToString() +
            //       " Location: " + BinLocation.ToString() + " Prix: " + LastCostPrice.ToString());

            //}
            //catch(SqlException e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            #endregion

            string sentence1 = "The quick brown fox jumps over the lazy dog"; //phrase type
            string sentence2 = "Portez ce vieux whisky au juge blond qui fume"; //phrase type
            int i = 0; //indexeur
            int j = 0;
 
            //Conversion des phrases en tableur
            Array sentence1ToArray = sentence1.Split(' ');
            Array sentence2ToArray = sentence2.Split(' ');           

            //Liste d'objets word
            List<Word> listeDeMots1 = new List<Word>();
            List<Word> listeDeMots2 = new List<Word>();

            //Querry pour obtenir un mot
            

            foreach (var word in sentence1ToArray)
            {
                i++;
                Word unMot = new Word(i, word.ToString());
                listeDeMots1.Add(unMot);
            }
            foreach (var word in sentence2ToArray)
            {
                j++;
                Word unMot = new Word(j, word.ToString());
                listeDeMots2.Add(unMot);
            }

            var queryGetWordById = from w1 in listeDeMots1
                                   join w2 in listeDeMots2 on w1.I equals w2.I
                                   where w1.I == 4
                                   select new { w1.I, Mot = w1.Mot + w2.Mot };

            foreach (var objet in queryGetWordById)
            {
                Console.WriteLine(objet.Mot);
            }
            

            Console.ReadKey();
        }
    }
}
