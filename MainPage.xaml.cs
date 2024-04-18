using grossetapp.Nuova_cartella;
using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace grossetapp
{
    public partial class grossetapp : ContentPage
    {

        private readonly HttpClient _httpClient = new HttpClient();
        private string grossetoUrl = "https://api.jsonbin.io/v3/b/6620334ce41b4d34e4e60a2c";

        public ObservableCollection<Record> CittaDiGrosseto = new();


        public grossetapp()
        {
            InitializeComponent();
            CittaCollectionView.ItemsSource = CittaDiGrosseto;

            CaricaDatiDiGrosseto();

        }
        private async void CaricaDatiDiGrosseto()
        {
            try
            {
                var grossetoResponse = await _httpClient.GetFromJsonAsync<Root>(grossetoUrl);
                if (grossetoResponse != null && grossetoResponse.record != null)
                {
                    var rG = grossetoResponse.record;
                    string nomeSindaco = rG.Sindaco;
                    string numeroAbitanti = rG.Abitanti;

                    CittaDiGrosseto.Add(new Record { Sindaco = nomeSindaco, Abitanti = numeroAbitanti });
                }
                else
                {
                    Console.WriteLine("Dati non validi");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
            }



        }


    }

}