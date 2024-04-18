using grossetapp.modMeteo;
using System.Collections.ObjectModel;
using System.Net.Http.Json;


namespace Esercizio18Aprile;

public partial class MeteoPage : ContentPage
{
    private readonly HttpClient _httpClient = new HttpClient();

    private ObservableCollection<Daily> DatiDelGirno = new();
    public MeteoPage()
    {
        InitializeComponent();
        MeteoCollectionView.ItemsSource = DatiDelGirno;

        CaricaDatiDelMeteo();

    }
    private async void CaricaDatiDelMeteo()
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<Root>("https://api.jsonbin.io/v3/b/662034fead19ca34f85bbe8b");
            foreach (var daily in response.record.timelines.daily)
            {
                DatiDelGirno.Add(daily);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Errore: {ex.Message}");
        }
    }
}