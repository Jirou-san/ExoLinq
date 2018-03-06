using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;


namespace DataO.EF
{
    /// <summary>
    /// Classe servant à gérer les listes de mots 
    /// </summary>
    class ToArray
    {
        #region Properties
        public List<Word> _listeDeMots = new List<Word>();
        public List<Word> _sortedListeDeMots = new List<Word>();
        private string Sentance { get; set; }
        private int index = 0;
        #endregion
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ToArray"/> class.
        /// </summary>
        /// <param name="sentance">The sentance.</param>
        public ToArray(string sentance)
        {
            Sentance = sentance;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Retourne une liste à partir d'un mot
        /// </summary>
        /// <returns></returns>
        public Array ToList()
        {
            Array cutedSentance = Sentance.Split(' ');
            return cutedSentance;
        }
        /// <summary>
        /// Remplie la liste d'objets Word
        /// </summary>
        public void NewListWord()
        {
            foreach (var word in ToList())
            {
                index++;
                Word unMot = new Word(index, word.ToString());
                _listeDeMots.Add(unMot);
            }
        }
        /// <summary>
        /// Trie la liste rentrée en paramètre
        /// </summary>
        /// <param name="uneListeDeMots">The une liste de mots.</param>
        public void SortArray(List<Word> uneListeDeMots)
        {
            var QuerySortedArray = from l1 in uneListeDeMots
                                   orderby l1.Mot ascending
                                   select l1;
            foreach(Word unMot in QuerySortedArray)
            {
                _sortedListeDeMots.Add(unMot);
            }
        }
        /// <summary>
        /// Fusionne les valeurs de deux objets world pour deux listes
        /// </summary>
        /// <param name="list1">The list1.</param>
        /// <param name="list2">The list2.</param>
        /// <param name="index">The index.</param>
        public void WordFusion(List<Word> list1, List<Word> list2, int index)
        {
            
            var queryFusionWord = from l1 in list1
                                   join l2 in list2 on l1.Index equals l2.Index
                                   where l1.Index == index
                                   select new { l1.Index, Mot = l1.Mot + l2.Mot };
            foreach(var unMot in queryFusionWord)
            {
                Console.WriteLine(unMot);
            }
        }
        /// <summary>
        /// Reconstructions the sentance.
        /// </summary>
        /// <param name="uneListe">The une liste.</param>
        /// <returns></returns>
        public string ReconstructionSentance(List<Word> uneListe)
        {
            string reconstructionSentance ="";
            var QueryTried= from l1 in uneListe
                                   orderby l1.Index ascending
                                   select l1;
            foreach (var unMot in QueryTried)
            {
                String.Intern(reconstructionSentance += (" "+unMot.Mot));
            }
            return reconstructionSentance;
        }
        #endregion
    }
    /// <summary>
    /// Programme principale exploitant la console
    /// </summary>
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

            //Conversion des phrases en tableur        

            //Liste d'objets word
            ToArray unePhrase = new ToArray(sentence1);
            ToArray unePhrase1 = new ToArray(sentence2);
            unePhrase.ToList();
            unePhrase1.ToList();
            unePhrase.NewListWord();
            unePhrase1.NewListWord();
            unePhrase.SortArray(unePhrase._listeDeMots);
            unePhrase1.SortArray(unePhrase1._listeDeMots);

            //Querry pour obtenir un mot
            Console.WriteLine("Fusion de mots" + Environment.NewLine);

            unePhrase.WordFusion(unePhrase._listeDeMots, unePhrase1._listeDeMots, 5);

            //Requête de tri
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Triage des mots dans la première phrase" + Environment.NewLine);

            foreach(Word unMot in unePhrase._sortedListeDeMots)
            {
                Console.WriteLine(unMot.Mot);
            }
            Console.WriteLine("Triage des mots dans la deuxième phrase" + Environment.NewLine);
            foreach (Word unMot in unePhrase1._sortedListeDeMots)
            {
                Console.WriteLine(unMot.Mot);
            }
            Console.WriteLine(Environment.NewLine + " Tri et reconstruction:" + Environment.NewLine + "Phrase 1: "+unePhrase.ReconstructionSentance(unePhrase._sortedListeDeMots) + Environment.NewLine + "Phrase 2: "+ unePhrase1.ReconstructionSentance(unePhrase1._sortedListeDeMots));
            
            Console.ReadKey();


        }
    }
}
