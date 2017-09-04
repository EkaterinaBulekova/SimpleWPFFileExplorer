using System.ComponentModel;
using PropertyChanged;

namespace WpfFileExplorer
{
    /// <summary>
    /// A base view model the fires Property changed as needed
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The event that is fired when any child property changed its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}
