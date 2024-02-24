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
    /// Interaction logic for FrmPlacanje.xaml
    /// </summary>
    public partial class FrmPlacanje : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;
        public FrmPlacanje()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtSuma.Focus();
            PopuniPadajuceListe();
        }
        public FrmPlacanje(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtSuma.Focus();
            PopuniPadajuceListe();
            this.red = red;
            this.azuriraj = azuriraj;
        }
        public void PopuniPadajuceListe()
        {
            try
            {
                konekcija.Open();
                string vratiPutovanja = @"select putovanjeID, cijena as Aranžman from tblPutovanje";
                SqlDataAdapter daPutovanje = new SqlDataAdapter(vratiPutovanja, konekcija);
                DataTable dtPutovanje = new DataTable();
                daPutovanje.Fill(dtPutovanje);
                cbPutovanje.ItemsSource = dtPutovanje.DefaultView;
                daPutovanje.Dispose();
                dtPutovanje.Dispose();

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

        
        

        private void btnSacuvaj_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                DateTime date = (DateTime)dpDatum.SelectedDate;
                string datum = date.ToString("yyyy-MM-dd");
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@suma", SqlDbType.Decimal).Value = txtSuma.Text;
                cmd.Parameters.Add("@popust", SqlDbType.Decimal).Value = txtPopust.Text;
                cmd.Parameters.Add("@datum", SqlDbType.DateTime).Value = datum;
                cmd.Parameters.Add("@placeno", SqlDbType.Bit).Value = Convert.ToInt32(cbxPlaceno.IsChecked);
                cmd.Parameters.Add("@putovanjeID", SqlDbType.Int).Value = cbPutovanje.SelectedValue;
                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblPlacanje set
                                         suma = @suma, popust = @popust, datum = @datum,
                                         placeno = @placeno, putovanjeID = @putovanjeID where placanjeID = @id";
                    red = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblPlacanje(suma, popust, datum, placeno, putovanjeID)
                                    values (@suma, @popust, @datum, @placeno, @putovanjeID)";
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
                MessageBox.Show("Došlo je do greške priliom konverzije podataka", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Popunite sva polja!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
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
