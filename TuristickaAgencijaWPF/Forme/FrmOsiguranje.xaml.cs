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
    /// Interaction logic for FrmOsiguranje.xaml
    /// </summary>
    public partial class FrmOsiguranje : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;
        public FrmOsiguranje()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtBrojPasosa.Focus();
            PopuniPadajuceListe();
        }
        public FrmOsiguranje(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtBrojPasosa.Focus();
            PopuniPadajuceListe();
            this.azuriraj = azuriraj;
            this.red = red;
        }
        public void PopuniPadajuceListe()
        {
            try
            {

                konekcija.Open();
                string vratiKlijente = @"select klijentID, ime + ' ' + prezime as Klijent from tblKlijent";
                SqlDataAdapter daKlijent = new SqlDataAdapter(vratiKlijente, konekcija);
                DataTable dtKlijent = new DataTable();
                daKlijent.Fill(dtKlijent);
                cbKlijent.ItemsSource = dtKlijent.DefaultView;
                daKlijent.Dispose();
                dtKlijent.Dispose();

            }
            catch (SqlException)
            {
                MessageBox.Show("Padajuće liste nisu popunjene", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
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
                cmd.Parameters.Add("@brojPasosa", SqlDbType.NVarChar).Value = txtBrojPasosa.Text;
                cmd.Parameters.Add("@jmbgOsiguranika", SqlDbType.NVarChar).Value = txtJmbg.Text;
                cmd.Parameters.Add("@brojPolise", SqlDbType.Int).Value = txtBrojPolise.Text;
                cmd.Parameters.Add("@starostOsiguranika", SqlDbType.Int).Value = txtStarost.Text;
                cmd.Parameters.Add("@klijentID", SqlDbType.Int).Value = cbKlijent.SelectedValue;
                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblOsiguranje set
                                         brojPasosa = @brojPasosa, jmbgOsiguranika = @jmbgOsiguranika, brojPolise = @brojPolise,
                                         starostOsiguranika = @starostOsiguranika, klijentID = @klijentID where osiguranjeID = @id";
                    red = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblOsiguranje(brojPasosa, jmbgOsiguranika, brojPolise, starostOsiguranika, klijentID)
                                    values (@brojPasosa, @jmbgOsiguranika, @brojPolise, @starostOsiguranika, @klijentID)";
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            }
           

            catch (SqlException)
            {
               MessageBox.Show("Unos određenih vrijednosti nije validan!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
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
