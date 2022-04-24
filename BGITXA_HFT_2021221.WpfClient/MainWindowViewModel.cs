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
        public RestCollection<Television> Televisions { get; set; }
        public RestCollection<Order> Orders { get; set; }
        private Television selectedTv;

        public Television SelectedtV
        {
            get { return selectedTv; }
            set
            {
                //SetProperty(ref selectedTv, value);
                if(value != null)
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

        public MainWindowViewModel()
        {
            Televisions = new RestCollection<Television>("http://localhost:9910/", "Television");
            Orders = new RestCollection<Order>("http://localhost:9910/", "Order");

            CreateTvCommand = new RelayCommand(() =>
            {
                Television tv = new Television();
                tv.Price = 0;
                tv.Model = "Default";
                tv.OrderId = 1;
                tv.BrandId = 1;
                //ennyibol megy a torles

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

        }
    }
}

