using FormulaOne.Shared.Models;

namespace FormulaOne.Client.Services;

public interface IRiderService
{
    Task<IEnumerable<Rider>?> All();
    Task<Rider?> GetRider(int id);
    Task<Rider?> AddRider(Rider rider);
    Task<bool> Update(Rider rider);
    Task<bool> Delete(int id);
}