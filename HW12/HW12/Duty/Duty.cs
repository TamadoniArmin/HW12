using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Task
{
    public class Duty
    {
        public int Id { get; set; }
        public string DutyName { get; set; }
        public string? Ditails { get; set; }
        public DateTime Date { get; set; }
        public StatusEnum Status { get; set; } = StatusEnum.NotDoneYet;
        public TaskPriorityEnum Priority { get; set; } = TaskPriorityEnum.NotImportant;

    }
}
