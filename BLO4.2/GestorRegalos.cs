using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLO4._2
{
    class GestorRegalos
    {
        private OleDbConnection cnx;

        public int Abrir()
        {
            String nombreDDBB = "Regalos.sdf";
            //String cnxStr = "Provider=Microsoft.SQLSERVER.CE.OLEDB.3.5; Data Source=" + nombreDDBB + ";Persist Security Info=False;";
            String cnxStr = "Provider=Microsoft.SQLSERVER.CE.OLEDB.4.0; Data Source=" + nombreDDBB + ";Persist Security Info=False;";
            cnx = new OleDbConnection(cnxStr);
            cnx.Open();
            return 0;
        }

        public int Cerrar()
        {
            cnx.Close();
            return 0;
        }

        public double InsertarRegalo(String nombre, String destinatario, double precio)
        {
            string query = "INSERT INTO misRegalos VALUES ('" + nombre + "','" + destinatario+ "'," + precio + ")";
            OleDbCommand command = new OleDbCommand(query, cnx);
            int result = command.ExecuteNonQuery();

            query = "SELECT precio FROM misRegalos WHERE (nombre = '" + destinatario + "')";
            DataTable res = new DataTable();
            OleDbDataAdapter adp = new OleDbDataAdapter(query, cnx);
            adp.Fill(res);
            int total = 0;
            int i = 0;
            while (i < res.Rows.Count)
            {
                total = total + Convert.ToInt32(res.Rows[i]["precio"]);
                i = i + 1;
            }
            return total;
        }       
    }
}
