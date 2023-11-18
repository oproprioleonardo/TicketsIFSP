using TicketsIFSP.Pages;
using TicketsIFSP.Views;

namespace TicketsIFSP;

public partial class MainPage : ContentPage
{
    private readonly IDispatcherTimer timer;
    public List<Developer> Developers { get; set; }

    public MainPage()
    {
        Developers = new List<Developer> {
                new Developer
                {
                    Name = "Leonardo da Silva",
                    Photo = "do_utilizador.png",
                    Description = "Desenvolvedor"
                },
                new Developer
                {
                    Name = "Gustavo André",
                    Photo = "do_utilizador.png",
                    Description = "Desenvolvedor"
                },
                new Developer
                {
                    Name = "Rafael Dias",
                    Photo = "do_utilizador.png",
                    Description = "Design"
                }

            };
        InitializeComponent();

        BindingContext = this;

        timer = Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromMilliseconds(9000);
        timer.Tick += (s, e) =>
        {
            if (carouselView.Position < ((List<Developer>)carouselView.ItemsSource).Count - 1)
            {
                carouselView.Position += 1;
            }
            else
            {
                carouselView.Position = 0;
            }
        };
        timer.Start();
    }

    private async void FlexLayoutTapped(object sender, TappedEventArgs e)
    {
        var border = (Border)sender;


        await border.ScaleTo(0.95, 100);
        await border.FadeTo(0.7, 100);
        await border.ScaleTo(1, 100);
        await border.FadeTo(1, 100);

        if (border.ClassId == "qrCode")
        {
            await Shell.Current.GoToAsync($"{nameof(QrCodeReaderPage)}");
        }
        else if (border.ClassId == "events")
        {
            await Shell.Current.GoToAsync($"{nameof(EventsPage)}");
        }

    }

    public partial class Developer
    {
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
    }

}



