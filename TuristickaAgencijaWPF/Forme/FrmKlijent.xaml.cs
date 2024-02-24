using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TuristickaAgencijaWPF.Forme
{
    /// <summary>
    /// Interaction logic for FrmKlijent.xaml
    /// </summary>
    public partial class FrmKlijent : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;
        public FrmKlijent()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtImeKlijent.Focus();
        }
        public FrmKlijent(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtImeKlijent.Focus();
            this.azuriraj = azuriraj;
            this.red = red;
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@ime", SqlDbType.NVarChar).Value = txtImeKlijent.Text;
                cmd.Parameters.Add("@prezime", SqlDbType.NVarChar).Value = txtPrezimeKlijent.Text;
                cmd.Parameters.Add("@adresa", SqlDbType.NVarChar).Value = txtAdresaKlijent.Text;
                cmd.Parameters.Add("@kontakt", SqlDbType.NVarChar).Value = txtKontaktKlijent.Text;

                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblKlijent set
                                         ime = @ime, prezime = @prezime, adresa = @adresa,
                                         kontakt = @kontakt where klijentID = @id";
                    red = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblKlijent(ime, prezime, adresa, kontakt)
                                    values (@ime, @prezime, @adresa, @kontakt)";
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos određenih vrijednosti nije validan", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Došlo je do greške prilikom konverzije podataka", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Polja ne mogu biti prazna!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
