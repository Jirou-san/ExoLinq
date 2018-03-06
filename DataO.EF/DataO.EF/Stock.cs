using System;
using System.Data;
using System.Data.SqlClient;



namespace DataO.EF
{
    public sealed class Stock
    {
        public int StockItemID { get; set; }
        public int QuantityOnHand { get; set; }
        public string BinLocation { get; set; }
        public int LastStocktakeQuantity { get; set; }
        public decimal LastCostPrice { get; set; }
        public int ReorderLevel { get; set; }
        public int TargetStockLevel { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }
        public string DataChain { get; set; }
        SqlConnection CURSConnexion;
        public Stock()
        {

        }


        public Stock GetById(int id, string table, string datachain)
        {
            var query = "select * from "+ table+" where StockItemID =" + id;
            //Récupération de la table
            SqlConnection CURSConnexion = new SqlConnection(datachain);
            SqlDataAdapter CURSAdaptater = new SqlDataAdapter(query, CURSConnexion);
            DataSet CURSSetter = new DataSet();
            SqlCommandBuilder CURSCommandBuilder = new SqlCommandBuilder(CURSAdaptater);
            CURSAdaptater.Fill(CURSSetter, table);
            var rows = CURSSetter.Tables[table].Rows;

            foreach (DataRow oneRow in rows)
            {
                    StockItemID = (int)oneRow[0];
                    QuantityOnHand = (int)oneRow[1];
                    BinLocation = (string)oneRow[2];
                    LastStocktakeQuantity = (int)oneRow[3];
                    LastCostPrice = (decimal)oneRow[4];
                    ReorderLevel = (int)oneRow[5];
                    TargetStockLevel = (int)oneRow[6];
                    LastEditedBy = (int)oneRow[7];
                    LastEditedWhen = (DateTime)oneRow[8];
            }
            CURSConnexion.Close();
            return this;
        }
        public void UpdateDelete(int id, string table, string datachain,string param)
        {
            string query= "select * from " + table + " where StockItemID =" + id;
            //Récupération de la table
            SqlConnection CURSConnexion = new SqlConnection(datachain);
            SqlDataAdapter CURSAdaptater = new SqlDataAdapter(query, CURSConnexion);
            DataSet CURSSetter = new DataSet();
            DataRow CURSRow;
            SqlCommandBuilder CURSCommandBuilder = new SqlCommandBuilder(CURSAdaptater);
            CURSAdaptater.Fill(CURSSetter, table);
            CURSRow = CURSSetter.Tables[table].Rows[0];
            if (param.ToUpper() == "UPD")//Mise à jour d'une ligne de la table
            {
                CURSRow["QuantityOnHand"] = QuantityOnHand;
                CURSRow["BinLocation"] = BinLocation;
                CURSRow["LastStocktakeQuantity"] = LastStocktakeQuantity;
                CURSRow["LastCostPrice"] = LastCostPrice;
                CURSRow["ReorderLevel"] = ReorderLevel;
                CURSRow["TargetStockLevel"] = TargetStockLevel;
                CURSRow["LastEditedBy"] = LastEditedBy;
                CURSRow["LastEditedWhen"] = LastEditedWhen;
                CURSAdaptater.Update(CURSSetter, table);
                CURSConnexion.Close();

            }
            else if(param.ToUpper() == "DEL")//Suppression d'une ligne dans la table
            {
                CURSRow.Delete();
                CURSAdaptater.Update(CURSSetter, table);
                CURSConnexion.Close();
            }
        }
        public void Add(string table, string datachain)
        {
            string query = "select * from " + table;
            //Récupération de la table
            SqlConnection CURSConnexion = new SqlConnection(datachain);
            SqlDataAdapter CURSAdaptater = new SqlDataAdapter(query, CURSConnexion);
            DataSet CURSSetter = new DataSet();
            DataRow CURSRow;
            SqlCommandBuilder CURSCommandBuilder = new SqlCommandBuilder(CURSAdaptater);
            CURSAdaptater.Fill(CURSSetter, table);
        }
    }
}
