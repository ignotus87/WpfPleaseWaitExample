using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BusyIndicatorExample
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<string> _itemsList;
        public List<string> ItemsList
        {
            get { return _itemsList; }
            set
            {
                _itemsList = value;
                NotifyPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            ItemsList = new List<string> { "Please click on the button above to fill me with items!" };
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
