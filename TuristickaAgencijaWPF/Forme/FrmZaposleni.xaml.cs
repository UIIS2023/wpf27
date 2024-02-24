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
    /// Interaction logic for FrmZaposleni.xaml
    /// </summary>
    public partial class FrmZaposleni : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;
        public FrmZaposleni()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtImeZaposleni.Focus();
        }
        public FrmZaposleni(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtImeZaposleni.Focus();
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
                cmd.Parameters.Add("@imeZaposleni", SqlDbType.NVarChar).Value = txtImeZaposleni.Text;
                cmd.Parameters.Add("@prezimeZaposleni", SqlDbType.NVarChar).Value = txtPrezimeZaposleni.Text;
                cmd.Parameters.Add("@adresaZaposleni", SqlDbType.NVarChar).Value = txtAdresaZaposleni.Text;
                cmd.Parameters.Add("@kontaktZaposleni", SqlDbType.NVarChar).Value = txtKontaktZaposleni.Text;

                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblZaposleni set
                                         imeZaposleni = @imeZaposleni, prezimeZaposleni = @prezimeZaposleni, adresaZaposleni = @adresaZaposleni,
                                         kontaktZaposleni = @kontaktZaposleni where zaposleniID = @id";
                    red = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblZaposleni(imeZaposleni, prezimeZaposleni, adresaZaposleni, kontaktZaposleni)
                                    values (@imeZaposleni, @prezimeZaposleni, @adresaZaposleni, @kontaktZaposleni)";
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
