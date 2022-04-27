using BGITXA_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BGITXA_HFT_2021221.WpfClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public List<KeyValuePair<string, double>> AveragePriceOfBrand { get => averagePriceOfBrand; set { SetProperty(ref averagePriceOfBrand, value); } }
        public List<KeyValuePair<string, int>> CountTvByOrder { get => countTvByOrder; set { SetProperty(ref countTvByOrder, value); } }
        public List<KeyValuePair<string, double>> AveragePriceOfOrder { get => averagePriceOfOrder; set { SetProperty(ref averagePriceOfOrder, value); } }
        public List<Order> OrdersInOrderByPrice { get => ordersInOrderByPrice; set { SetProperty(ref ordersInOrderByPrice, value); } }

        public RestCollection<Television> Televisions { get; set; }
        private Television selectedTv;
        private RestService rest;
        private List<KeyValuePair<string, double>> averagePriceOfBrand;
        private List<KeyValuePair<string, int>> countTvByOrder;
        private List<KeyValuePair<string, double>> averagePriceOfOrder;
        private List<Order> ordersInOrderByPrice;

        public Television SelectedtV
        {
            get { return selectedTv; }
            set
            {
                if (value != null)
                {
                    selectedTv = new Television()
                    {
                        Model = value.Model,
                        OrderId = value.OrderId,
                        BrandId = value.BrandId,
                        Price = value.Price,
                        Id = value.Id
                    };
                    OnPropertyChanged();
                    (DeleteTvCommand as RelayCommand).NotifyCanExecuteChanged();
                }

            }
        }

        public ICommand CreateTvCommand { get; set; }
        public ICommand DeleteTvCommand { get; set; }
        public ICommand EditTvCommand { get; set; }
        public ICommand UpdateRequest { get; set; }

        public MainWindowViewModel()
        {
            System.Threading.Thread.Sleep(7000);
            rest = new RestService("http://localhost:9910/");
            Televisions = new RestCollection<Television>("http://localhost:9910/", "Television", "hub");
            RequestUpdate();

            CreateTvCommand = new RelayCommand(() =>
            {
                Television tv = new Television();
                tv.Price = 0;
                tv.Model = "Default";
                tv.OrderId = 1;
                tv.BrandId = 1;

                Televisions.Add(tv);
            });
            DeleteTvCommand = new RelayCommand(() =>
            {
                Televisions.Delete(SelectedtV.Id);
            },
            () =>
            {
                return SelectedtV != null;
            });
            EditTvCommand = new RelayCommand(() =>
            {
                Televisions.Update(SelectedtV);
            });
            UpdateRequest = new RelayCommand(() => RequestUpdate());
        }
        public void RequestUpdate()
        {
            AveragePriceOfBrand = rest.Get<KeyValuePair<string, double>>("/noncrud/AveragePriceOfBrand");
            CountTvByOrder = rest.Get<KeyValuePair<string, int>>("/noncrud/CountTvByOrder");
            AveragePriceOfOrder = rest.Get<KeyValuePair<string, double>>("/noncrud/AveragePriceOfOrder");
            OrdersInOrderByPrice = rest.Get<Order>("/noncrud/OrdersInOrderByPrice");
        }
    }
}

