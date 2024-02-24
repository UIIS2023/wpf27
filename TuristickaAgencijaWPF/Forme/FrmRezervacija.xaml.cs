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
    /// Interaction logic for FrmRezervacija.xaml
    /// </summary>
    public partial class FrmRezervacija : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;
        public FrmRezervacija()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtNazivHotela.Focus();
            PopuniPadajuceListe();
        }
        public FrmRezervacija(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtNazivHotela.Focus();
            PopuniPadajuceListe();
            this.red = red;
            this.azuriraj = azuriraj;
        }
        public void PopuniPadajuceListe()
        {
            try
            {

                konekcija.Open();
                string vratiZaposlene = @"select zaposleniID, imeZaposleni + ' ' + prezimeZaposleni as Zaposleni from tblZaposleni";
                DataTable dtZaposleni = new DataTable();
                SqlDataAdapter daZaposleni = new SqlDataAdapter(vratiZaposlene, konekcija);
                daZaposleni.Fill(dtZaposleni);
                cbZaposleni.ItemsSource = dtZaposleni.DefaultView;
                daZaposleni.Dispose();
                dtZaposleni.Dispose();

                string vratiPutovanja = @"select putovanjeID, datum, cijena as Aranžman from tblPutovanje";
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

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@nazivHotela", SqlDbType.NVarChar).Value = txtNazivHotela.Text;
                cmd.Parameters.Add("@popunjeno", SqlDbType.Bit).Value = Convert.ToInt32(cbxPopunjeno.IsChecked);
                cmd.Parameters.Add("@zaposleniID", SqlDbType.Int).Value = cbZaposleni.SelectedValue;
                cmd.Parameters.Add("@putovanjeID", SqlDbType.Int).Value = cbPutovanje.SelectedValue;
                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblRezervacija set
                                         nazivHotela = @nazivHotela, popunjeno = @popunjeno, zaposleniID = @zaposleniID,
                                         putovanjeID = @putovanjeID where rezervacijaID = @id";
                    red = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblRezervacija(nazivHotela, popunjeno, zaposleniID, putovanjeID)
                                    values (@nazivHotela, @popunjeno, @zaposleniID, @putovanjeID)";
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();//sluzi za oslobadjanje trenutno zauzetih resursa
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Došlo je do greške priliom konverzije podataka", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Sva polja moraju biti popunjena!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
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
