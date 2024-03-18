using MCC.DAL.DB.Models;
using MCC.DAL.Dto.ChildDto;
using MCC.DAL.Dto.ParentDto;

namespace MCC.DAL.Repository.Interface;

public interface IParentRepository : IRepositoryGeneric<Parent>
{
    Task<Parent> LoginAsync(string email, string password);
    Task<IEnumerable<Child>> GetChildFromParentIdAsync(int id);
    Task<IEnumerable<Child>> GetChildFromParentEmailAsync(string email);
    Task<bool> CheckExistingEmailAsync(string email);
    Task<bool> CheckExistingPhoneAsync(string phone);
    Task<Parent> GetParentByEmailAndPasswordAsync(string email, string password);
    Task<IQueryable<Child>> GetAllChildFromParentIdAsync(int id);
    Task AddChildAsync(Child child);
    Task UpdateChildrenAsync(int parentId, IEnumerable<ChildUpdateDto> childUpdates);

    Task<bool> IsOlderThan18(DateTime birthday);

}
