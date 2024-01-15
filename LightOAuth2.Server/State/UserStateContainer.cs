using System.ComponentModel;

namespace LightOAuth2.Server.State
{
    public class UserStateContainer : INotifyPropertyChanged
    {

        public bool? IsLogin { get; set; }


        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
