﻿using MCC.DAL.Common;
using MCC.DAL.DB.Models;
using MCC.DAL.Dto.ManagerDto;
using System.Globalization;

namespace MCC.DAL.Repository.Interface;

public interface IManagerRepository : IRepositoryGeneric<Manager>
{
    Task<bool> CheckExistingEmailAsync(string email);
    Task<bool> CheckExistingPhoneAsync(string phone);
    Task<Manager> GetAdminByUsernameAndPassword(string username, string password);
    Task<Manager> GetStaffByUsernameAndPassword(string username, string password);
    Task<Manager> GetManagerByEmailAndPasswordAsync(string email, string password);
    Task<bool> ChangePasswordStaffAsync(int staffId, string newPassword);
}
