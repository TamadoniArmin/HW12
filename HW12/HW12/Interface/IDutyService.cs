using HW12.DB;
using HW12.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Interface
{
    public interface IDutyService
    {
        public void AddDuty(string Name, TaskPriorityEnum taskPriorityEnum, int userId, DateTime date);
        public List<Duty> ShowAllDuties(int userId);
        public void ChangeDutyInfo(int userId,int task, int Id, string? name, string? ditails, DateTime? date, TaskPriorityEnum? priorityEnum);
        public void RemoveDuty(int Id,int userId);
        public void ChangeDutyStatus(int id, int task,int UserId);
        public List<Duty> SearchByName(int userId, string name);
    }
}
