using Microsoft.UI.Xaml.Controls;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace MauiBugVSMFocus;

public partial class NewPage1 : ContentPage
{
    public NewPage1()
	{
        InitializeComponent();
        //BindingContext = vm;
    }

    private async void GoToRoot_Clicked(object sender, EventArgs e)
    {
        await GoToRoot();
    }

    public async Task GoToRoot()
    {
        try
        {
            if (App.Current is App app)
            {
                // if you call Navigate here, error does not appear
                // await app.GetNavigation().PopToRootAsync();

                if (App.Current.Windows[0].Page is FlyoutPage fp
                    && fp.Detail is NavigationPage np
                    && np.RootPage is MainPage mp)
                {
                    await Task.Run(() => mp.SetSomeTextAsync("text"));
                }
                await app.GetNavigation().PopToRootAsync();
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
    }
}