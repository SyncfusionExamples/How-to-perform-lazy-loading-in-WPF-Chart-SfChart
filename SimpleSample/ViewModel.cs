using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Xaml.Schema;

namespace SimpleSample
{
    public class ViewModel : INotifyPropertyChanged
    {
        private Random random;
        private ObservableCollection<Model> data;
        public ObservableCollection<Model> Data
        {
            get { return data; }
            set
            {
                data = value;
                RaisePropertyChanged("Data");
            }
        }
        
        public ViewModel() 
        {
            var data1 = new ObservableCollection<Model>();
            random = new Random();
            
            for(int i = 0; i < 10; i++)
            {
                data1.Add(new Model(i, random.Next(0, 20)));                
            }

            Data = data1;
        }
        
        public event PropertyChangedEventHandler? PropertyChanged;

        void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
