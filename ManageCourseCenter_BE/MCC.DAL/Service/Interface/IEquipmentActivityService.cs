﻿using MCC.DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Service.Interface;

public interface IEquipmentActivityService
{
    Task<AppActionResult> GetAllEquipmentActivityAsync();
    Task<AppActionResult> GetEquipmentByEquipmentId(int equipmentId);
    Task<AppActionResult> GetEquipmentByManagerId(int managerId);
    Task<AppActionResult> GetEquipmentByRoomId(int roomId);
    Task<AppActionResult> GetEquipmentByRoomNo(int roomNo);
    Task<AppActionResult> GetEquipmentByTimeRange(DateTime from, DateTime to);
}