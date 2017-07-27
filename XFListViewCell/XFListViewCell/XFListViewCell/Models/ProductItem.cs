using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFListViewCell.Models
{
    public class ProductItem : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }
        public int price { get; set; }
        public int number { get; set; }

    }
}
