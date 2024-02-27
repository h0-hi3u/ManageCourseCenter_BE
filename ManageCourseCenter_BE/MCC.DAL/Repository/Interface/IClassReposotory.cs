﻿using MCC.DAL.DB.Models;

namespace MCC.DAL.Repository.Interface;

public interface IClassReposotory : IRepositoryGeneric<Class>
{
    Task<IEnumerable<Class>> GetCourseByNameAsync(string name);
}
