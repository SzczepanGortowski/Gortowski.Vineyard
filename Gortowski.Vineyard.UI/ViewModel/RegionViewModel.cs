using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Gortowski.Vineyard.BL.Services;
using Gortowski.Vineyard.Interfaces;
using Gortowski.Vineyard.Interfaces.Entities;
using Gortowski.Vineyard.Interfaces.Services;


namespace Gortowski.Vineyard.UI.ViewModel

{
    internal class RegionViewModel : ViewModelBase, IViewModel
    {
        private string _guid;
        private IRegion _region;
        private readonly IDialogService _dialogService;
        private readonly IRegionService _regionsService;

        public RegionViewModel(IRegionService producerService, IDialogService dialogService)
        {
            _dialogService = dialogService;
            _regionsService = producerService;
        }

        public IRegion Region
        {
            get => _region;
            set
            {
                _region = value;
            }
        }

        public RelayCommand SaveCommand => new RelayCommand(AddRegion);

        private bool CanAddEdit() => _region.Country != null && _region.Name != null;

        public void Initialize(IEntity entity, string guid)
        {
            _region = (IRegion)entity;
            _guid = guid;
        }

        public void AddRegion()
        {
            if(!CanAddEdit())
            {
                _dialogService.MessageError("Wszystkie pola są wymagane");
                return;
            }

            _regionsService.Save(Region);
            _dialogService.Close(_guid);
        }
    }
}