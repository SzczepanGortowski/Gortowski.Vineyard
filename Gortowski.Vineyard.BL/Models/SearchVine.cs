using GalaSoft.MvvmLight;
using Gortowski.Vineyard.Core.Enum;
using Gortowski.Vineyard.Interfaces.Searches;

namespace Gortowski.Vineyard.BL.Models
{
    public class SearchVine : ViewModelBase,ISearchVine
    {
        private VineType? _vineType;
        private GrapeType? _grapeType;

        public int IdRegion { get; set; }

        public string NameVine { get; set; }

        public GrapeType GrapeType
        {
            get => _grapeType ?? GrapeType.All;
            set => _grapeType = value;
        }

        public VineType VineType
        {
            get => _vineType ?? VineType.All;
            set
            {
                _vineType = value;
            }
        }
    }
}
