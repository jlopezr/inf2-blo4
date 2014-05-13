using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace BLO4
{
    class OperacionesBBDD
    {
        OleDbConnection cnx;

        public void Open()
        {
            String nombreDDBB = "BaseJugadores.sdf";
            //String cnxStr = "Provider=Microsoft.SQLSERVER.CE.OLEDB.3.5; Data Source=" + nombreDDBB + ";Persist Security Info=False;";
            String cnxStr = "Provider=Microsoft.SQLSERVER.CE.OLEDB.4.0; Data Source=" + nombreDDBB + ";Persist Security Info=False;";            
            cnx = new OleDbConnection(cnxStr);
            cnx.Open();
        }

        public void Close()
        {
            cnx.Close();
        }

        public void AñadirJugador(String nombre, int edad, int puntos)
        {
            string query = "INSERT INTO Jugadores VALUES ('" + nombre + "'," + edad + "," + puntos + ")";
            OleDbCommand command = new OleDbCommand(query, cnx);
            int result = command.ExecuteNonQuery();
        }

        public int Puntos(int e)
        {
            String query = "SELECT nombre, puntos FROM Jugadores WHERE (edad > " + e + ")";
            DataTable res = new DataTable();
            OleDbDataAdapter adp = new OleDbDataAdapter(query, cnx);
            adp.Fill(res);
            int puntos = 0;
            int i = 0;
            while (i < res.Rows.Count)
            {
                puntos = puntos + Convert.ToInt32(res.Rows[i]["puntos"]);
                i = i + 1;
            }
            return puntos;
        }
    }
}
