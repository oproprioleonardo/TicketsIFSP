using System.Collections.ObjectModel;
using TicketsIFSP.Models;
using TicketsIFSP.Providers;

namespace TicketsIFSP.Pages;

public partial class EventsPage : ContentPage
{

    private ObservableCollection<IfspEvent> events;
    public ObservableCollection<IfspEvent> Events
    {
        get => events;
        set
        {
            events = value;
            OnPropertyChanged(nameof(Events));
        }
    }
    private readonly IEventProvider eventProvider;

    public EventsPage(IEventProvider eventProvider)
    {
        this.eventProvider = eventProvider;
        InitializeComponent();
        BindingContext = this;
        Events = new ObservableCollection<IfspEvent>();
    }

    private async void SearchEvents()
    {
        List<IfspEvent> searchedEvents = await eventProvider.FindEvents();
        Events.Clear();
        foreach (IfspEvent searchedEvent in searchedEvents)
        {
            Events.Add(searchedEvent);
        }
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        SearchEvents();
    }
}