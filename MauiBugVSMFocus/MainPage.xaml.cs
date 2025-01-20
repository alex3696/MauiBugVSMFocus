using System.Diagnostics;

namespace MauiBugVSMFocus
{
    public partial class MainPage : ContentPage
    {
        int count = 0;


        public MainPage()
        {
            InitializeComponent();
            Routing.RegisterRoute("NewPage1", typeof(NewPage1));
        }

        private async void GoToBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                //await Shell.Current.GoToAsync("NewPage1");
                (App.Current as App)?.GetNavigation().PushAsync(new NewPage1());
            }
            catch (Exception ex)
            { 
                Debug.WriteLine(ex.Message);
            }
        }
        public async Task SetSomeTextAsync(string? str)
        {
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Editor.Text = str;
                Debug.WriteLine($"SetSomeText {str}");
            });
        }
    }

}
