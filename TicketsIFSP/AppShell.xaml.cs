using TicketsIFSP.Pages;
using TicketsIFSP.Views;

namespace TicketsIFSP;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
		Routing.RegisterRoute(nameof(QrCodeReaderPage), typeof(QrCodeReaderPage));
		Routing.RegisterRoute(nameof(PersonDataPage), typeof(PersonDataPage));
		Routing.RegisterRoute(nameof(EventsPage), typeof(EventsPage));

	}
}
