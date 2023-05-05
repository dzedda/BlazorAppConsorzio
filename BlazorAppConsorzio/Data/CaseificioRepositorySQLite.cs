using BlazorAppConsorzio.Models;
using Microsoft.Data.Sqlite;

namespace BlazorAppConsorzio.Data
{
    public class CaseificioRepositorySQLite : ICaseicificioRepository
    {
        private static string dataSourceString = @"Data Source=Data/Source/consorzio.db";
        public Caseificio GetCaseificio(int id)
        {
            Caseificio existentCaseificio = new Caseificio();
            SqliteConnection myConnection = new SqliteConnection(dataSourceString);
            //creo il command 
            SqliteCommand myCommand = new SqliteCommand("SELECT * FROM tblCaseifici WHERE idCaseificio=@par1");
            SqliteParameter myPar = new SqliteParameter("@par1", id);
            SqliteDataReader myDatareader;
            myCommand.Connection = myConnection;
            myCommand.Parameters.Add(myPar);
            myConnection.Open();
            myDatareader = myCommand.ExecuteReader();
            myDatareader.Read();
            existentCaseificio.IdCaseificio = id;
            existentCaseificio.Denominazione = myDatareader["denominazione"].ToString();
            myConnection.Close();
            return existentCaseificio;

        }

        public List<Foto> GetFotos(int id)
        {
            List<Foto> listaFoto = new List<Foto>();
            //creo gli oggetti che mi servono per manipolare il database: 
            //connection: collega il db a c#
            SqliteConnection myConnection = new SqliteConnection(dataSourceString);
            //command: manda in esecuzione una query sql
            SqliteCommand myCommand = new SqliteCommand("SELECT * FROM tblFoto WHERE caseificioId=@par1");
            SqliteParameter myPar = new SqliteParameter("@par1", id);
            myCommand.Parameters.Add(myPar);
            //ospita la tabella che risulta dall'esecuzione del command
            SqliteDataReader myDatareader;
            myCommand.Connection = myConnection;
            myConnection.Open();
            
                myDatareader = myCommand.ExecuteReader();            
            
            while (myDatareader.Read())
            {                
                Foto myFoto = new Foto();
                myFoto.Path = myDatareader["path"].ToString();
                myFoto.AltText = myDatareader["altText"].ToString();
                listaFoto.Add(myFoto);
            }
            myConnection.Close();

            return listaFoto;
        }
    }
}
