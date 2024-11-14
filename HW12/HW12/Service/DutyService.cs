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
        public void AddDuty(string Name, string Ditails,TaskPriorityEnum taskPriorityEnum ,DateTime date)
        {
            var duty = new Duty()
            {
                DutyName = Name,
                Ditails = Ditails,
                Priority = taskPriorityEnum,
                Date = date
            };
            context.Duties.Add(duty);
            context.SaveChanges();
        }
        public void ShowAllDuties()
        {
            var Duties = context.Duties.OrderBy(D=>D.Date).ToList();
            foreach (var duty in Duties)
            {
                Console.WriteLine($"{duty.Id} - {duty.DutyName}:({duty.Ditails})");
                Console.WriteLine($"date: {duty.Date} Priority: {duty.Priority} Status:{duty.Status}");
            }
        }
        public void ChangeDutyInfo(int task,int Id,string? name,string? ditails,DateTime? date,TaskPriorityEnum? priorityEnum)
        {
            try
            {
                var duty = context.Duties.FirstOrDefault(D => D.Id == Id);
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
            catch (Exception)
            {

                throw new Exception("Duty not found");
            }
            
        }
        public void RemoveDuty(int Id)
        {
            var duty = context.Duties.Where(D => D.Id == Id).ToList();
            context.Remove(duty);
            context.SaveChanges();
        }
        public void ChangeDutyStatus(int id,int task)
        {
            try
            {
                var duty = context.Duties.FirstOrDefault(D => D.Id == id);
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
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            } 
        }
        public Duty SearchByName(string name)
        {
            var duty = context.Duties.FirstOrDefault(D => D.DutyName == name);
            return duty;
        }
    }
}
