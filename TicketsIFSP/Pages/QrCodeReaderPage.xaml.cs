using TicketsIFSP.Handlers;
using TicketsIFSP.Models;
using TicketsIFSP.Providers;
using TicketsIFSP.Utils;
using ZXing;

namespace TicketsIFSP.Views;

public partial class QrCodeReaderPage : ContentPage
{

    private readonly IGuestProvider guestProvider;
    private readonly IGuestHandler guestHandler;

    public QrCodeReaderPage(IGuestProvider guestProvider, IGuestHandler guestHandler)
    {
        this.guestProvider = guestProvider;
        this.guestHandler = guestHandler;
        InitializeComponent();
        cameraView.BarCodeOptions = new()
        {
            AutoRotate = true,
            ReadMultipleCodes = false,
            TryHarder = true,
            TryInverted = false,
            PossibleFormats = new List<BarcodeFormat>
            {
                BarcodeFormat.QR_CODE
            },
            CharacterSet = "UTF-8",
        };
        cameraView.ControlBarcodeResultDuplicate = true;
        cameraView.BarCodeDetectionEnabled = true;
        cameraView.ForceAutoFocus();
    }

    private void cameraView_BarcodeDetected(object sender, Camera.MAUI.ZXingHelper.BarcodeEventArgs args)
    {
        var rs = args.Result[0];
        MainThread.BeginInvokeOnMainThread(() =>
        {
            barcodeResult.Text = "";
            if (UUIDUtils.IsValidUUID(rs.Text)) { 
                RedirectToPersonDataPage(rs.Text);
            }
            else
                barcodeResult.Text = "Código inválido";
        });
    }

    private async void RedirectToPersonDataPage(string id)
    {
        Guest guest = await guestProvider.FindGuestById(id);
        if (guest == null)
        {
            await DisplayAlert("Erro", "Não foi possível encontrar o convidado", "OK");
            return;
        }

        MainThread.BeginInvokeOnMainThread(async () =>
        {
            var navigationParameter = new Dictionary<string, object>{{ "Guest", guest }, { "Handler", guestHandler} };
            await Shell.Current.GoToAsync($"{nameof(PersonDataPage)}", navigationParameter);
        });
    }

    private void cameraView_CamerasLoaded(object sender, EventArgs e)
    {
        if (cameraView.Cameras.Count > 0)
        {
            cameraView.Camera = cameraView.Cameras.First();
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await cameraView.StopCameraAsync();
                await cameraView.StartCameraAsync();
            });
        }
    }

    private void ContentPage_NavigatedFrom(object sender, NavigatedFromEventArgs e)
    {
        
    }
}