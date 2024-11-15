using HW12.DB;
using HW12.Interface;
using HW12.Task;
using HW12.Tools;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Service
{
    public class DutyService : IDutyService
    {
        AppDbContext context = new AppDbContext();
        public void AddDuty(string Name,TaskPriorityEnum taskPriorityEnum,int userId ,DateTime date)
        {
            InMemoryDatabase.CheckUserLogin();
            var OnlineuserId = InMemoryDatabase.OnlineUser.Id;
            var duty = new Duty()
            {
                DutyName = Name,
                Priority = taskPriorityEnum,
                Date = date
            };
            context.Duties.Add(duty);
            context.SaveChanges();
        }
        public List<Duty> ShowAllDuties(int userId)
        {
            InMemoryDatabase.CheckUserLogin();
            return context.Duties.Where(x => x.UserId == userId).OrderBy(x => x.Date).ToList();
        }
        public void ChangeDutyInfo(int task,int Id,string? name,string? ditails,DateTime? date,TaskPriorityEnum? priorityEnum)
        {
            InMemoryDatabase.CheckUserLogin();
            try
            {
                var duty = context.Duties.FirstOrDefault(D => D.Id == Id);
                if (duty is not null)
                {
                    switch (task)
                    {
                        case 1:
                            duty.DutyName = name;
                            context.SaveChanges();
                            break;
                        case 2:
                            duty.Ditails = ditails;
                            context.SaveChanges();
                            break;
                        case 3:
                            duty.Date = date;
                            context.SaveChanges();
                            break;
                        case 4:
                            duty.Priority = priorityEnum;
                            context.SaveChanges();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    throw new Exception($"Connot find item with id {Id}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }
        public void RemoveDuty(int Id)
        {
            InMemoryDatabase.CheckUserLogin();
            var duty = context.Duties.FirstOrDefault(D => D.Id == Id);
            if (duty is not null)
            {
                context.Remove(duty);
                context.SaveChanges();
            }
            else
            {
                throw new Exception($"Connot find item with id {Id}");
            }
        }
        public void ChangeDutyStatus(int id,int task)
        {
            InMemoryDatabase.CheckUserLogin();
            try
            {
                var duty = context.Duties.FirstOrDefault(D => D.Id == id);
                if (duty is not null)
                {
                    switch (task)
                    {
                        case 1:
                            duty.Status = StatusEnum.InProcess;
                            context.SaveChanges();
                            break;
                        case 2:
                            duty.Status = StatusEnum.Done;
                            context.SaveChanges();
                            break;
                        case 3:
                            duty.Status = StatusEnum.Cancelled;
                            context.SaveChanges();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    throw new Exception($"Connot find item with id {id}");
                }
                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            } 
        }
        public List<Duty> SearchByName(int userId,string name)
        {
            InMemoryDatabase.CheckUserLogin();
            var duties = context.Duties.Where(D => D.UserId==userId && D.DutyName.Contains(name)).ToList();
            return duties;
        }
    }
}
