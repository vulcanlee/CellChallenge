using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using XFListViewCell.Models;

namespace XFListViewCell.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public int SumCost { get; set; }
        public bool ShowBusyMark { get; set; }


        public ObservableCollection<ProductItem> ProductItems { get; set; } = new ObservableCollection<ProductItem>();
        public ProductItem SelectedProductItem { get; set; }


        public DelegateCommand CalSumCommand { get; set; }


        public MainPageViewModel()
        {
            CalSumCommand = new DelegateCommand(async () =>
            {
                // 使用這樣寫法，與直接呼叫 CalculateSum() 方法，有何不同呢？
                await Task.Factory.StartNew(async () =>
                {
                    ShowBusyMark = true;
                    CalculateSum();
                    await Task.Delay(2000);
                    ShowBusyMark = false;
                });
            });

        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            Init();
            ShowBusyMark = true;
            CalculateSum();
            await Task.Delay(2000);
            ShowBusyMark = false;
        }

        public void Init()
        {
            ProductItems.Clear();
            ProductItems.Add(new ProductItem
            {
                Name = "iPhone 7 Plus 太空金",
                price = 28000,
                number = 2,
                UpdateSumCommand = new DelegateCommand(CalculateSum),
            });
            ProductItems.Add(new ProductItem
            {
                Name = "60天世界旅遊一周",
                price = 168168,
                number = 1,
                UpdateSumCommand = new DelegateCommand(CalculateSum),
            });
            ProductItems.Add(new ProductItem
            {
                Name = "32\"重乳酪起司",
                price = 742,
                number = 2,
                UpdateSumCommand = new DelegateCommand(CalculateSum),
            });
            ProductItems.Add(new ProductItem
            {
                Name = "海港自助餐劵",
                price = 468,
                number = 8,
                UpdateSumCommand = new DelegateCommand(CalculateSum),
            });
        }

        public void CalculateSum()
        {
            SumCost = 0;
            foreach (var item in ProductItems)
            {
                SumCost += item.price * item.number;
            }
        }
    }
}
