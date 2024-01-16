using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.ObjectModel;

namespace SimpleSample
{
    public class ViewModel
    {
        private Random random;
        private ObservableCollection<Model> data;
        public ObservableCollection<Model> Data
        {
            get; set;
        }
        
        public ViewModel() 
        {
            Data = new ObservableCollection<Model>();
            random = new Random();

            for (int i = 0; i < 10; i++)
            {
                Data.Add(new Model(i, random.Next(0, 20)));
            }
        }
    }
}
