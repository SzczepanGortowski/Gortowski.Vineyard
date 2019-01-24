using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Gortowski.Vineyard.BL.Models;
using Gortowski.Vineyard.BL.Services;
using Gortowski.Vineyard.Core.Enum;
using Gortowski.Vineyard.Interfaces.Entities;
using Gortowski.Vineyard.Interfaces.Searches;
using Gortowski.Vineyard.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Gortowski.Vineyard.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<IRegion> _regions;
        private ObservableCollection<IVine> _vines;
        private readonly IDialogService _dialogService;
        private readonly IVineService _vineService;
        private readonly IRegionService _regionService;
        private SearchVine _searchesVine;
        private IRegion _selectedRegion;
        private IVine _selectedVine;

        public MainViewModel(IDialogService dialogService, IRegionService regionService, IVineService vineService)
        {
            _dialogService = dialogService;
            _regionService = regionService;

            _vineService = vineService;
            _searchesVine = new SearchVine();
            LoadCollection();
        }

        public RelayCommand DeleteVineCommand => new RelayCommand(() => DeleteVine(), () => CanDelete(SelectedVine), true);
        public RelayCommand DeleteRegionCommand => new RelayCommand(() => DeleteRegion(), () => CanDelete(SelectedRegion) && _searchesVine.IdRegion != 0, true);

        public RelayCommand EditVineCommand => new RelayCommand(() => OpenWindow(SelectedVine), () => CanDelete(SelectedVine), true);
        public RelayCommand EditRegionCommand => new RelayCommand(() => OpenWindow(SelectedRegion), () => CanDelete(SelectedRegion) && _searchesVine.IdRegion != 0, true);

        public RelayCommand OpenVineCommand => new RelayCommand(() => OpenWindow(new Vine()));
        public RelayCommand OpenRegionCommand => new RelayCommand(() => OpenWindow(new Region()));

        public ObservableCollection<IVine> Vines
        {
            get => _vines;
            set
            {
                _vines = value;
                RaisePropertyChanged(() => Vines);
            }
        }

        public ObservableCollection<IRegion> Regions
        {
            get => _regions;
            set
            {
                _regions = value;
                RaisePropertyChanged(() => Regions);
            }
        }

        public IVine SelectedVine
        {
            get => _selectedVine;
            set
            {
                _selectedVine = value;
                RaisePropertyChanged(() => SelectedVine);
                RaisePropertyChanged(() => DeleteVineCommand);
                RaisePropertyChanged(() => EditVineCommand);

            }
        }

        public VineType SelectedVineType
        {
            get => _searchesVine.VineType;
            set
            {
                _searchesVine.VineType = value;
                RaisePropertyChanged(() => SelectedVineType);
                FilterVine();

            }
        }

        public GrapeType SelectedGrype
        {
            get => _searchesVine.GrapeType;
            set
            {
                _searchesVine.GrapeType = value;
                RaisePropertyChanged(() => SelectedGrype);
                FilterVine();
            }
        }

        public IRegion SelectedRegion
        {
            get => _selectedRegion;
            set
            {
                _selectedRegion = value;
                _searchesVine.IdRegion = value == null ? 0 : value.Id;
                RaisePropertyChanged(() => SelectedRegion);
                RaisePropertyChanged(() => DeleteRegionCommand);
                RaisePropertyChanged(() => EditRegionCommand);
                FilterVine();
            }
        }

        public string NameVine
        {
            get => _searchesVine.NameVine;
            set
            {
                _searchesVine.NameVine = value;
                RaisePropertyChanged(() => NameVine);
                FilterVine();
            }
        }

        private IRegion GetAllRegion => Regions.FirstOrDefault(x => x.Id == -1);

        public IEnumerable<GrapeType> GrapeTypes => _vineService.GrapeTypes(true);

        public IEnumerable<VineType> VineTypes => _vineService.VineTypes(true);

        private static bool CanDelete(IEntity entity) => entity != null && entity.Id != -1;

        private bool CanAddProduct() => Regions.Count(x => x.Id != -1) > 0;

        private void DeleteVine()
        {
            _vineService.Delete(SelectedVine.Id);
            Vines.Remove(SelectedVine);
        }

        private void DeleteRegion()
        {
            _regionService.Delete(SelectedRegion.Id);
            Regions.Remove(SelectedRegion);
            SelectedRegion = Regions.FirstOrDefault();
        }

        private void FilterVine()
        {
            Vines = _vineService.Filter(_searchesVine);
            RaisePropertyChanged(() => Vines);
        }

        private void LoadCollection()
        {
            Regions = _regionService.GetRegions(true);
            Vines = _vineService.GetVines();
        }

        private void OpenWindow(IEntity entity)
        {
            _dialogService.Show(entity);
            LoadCollection();
            FilterVine();
        }
    }
}