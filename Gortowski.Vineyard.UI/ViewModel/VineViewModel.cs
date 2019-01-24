using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Gortowski.Vineyard.BL.Services;
using Gortowski.Vineyard.Core.Enum;
using Gortowski.Vineyard.Interfaces;
using Gortowski.Vineyard.Interfaces.Entities;
using Gortowski.Vineyard.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Gortowski.Vineyard.UI.ViewModel
{
    public class VineViewModel : ViewModelBase, IViewModel
    {
        private string _guid;
        private IVine _vine;
        private readonly IDialogService _dialogService;
        private readonly IVineService _vineService;
        private readonly IRegionService _regionService;
        private readonly ObservableCollection<IRegion> _regions;

        public VineViewModel(IDialogService dialogService, IVineService vineService, IRegionService regionService)
        {
            _dialogService = dialogService;
            _vineService = vineService;
            _regionService = regionService;
            _regions = _regionService.GetRegions();
        }

        public IVine Vine
        {
            get => _vine;
            set { _vine = value; }
        }

        public IEnumerable<GrapeType> GrapeTypes => _vineService.GrapeTypes(false);

        public IEnumerable<VineType> VineTypes => _vineService.VineTypes(false);

        public ObservableCollection<IRegion> Regions
        {
            get => _regions;
        }

        public RelayCommand SaveCommand => new RelayCommand(AddEditVine);

        public void AddEditVine()
        {
            if(_vine.Name == null)
            {
                _dialogService.MessageError("Wszystkie pola są wymagane");
                return;
            }

            _vineService.Save(Vine);
            _dialogService.Close(_guid);
        }

        public void Initialize(IEntity entity, string guid)
        {
            Vine = (IVine)entity;
            _guid = guid;

            if(entity.Id == 0)
            {
                _vine.GrapeType = GrapeTypes.FirstOrDefault();
                _vine.VineType = VineTypes.FirstOrDefault();
                _vine.Region = Regions.FirstOrDefault();
            }
        }
    }
}
