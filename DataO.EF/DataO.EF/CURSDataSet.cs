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
    public sealed class CURSDataSet
    {
        #region Properties
        private string _CURSDataChain;
        private string _CURSQuerry;


        #endregion
        #region Constructor
        public CURSDataSet(string ipCURSDataChain, string ipCURSQuerry)
        {
            CURSQuerry = ipCURSQuerry;
            CURSDataChain = ipCURSDataChain;

        }
        #endregion
        #region Accesseurs
        public string CURSDataChain { get => _CURSDataChain; set => _CURSDataChain = value; }
        public string CURSQuerry { get => _CURSQuerry; set => _CURSQuerry = value; }
        #endregion
        #region Methods
        public void Select(string CURSTable) // Select sur une table
        {
            SqlConnection CURSConnexion = new SqlConnection(_CURSDataChain);
            SqlDataAdapter CURSAdaptater = new SqlDataAdapter(_CURSQuerry, CURSConnexion);
            DataSet CURSSetter = new DataSet();
            SqlCommandBuilder CURSCommandBuilder = new SqlCommandBuilder(CURSAdaptater);
            CURSAdaptater.Fill(CURSSetter, CURSTable);
            var rows = CURSSetter.Tables[CURSTable].Rows;
            foreach (DataRow oneRow in rows)
            {
                foreach (Object uneDonnée in oneRow.ItemArray)
                {
                    Console.WriteLine(uneDonnée.ToString());
                }
            }


        }
        
        #endregion
    }
}
