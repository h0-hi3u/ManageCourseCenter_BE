using MCC.DAL.DB.Models;
using MCC.DAL.EntityModels;
using MCC.DAL.Repository.Implements;
using MCC.DAL.Repository.Interface;
using MCC.DAL.Service.Interface;

namespace MCC.DAL.Service.Implements;

public class ManagerService : IManagerService
{
    IManagerRepository _managerRepo;

    public ManagerService(IManagerRepository managerRepo)
    {
        _managerRepo = managerRepo;
    }

    public async Task CreateAsync(Manager entity)
    {
        var checkEmail = await _managerRepo.CheckExistingEmailAsync(entity.Email);
        if(checkEmail)
        {
            await _managerRepo.AddAsync(entity);
            await _managerRepo.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var exsiting =  await _managerRepo.GetByIdAsync(id);
        if(exsiting != null)
        {
            _managerRepo.Delete(exsiting);
            await _managerRepo.SaveChangesAsync();
        }
    }

    public async Task<Manager> GetByIdAsync(int id)
    {
        return await _managerRepo.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Manager>> GetListAsync()
    {
        return await _managerRepo.GetAllAsync();
    }

    public async Task UpdateAsync(Manager entity)
    {
        var existing = await _managerRepo.GetByIdAsync(entity.Id);
        if(existing != null)
        {
            existing.FullName = entity.FullName;
            existing.Email = entity.Email;
            existing.Phone = entity.Phone;
            existing.BirthDay = entity.BirthDay;
            existing.Gender = entity.Gender;
            existing.Role = entity.Role;
            existing.Status = entity.Status;
            _managerRepo.Update(existing);
            await _managerRepo.SaveChangesAsync();
        }

    }
}
