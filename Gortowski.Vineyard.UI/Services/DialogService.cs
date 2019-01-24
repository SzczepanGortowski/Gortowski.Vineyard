using Gortowski.Vineyard.BL.Services;
using Gortowski.Vineyard.Interfaces;
using Gortowski.Vineyard.Interfaces.Entities;
using Gortowski.Vineyard.UI.Bootstrap;
using Gortowski.Vineyard.UI.ViewModel;
using Gortowski.Vineyard.UI.Views;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Gortowski.Vineyard.UI.Services
{
    internal class DialogService : IDialogService
    {
        private Dictionary<string, Window> _guids;

        public DialogService()
        {
            _guids = new Dictionary<string, Window>();
        }

        public void Close(string guid)
        {
            if (_guids.TryGetValue(guid, out Window window))
            {
                _guids.Remove(guid);
                window.Close();
                return;
            }
        }

        public void MessageError(string text)
        {
            MessageBox.Show(text, "Error", MessageBoxButton.OK);
        }

        public void Show(IEntity entity)
        {
            var typeEntity = entity.GetType();
            var guid = Guid.NewGuid().ToString();
            Window view;

            if (typeEntity.GetInterfaces().Contains(typeof(IVine)))
            {
                view = new VineView
                {
                    DataContext = KernelMain.KernelInstance.Get<VineViewModel>()
                };
            }
            else
            {
                view = new RegionView
                {
                    DataContext = KernelMain.KernelInstance.Get<RegionViewModel>()
                };
            }

            ((IViewModel)view.DataContext).Initialize(entity, guid);

            _guids.Add(guid, view);

            view.ShowDialog();
        }
    }
}
