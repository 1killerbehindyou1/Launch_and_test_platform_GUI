using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Threading;
using System.IO;
using System.Windows;

namespace BazyDanych
{
    public class Serwer
    {
       //private  string mojePolaczenie;
        private string sql;
        MySqlConnection polaczenie;
        MySqlDataAdapter da;
        DataTable dt = new DataTable();
        MySqlCommand cmdSel;
        public void zaloguj(string host, string BazaDanych, string user, string pass)
        {
            //pobierz dane logowania z formularza i przypisz
            string mojePolaczenie = "SERVER="+ host + ";" + "DATABASE="+ BazaDanych +";" + "UID=" + user + ";" + "PASSWORD="+ pass +";";
            polaczenie = new MySqlConnection(mojePolaczenie);
          
                polaczenie.Open();

        }
        public DataView PobierzDane(string Column,string Tabel)
        {

            //wykonaj polecenie języka SQL
             sql = "SELECT " + Column + " FROM " + Tabel;
            


          //  try
            //{

                //wykonaj polecenie języka SQL na danych po łączeniu
                using (MySqlCommand cmdSel = new MySqlCommand(sql, polaczenie))
                {
                   
                    //Pobierz dane i zapisz w strukturze DataTable
                    da = new MySqlDataAdapter(cmdSel);
                    da.Fill(dt);
                    //wpisz dane do kontrolki DATAGRID
                   

                }

          //  }
            //Jeżeli wystąpi wyjątek wyrzuć go i pokaż informacje
           /* catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                //MessageBox.Show("Błąd logowania do bazy danych MySQL", "Błąd");
            }*/
            //Zamknij połączenie po wyświetleniu danych
            polaczenie.Close();

            return dt.DefaultView;
        }
        public void wyloguj()
        {

        }
    }
}
