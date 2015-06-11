using Demo.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel;

namespace Demo.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private bool _loaded;
        private bool _loading;

        public MainViewModel()
        {
            Photos = new ObservableCollection<Photo>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool Loaded
        {
            get
            {
                return _loaded;
            }
            set
            {
                _loaded = value;
                RaisePropertyChange(nameof(Loaded));
            }
        }

        public bool Loading
        {
            get
            {
                return _loading;
            }
            set
            {
                _loading = value;
                RaisePropertyChange(nameof(Loading));
                Loaded = !value;
            }
        }

        public ObservableCollection<Photo> Photos { get; private set; }

        public async Task Load()
        {
            this.Loading = true;
            var directoryInfo = new DirectoryInfo(@"C:\Users\v-robmc\Desktop\demoimages");
            var files = directoryInfo.EnumerateFiles().ToArray();
            foreach (var item in files.Where(file => file.Extension == ".jpg"))
            {
                var photo = new Photo();
                await photo.Load(Path.Combine(@"C:\Users\v-robmc\Desktop\demoimages", item.Name));
                Photos.Add(photo);
            }

            this.Loading = false;
        }

        private void RaisePropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}