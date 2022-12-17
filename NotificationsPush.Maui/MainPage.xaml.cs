using Plugin.Firebase.CloudMessaging;

namespace NotificationsPush.Maui;
public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnSubscribeClicked(object sender, EventArgs e)
    {
        await CrossFirebaseCloudMessaging.Current.CheckIfValidAsync();
        await CrossFirebaseCloudMessaging.Current.SubscribeToTopicAsync("Bienvenido");
        this.Status.Text = "Ahora estas suscrito";
        await DisplayAlert("Bienvenido", "Te has suscrito al tema de Bienvenido", "OK");
    }

    private async void OnUnSubscribeClicked(object sender, EventArgs e)
    {
        await CrossFirebaseCloudMessaging.Current.UnsubscribeFromTopicAsync("Bienvenido");
        this.Status.Text = "Ya no estas suscrito";
        await DisplayAlert("Bienvenido", "Te has dado de baja del tema de Bienvenido", "OK");
    }
}
