using FormulaOne.Shared.Models;

namespace FormulaOne.Client.Services;

public interface IRiderService
{
    Task<IEnumerable<Rider>?> All();
    Task<Rider?> GetDriver(int id);
    Task<Rider?> AddDriver(Rider rider);
    Task<bool> Update(Rider rider);
    Task<bool> Delete(Rider rider);
}