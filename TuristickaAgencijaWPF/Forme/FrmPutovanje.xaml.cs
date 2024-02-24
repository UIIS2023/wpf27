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
    /// Interaction logic for FrmPutovanje.xaml
    /// </summary>
    public partial class FrmPutovanje : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;

        public FrmPutovanje()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtBrojDana.Focus();
            PopuniPadajuceListe();
        }
        public FrmPutovanje(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtBrojDana.Focus();
            PopuniPadajuceListe();
            this.azuriraj = azuriraj;
            this.red = red;
        }
        public void PopuniPadajuceListe()
        {
            try
            {

                konekcija.Open();
                string vratiVrste = @"select vrstaID, nazivVrste from tblVrsta";
                DataTable dtVrsta = new DataTable();
                SqlDataAdapter daVrsta = new SqlDataAdapter(vratiVrste, konekcija);
                daVrsta.Fill(dtVrsta);
                cbVrsta.ItemsSource = dtVrsta.DefaultView;
                daVrsta.Dispose();
                dtVrsta.Dispose();

                string vratiDestinacije = @"select destinacijaID, grad + ', ' + drzava as Destinacija from tblDestinacija";
                SqlDataAdapter daDestinacija = new SqlDataAdapter(vratiDestinacije, konekcija);
                DataTable dtDestinacija = new DataTable();
                daDestinacija.Fill(dtDestinacija);
                cbDestinacija.ItemsSource = dtDestinacija.DefaultView;
                daDestinacija.Dispose();
                dtDestinacija.Dispose();

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
                DateTime date = (DateTime)dpDatum.SelectedDate;
                string datum = date.ToString("yyyy-MM-dd");
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@brojDana", SqlDbType.Int).Value = txtBrojDana.Text;
                cmd.Parameters.Add("@cijena", SqlDbType.Decimal).Value = txtCijena.Text;
                cmd.Parameters.Add("@datum", SqlDbType.DateTime).Value = datum;
                cmd.Parameters.Add("@vrstaID", SqlDbType.Int).Value = cbVrsta.SelectedValue;
                cmd.Parameters.Add("@destinacijaID", SqlDbType.Int).Value = cbDestinacija.SelectedValue;
                cmd.Parameters.Add("@klijentID", SqlDbType.Int).Value = cbKlijent.SelectedValue;

                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblPutovanje set
                                         brojDana = @brojDana, cijena = @cijena, datum = @datum,
                                         vrstaID = @vrstaID, destinacijaID = @destinacijaID,
                                         klijentID = @klijentID where putovanjeID = @id";
                    red = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblPutovanje(brojDana, cijena, datum, vrstaID, destinacijaID, klijentID)
                                    values (@brojDana, @cijena, @datum, @vrstaID, @destinacijaID, @klijentID)";
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();                                                          
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                var errorMessage = "Greška u SQL upitu: \n";
                foreach (SqlError error in ex.Errors)
                {
                    errorMessage += "Error Code: " + error.Number + " - " +
                                    "Message: " + error.Message + "\n";
                    
                }
                MessageBox.Show(errorMessage, "Detaljne informacije o grešci", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Došlo je do greške prilikom konverzije podataka", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
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
