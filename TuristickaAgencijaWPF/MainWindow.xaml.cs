using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TuristickaAgencijaWPF.Forme;

namespace TuristickaAgencijaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string ucitanaTabela;
        Konekcija kon = new Konekcija();//kreirati klasu za konekciju
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;
        #region Select upiti
        private static string destinacijeSelect = @"select destinacijaID as ID, grad as Grad, drzava as Država from tblDestinacija";
        private static string vrsteSelect = @"select vrstaID as ID, nazivVrste as 'Naziv vrste' from tblVrsta";
        private static string putovanjaSelect = @"select putovanjeID as ID, brojDana as 'Broj dana', cijena as Cijena, 
                                          datum as 'Datum putovanja', nazivVrste as Vrsta, grad +','+drzava as Destinacija,
                                          ime + ' ' + prezime as Klijent
                                          from tblPutovanje join tblVrsta on tblPutovanje.vrstaID = tblVrsta.vrstaID
                                          join tblDestinacija on tblPutovanje.destinacijaID = tblDestinacija.destinacijaID
                                          join tblKlijent on tblPutovanje.klijentID = tblKlijent.klijentID";
        private static string rezervacijeSelect = @"select rezervacijaID as ID, nazivHotela as 'Naziv hotela', popunjeno as Popunjeno, 
                                          tblPutovanje.cijena as Cijena,  datum as Datum, 
                                          tblZaposleni.imeZaposleni + ' ' + tblZaposleni.prezimeZaposleni as Zaposleni
                                          from tblRezervacija join tblPutovanje on tblRezervacija.putovanjeID = tblPutovanje.putovanjeID
                                          join tblZaposleni on tblRezervacija.zaposleniID = tblZaposleni.zaposleniID";
        private static string klijentiSelect = @"select klijentID as ID, ime as Ime, prezime as Prezime, kontakt as Kontakt, 
                                          adresa as Adresa from tblKlijent";
        private static string zaposleniSelect = @"select zaposleniID as ID, imeZaposleni as Ime, prezimeZaposleni as Prezime,
                                          adresaZaposleni as Adresa, kontaktZaposleni as Kontakt from tblZaposleni";
        private static string osiguranjaSelect = @"select osiguranjeID as ID, brojPasosa as 'Broj pasoša', jmbgOsiguranika as JMBG, 
                                          brojPolise as 'Broj polise',
                                          starostOsiguranika as Starost, ime + ' '  + prezime as Klijent
                                          from tblOsiguranje join tblKlijent on tblOsiguranje.klijentID = tblKlijent.klijentID";
        private static string placanjaSelect = @"select placanjeID as ID, suma as Suma, popust as Popust, tblPlacanje.datum as 'Datum plaćanja',
                                          placeno as Plaćeno, brojDana as 'Broj dana',cijena as 'Cijena putovanja',
                                          tblPutovanje.datum as 'Datum putovanja'
                                          from tblPlacanje join tblPutovanje on tblPlacanje.putovanjeID = tblPutovanje.putovanjeID";
        #endregion

        #region Select upiti sa uslovom
        private static string selectUslovRezervacije = @"select * from tblRezervacija where rezervacijaID=";
        private static string selectUslovPutovanja = @"select * from tblPutovanje where putovanjeID=";
        private static string selectUslovDestinacije = @"select * from tblDestinacija where destinacijaID=";
        private static string selectUslovKlijenti = @"select * from tblKlijent where klijentID=";
        private static string selectUslovOsiguranja = @"select * from tblOsiguranje where osiguranjeID=";
        private static string selectUslovPlacanja = @"select * from tblPlacanje where placanjeID=";
        private static string selectUslovZaposleni = @"select * from tblZaposleni where zaposleniID=";
        private static string selectUslovVrste = @"select * from tblVrsta where vrstaID=";
        #endregion

        #region Delete
        private static string rezervacijeDelete = @"delete from tblRezervacija where rezervacijaID=";
        private static string putovanjaDelete = @"delete from tblPutovanje where putovanjeID=";
        private static string destinacijeDelete = @"delete from tblDestinacija where destinacijaID=";
        private static string klijentiDelete = @"delete from tblKlijent where klijentID=";
        private static string osiguranjaDelete = @"delete from tblOsiguranje where osiguranjeID=";
        private static string placanjaDelete = @"delete from tblPlacanje where placanjeID=";
        private static string zaposleniDelete = @"delete from tblZaposleni where zaposleniID=";
        private static string vrsteDelete = @"delete from tblVrsta where vrstaID";
        #endregion
        public MainWindow()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            UcitajPodatke(putovanjaSelect);
        }
        private void UcitajPodatke(string selectUpit)
        {
            try
            {
                konekcija.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectUpit, konekcija);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);//popunjavamo tabelu
                if (dataGridCentralni != null)
                {
                    dataGridCentralni.ItemsSource = dataTable.DefaultView;//prikazuju se podaci iz tabele u prozoru
                }
                ucitanaTabela = selectUpit;
                dataAdapter.Dispose();
                dataTable.Dispose();
            }
           catch (SqlException ex)
            {
                MessageBox.Show("Neuspješno učitani podaci",  "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnPutovanje_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(putovanjaSelect);
        }

        private void btnRezervacija_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(rezervacijeSelect);
        }

        private void btnZaposleni_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(zaposleniSelect);
        }

        private void btnKlijenti_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(klijentiSelect);
        }

        private void btnOsiguranje_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(osiguranjaSelect);
        }

        private void btnVrsta_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(vrsteSelect);
        }

        private void btnDestinacija_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(destinacijeSelect);
        }

        private void btnPlacanje_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(placanjaSelect);
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Window prozor;
            if (ucitanaTabela.Equals(rezervacijeSelect))
            {
                prozor = new FrmRezervacija();
                prozor.ShowDialog();
                UcitajPodatke(rezervacijeSelect);
            }
            else if (ucitanaTabela.Equals(putovanjaSelect))
            {
                prozor = new FrmPutovanje();
                prozor.ShowDialog();
                UcitajPodatke(putovanjaSelect);
            }
            else if (ucitanaTabela.Equals(destinacijeSelect))
            {
                prozor = new FrmDestinacija();
                prozor.ShowDialog();
                UcitajPodatke(destinacijeSelect);
            }
            else if (ucitanaTabela.Equals(klijentiSelect))
            {
                prozor = new FrmKlijent();
                prozor.ShowDialog();
                UcitajPodatke(klijentiSelect);
            }
            else if (ucitanaTabela.Equals(zaposleniSelect))
            {
                prozor = new FrmZaposleni();
                prozor.ShowDialog();
                UcitajPodatke(zaposleniSelect);
            }
            else if (ucitanaTabela.Equals(osiguranjaSelect))
            {
                prozor = new FrmOsiguranje();
                prozor.ShowDialog();
                UcitajPodatke(osiguranjaSelect);
            }
            else if (ucitanaTabela.Equals(vrsteSelect))
            {
                // prozor = new FrmVrsta();
                // prozor.ShowDialog();
                //UcitajPodatke(vrsteSelect);
                MessageBox.Show("Trenutno nije moguće dodati nove vrste.", "Informacija", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                prozor = new FrmPlacanje();
                prozor.ShowDialog();
                UcitajPodatke(placanjaSelect);
            }
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(destinacijeSelect))
            {
                PopuniFormu(selectUslovDestinacije);
                UcitajPodatke(destinacijeSelect);
            }
            else if (ucitanaTabela.Equals(klijentiSelect))
            {
                PopuniFormu(selectUslovKlijenti);
                UcitajPodatke(klijentiSelect);
            }
            else if (ucitanaTabela.Equals(osiguranjaSelect))
            {
                PopuniFormu(selectUslovOsiguranja);
                UcitajPodatke(osiguranjaSelect);
            }
            else if (ucitanaTabela.Equals(placanjaSelect))
            {
                PopuniFormu(selectUslovPlacanja);
                UcitajPodatke(placanjaSelect);
            }
            else if (ucitanaTabela.Equals(putovanjaSelect))
            {
                PopuniFormu(selectUslovPutovanja);
                UcitajPodatke(putovanjaSelect);
            }
            else if (ucitanaTabela.Equals(rezervacijeSelect))
            {
                PopuniFormu(selectUslovRezervacije);
                UcitajPodatke(rezervacijeSelect);
            }
            else if (ucitanaTabela.Equals(vrsteSelect))
            {
                //PopuniFormu(selectUslovVrste);
                // UcitajPodatke(vrsteSelect);
                MessageBox.Show("Trenutno nije moguće dodati izmjene vrste.", "Informacija", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (ucitanaTabela.Equals(zaposleniSelect))
            {
                PopuniFormu(selectUslovZaposleni);
                UcitajPodatke(zaposleniSelect);
            }
        }
        private void PopuniFormu(string selectUslov)
        {
            try
            {
                konekcija.Open();
                azuriraj = true;
                red = (DataRowView)dataGridCentralni.SelectedItems[0];//pristupamo redu preko centarlnog data grida
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                cmd.CommandText = selectUslov + "@id";
                SqlDataReader citac = cmd.ExecuteReader();
                if (citac.Read())//kada ima sta da cita
                {
                    if (ucitanaTabela.Equals(putovanjaSelect))
                    {
                        FrmPutovanje prozorPutovanje = new FrmPutovanje(azuriraj, red);
                        prozorPutovanje.txtBrojDana.Text = citac["brojDana"].ToString();
                        prozorPutovanje.txtCijena.Text = citac["cijena"].ToString();
                        prozorPutovanje.dpDatum.SelectedDate = (DateTime)citac["datum"];
                        prozorPutovanje.cbVrsta.SelectedValue = citac["vrstaID"].ToString();
                        prozorPutovanje.cbDestinacija.SelectedValue = citac["destinacijaID"].ToString();
                        prozorPutovanje.cbKlijent.SelectedValue = citac["klijentID"].ToString() ;
                        prozorPutovanje.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(vrsteSelect))
                    {
                        FrmVrsta prozorVrsta = new FrmVrsta(azuriraj, red);
                        prozorVrsta.txtVrsta.Text = citac["nazivVrste"].ToString();
                        prozorVrsta.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(destinacijeSelect))
                    {
                        FrmDestinacija prozorDestinacija = new FrmDestinacija(azuriraj, red);
                        prozorDestinacija.txtGrad.Text = citac["grad"].ToString();
                        prozorDestinacija.txtDrzava.Text = citac["drzava"].ToString();
                        prozorDestinacija.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(klijentiSelect))
                    {
                        FrmKlijent prozorKlijent = new FrmKlijent(azuriraj, red);
                        prozorKlijent.txtImeKlijent.Text = citac["ime"].ToString();
                        prozorKlijent.txtPrezimeKlijent.Text = citac["prezime"].ToString();
                        prozorKlijent.txtAdresaKlijent.Text = citac["adresa"].ToString();
                        prozorKlijent.txtKontaktKlijent.Text = citac["kontakt"].ToString();
                        prozorKlijent.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(rezervacijeSelect))
                    {
                        FrmRezervacija prozorRezervacija = new FrmRezervacija(azuriraj, red);
                        prozorRezervacija.txtNazivHotela.Text = citac["nazivHotela"].ToString();
                        prozorRezervacija.cbxPopunjeno.IsChecked = (bool)citac["popunjeno"];
                        prozorRezervacija.cbZaposleni.SelectedValue = citac["zaposleniID"].ToString();
                        prozorRezervacija.cbPutovanje.SelectedValue = citac["putovanjeID"].ToString();
                        prozorRezervacija.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(osiguranjaSelect))
                    {
                        FrmOsiguranje prozorOsiguranje = new FrmOsiguranje(azuriraj, red);
                        prozorOsiguranje.txtBrojPasosa.Text = citac["brojPasosa"].ToString();
                        prozorOsiguranje.txtJmbg.Text = citac["jmbgOsiguranika"].ToString();
                        prozorOsiguranje.txtBrojPolise.Text = citac["brojPolise"].ToString();
                        prozorOsiguranje.txtStarost.Text = citac["starostOsiguranika"].ToString();
                        prozorOsiguranje.cbKlijent.SelectedValue = citac["klijentID"];
                        prozorOsiguranje.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(zaposleniSelect))
                    {
                        FrmZaposleni prozorZaposleni = new FrmZaposleni(azuriraj, red);
                        prozorZaposleni.txtImeZaposleni.Text = citac["imeZaposleni"].ToString();
                        prozorZaposleni.txtPrezimeZaposleni.Text = citac["prezimeZaposleni"].ToString();
                        prozorZaposleni.txtAdresaZaposleni.Text = citac["adresaZaposleni"].ToString();
                        prozorZaposleni.txtKontaktZaposleni.Text = citac["kontaktZaposleni"].ToString();
                        prozorZaposleni.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(placanjaSelect))
                    {
                        FrmPlacanje prozorPlacanje = new FrmPlacanje(azuriraj, red);
                        prozorPlacanje.txtSuma.Text = citac["suma"].ToString();
                        prozorPlacanje.txtPopust.Text = citac["popust"].ToString();
                        prozorPlacanje.dpDatum.SelectedDate = (DateTime)citac["datum"];
                        prozorPlacanje.cbxPlaceno.IsChecked = (bool)citac["placeno"];
                        prozorPlacanje.cbPutovanje.SelectedValue = citac["putovanjeID"];
                        prozorPlacanje.ShowDialog();
                    }

                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                azuriraj = false;
            }

        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(putovanjaSelect))
            {
                ObrisiZapis(putovanjaDelete);
                UcitajPodatke(putovanjaSelect);
            }
            else if (ucitanaTabela.Equals(vrsteSelect))
            {
                //ObrisiZapis(vrsteDelete);
                //UcitajPodatke(vrsteSelect);
                MessageBox.Show("Trenutno nije moguće izbrisati vrste.", "Informacija", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (ucitanaTabela.Equals(destinacijeSelect))
            {
                ObrisiZapis(destinacijeDelete);
                UcitajPodatke(destinacijeSelect);
            }
            else if (ucitanaTabela.Equals(klijentiSelect))
            {
                ObrisiZapis(klijentiDelete);
                UcitajPodatke(klijentiSelect);
            }
            else if (ucitanaTabela.Equals(rezervacijeSelect))
            {
                ObrisiZapis(rezervacijeDelete);
                UcitajPodatke(rezervacijeSelect);
            }
            else if (ucitanaTabela.Equals(osiguranjaSelect))
            {
                ObrisiZapis(osiguranjaDelete);
                UcitajPodatke(osiguranjaSelect);
            }
            else if (ucitanaTabela.Equals(zaposleniSelect))
            {
                ObrisiZapis(zaposleniDelete);
                UcitajPodatke(zaposleniSelect);
            }
            else if (ucitanaTabela.Equals(placanjaSelect))
            {
                ObrisiZapis(placanjaDelete);
                UcitajPodatke(placanjaSelect);
            }
        }
        private void ObrisiZapis(string deleteUpit)
        {
            try
            {
                konekcija.Open();
                red = (DataRowView)dataGridCentralni.SelectedItems[0];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = konekcija
                    }; cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = deleteUpit + "@id";
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugim tabelama.", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

    }
}