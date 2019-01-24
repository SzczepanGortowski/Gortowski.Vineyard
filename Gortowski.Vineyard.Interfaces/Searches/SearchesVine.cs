using Gortowski.Vineyard.Core.Enum;

namespace Gortowski.Vineyard.Interfaces.Searches
{
    public interface ISearchVine
    {
        string NameVine { get; set; }

        GrapeType GrapeType { get; set; }

        VineType VineType { get; set; }

        int IdRegion { get; set; }
    }
}



