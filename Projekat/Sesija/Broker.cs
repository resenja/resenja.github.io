using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Baza;

namespace Sesija
{
    public class Broker
    {
        private static Broker instanca;
        private OleDbConnection konekcija;
        private OleDbCommand komanda;
        public Broker()
        {
            konekcija = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database.accdb");
            komanda = konekcija.CreateCommand();
        }
        public static Broker DajSesiju()
        {
            if (instanca == null) instanca = new Broker();
            return instanca;
        }
        public int UbaciUBazu(Objekat objekat)
        {
            try
            {
                komanda.CommandText = String.Format("insert into Objekti values({0}, '{1}')", objekat.id, objekat.atribut1);
                komanda.CommandType = CommandType.Text;
                konekcija.Open();
                return komanda.ExecuteNonQuery();
            }
            finally
            {
                if (konekcija != null) konekcija.Close();
            }
        }
        public List<Objekat> VratiSve()
        {
            List<Objekat> objekti = new List<Objekat>();
            try
            {
                komanda.CommandText = String.Format("select * from Objekti");
                komanda.CommandType = CommandType.Text;
                konekcija.Open();
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Objekat objekat = new Objekat
                    {
                        id = (int)citac["id"],
                        atribut1 = citac["atribut1"].ToString()
                    };
                    objekti.Add(objekat);
                }
                return objekti;
            }
            finally
            {
                if (konekcija != null) konekcija.Close();
            }
        }
    }
}
