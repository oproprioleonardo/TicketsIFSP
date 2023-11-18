using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TicketsIFSP.Models
{

    [Serializable]
    [JsonObject]
    public class Guest : INotifyPropertyChanged
    {

        private string id;
        [JsonProperty("id")]
        public string Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged();
                }
            }
        }

        private int entranceNumber;
        [JsonProperty("enter_id")]
        public int EntranceNumber
        {
            get { return entranceNumber; }
            set
            {
                if (entranceNumber != value)
                {
                    entranceNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        private string name;
        [JsonProperty("name")]
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged();
                }
            }
        }

        private string email;
        [JsonProperty("email")]
        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged();
                }
            }
        }

        private int age;
        [JsonProperty("age")]
        public int Age
        {
            get { return age; }
            set
            {
                if (age != value)
                {
                    age = value;
                    OnPropertyChanged();
                }
            }
        }

        private string document;
        [JsonProperty("document")]
        public string Document
        {
            get { return document; }
            set
            {
                if (document != value)
                {
                    document = value;
                    OnPropertyChanged();
                }
            }
        }

        private string phoneNumber;
        [JsonProperty("phone_number")]
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (phoneNumber != value)
                {
                    phoneNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        private string eventId;
        [JsonProperty("event_id")]
        public string EventId
        {
            get { return eventId; }
            set
            {
                if (eventId != value)
                {
                    eventId = value;
                    OnPropertyChanged();
                }
            }
        }

        private GuestProfile profile;
        [JsonProperty("profile")]
        public GuestProfile Profile
        {
            get { return profile; }
            set
            {
                if (profile != value)
                {
                    profile = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool banned;
        [JsonProperty("is_banned")]
        public bool Banned
        {
            get { return banned; }
            set
            {
                if (banned != value)
                {
                    banned = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool entranceCheckIn;
        [JsonProperty("is_entered")]
        public bool EntranceCheckIn
        {
            get { return entranceCheckIn; }
            set
            {
                if (entranceCheckIn != value)
                {
                    entranceCheckIn = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool exitCheckIn;
        [JsonProperty("is_left")]
        public bool ExitCheckIn
        {
            get { return exitCheckIn; }
            set
            {
                if (exitCheckIn != value)
                {
                    exitCheckIn = value;
                    OnPropertyChanged();
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public Guest()
        {
        }

        public Guest(string id, int entranceNumber, string name, string email, int age, string document, string phoneNumber, string eventId, GuestProfile profile, bool banned, bool entranceCheckIn, bool exitCheckIn)
        {
            Id = id;
            Name = name;
            Email = email;
            Document = document;
            PhoneNumber = phoneNumber;
            Age = age;
            EventId = eventId;
            Profile = profile;
            Banned = banned;
            EntranceCheckIn = entranceCheckIn;
            ExitCheckIn = exitCheckIn;
            EntranceNumber = entranceNumber;
        }

        public override string ToString() => $"Id: {Id}, EntranceNumber: {EntranceNumber}, Name: {Name}, Email: {Email}, Age: {Age}, Document: {Document}, PhoneNumber: {PhoneNumber}, EventId: {EventId}, Profile: {Profile}, Banned: {Banned}";

    }
}
