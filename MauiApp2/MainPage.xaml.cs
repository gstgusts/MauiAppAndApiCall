using MauiApp2.Models;
using Newtonsoft.Json;

namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public static string BaseAddress =
            DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5205" : "http://localhost:5205";

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"{BaseAddress}/api/Student");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();

            var students = JsonConvert.DeserializeObject<Student[]>(json);
        }
    }

}
