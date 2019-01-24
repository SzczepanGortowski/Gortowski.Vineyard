using Gortowski.Vineyard.Interfaces.Entities;

namespace Gortowski.Vineyard.BL.Services
{
    public interface IDialogService
    {
        void Show(IEntity entity);
        void Close(string guid);
        void MessageError(string text);
    }
}