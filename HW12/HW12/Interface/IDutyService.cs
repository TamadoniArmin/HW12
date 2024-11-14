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
        public void AddDuty(string Name, string Ditails, TaskPriorityEnum taskPriorityEnum, DateTime date);
        public void ShowAllDuties();
        public void ChangeDutyInfo(int task, int Id, string? name, string? ditails, DateTime date, TaskPriorityEnum priorityEnum);
        public void RemoveDuty(int Id);
        public void ChangeDutyStatus(int id, int task);
        public Duty SearchByName(string name);
    }
}
