using TicketsIFSP.Handlers;
using TicketsIFSP.Models;

namespace TicketsIFSP.Views;

[QueryProperty(nameof(Guest), nameof(Guest))]
public partial class PersonDataPage : ContentPage
{
    Guest guest;

    IGuestHandler guestHandler;

    public Guest Guest
    {
        get => guest;
        set
        {
            guest = value;
            OnPropertyChanged();
        }
    }

    public IGuestHandler IGuestHandler
    {
        get => guestHandler;
        set
        {
            guestHandler = value;
            OnPropertyChanged();
        }
    }

    public PersonDataPage(IGuestHandler guestHandler)
    {
        InitializeComponent();
        BindingContext = this;
        this.guestHandler = guestHandler;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (!Guest.EntranceCheckIn)
        {
            Guest g = await guestHandler.Enter(Guest);
            Guest.EntranceCheckIn = true;
            Guest.EntranceNumber = g.EntranceNumber;
        }
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        if (!Guest.ExitCheckIn)
        {
            Guest.ExitCheckIn = true;
            guestHandler.Left(Guest);
        }
    }
}