using HW12;
using HW12.DB;
using HW12.Interface;
using HW12.Service;
using Microsoft.EntityFrameworkCore;
IUserService _userService = new Userservice();
IDutyService _dutyService = new DutyService();
while (true)
{
    try
    {
        Console.WriteLine("***** Wellcome *****");
        Console.WriteLine("1.Login 2.Register");
        int LoginOrRegister = int.Parse(Console.ReadLine()!);
        if (LoginOrRegister == 1)
        {
            Console.Clear();
            Console.WriteLine("***** Login *****");
            Console.Write("Please enter your username:");
            var username = Console.ReadLine()!;
            Console.Write("Please enter your password:");
            var password = Console.ReadLine()!;
            _userService.Login(username, password);
            Userservice();
        }
        else if (LoginOrRegister==2)
        {
            Console.Clear();
            Console.WriteLine("***** Register *****");
            Console.Write("Please enter your username:");
            var username1 = Console.ReadLine()!;
            Console.Write("Please enter your password:");
            var password1 = Console.ReadLine()!;
            _userService.Register(username1, password1);
            Console.WriteLine("Done. Now please login");
            break;
        }
        else
        {
            Console.WriteLine("Action is invalid! Please try again");
            break;
        }
        
        
    }
    catch (Exception)
    {

        throw;
    }
    Console.Clear();
}
void Userservice()
{
    bool Logout = false;
    do
    {
        Console.WriteLine("Please Choese your wanted task:");
        Console.WriteLine("1.Add new duty");
        Console.WriteLine("2.Show all duties");
        Console.WriteLine("3.Edit a duty's information");
        Console.WriteLine("4.Remove duty");
        Console.WriteLine("5.Change a duty status");
        Console.WriteLine("6.Search for a duty by name");
        Console.WriteLine("7.Logout");
        DutyService dutyService = new DutyService();
        
        int answer = int.Parse(Console.ReadLine()!);
        switch (answer)
        {
            case 1:
                Console.Write("Please enter name:");
                string name = Console.ReadLine()!;
                Console.Write("Please enter the ditaile of this duty: ");
                var ditaile = Console.ReadLine();
                Console.Write("Pleas enter the date: ");
                DateTime dateTime = Convert.ToDateTime(Console.ReadLine()!);
                Console.WriteLine("Please set this duty's Priority");
                int pri = int.Parse(Console.ReadLine()!);
                switch (pri)
                {
                    case 1: dutyService.AddDuty(name, TaskPriorityEnum.VeryImportant,InMemoryDatabase.OnlineUser.Id ,dateTime); break;
                    case 2: dutyService.AddDuty(name, TaskPriorityEnum.Important, InMemoryDatabase.OnlineUser.Id, dateTime); break;
                    case 3: dutyService.AddDuty(name, TaskPriorityEnum.Normalpriority, InMemoryDatabase.OnlineUser.Id, dateTime); break;
                    case 4: dutyService.AddDuty(name, TaskPriorityEnum.NotImportant, InMemoryDatabase.OnlineUser.Id, dateTime); break;
                    default:
                        break;
                }
                break;
            case 2: dutyService.ShowAllDuties(InMemoryDatabase.OnlineUser.Id); break;
            case 3:
                Console.Write("Please enter the duty's Id:");
                int dutyid = int.Parse(Console.ReadLine()!);
                Console.WriteLine("Please enter the number of part of duty that you want to edit:(1.name 2.ditail 3.date 4.Priority");
                int answer2 = int.Parse(Console.ReadLine()!);
                switch (answer2)
                {
                    case 1:
                        Console.WriteLine("Please enter the new name: ");
                        string Newname = Console.ReadLine()!;
                        dutyService.ChangeDutyInfo(InMemoryDatabase.OnlineUser.Id, answer2, dutyid, Newname, null, null, null);
                        break;
                    case 2:
                        Console.Write("Please enter new ditail:");
                        var NewDitail = Console.ReadLine();
                        dutyService.ChangeDutyInfo(InMemoryDatabase.OnlineUser.Id, answer2, dutyid, null, NewDitail, null, null);
                        break;
                    case 3:
                        Console.Write("Please enter the new date of your duty: ");
                        DateTime NewDate = Convert.ToDateTime(Console.ReadLine()!);
                        dutyService.ChangeDutyInfo(InMemoryDatabase.OnlineUser.Id, answer2, dutyid, null, null, NewDate, null);
                        break;
                    case 4:
                        Console.WriteLine("Please set this duty new Priority :(1.veryimportant 2.important 3.normalimportant 4.notimportant");
                        int NewPriority = int.Parse(Console.ReadLine()!);
                        switch (NewPriority)
                        {
                            case 1: dutyService.ChangeDutyInfo(InMemoryDatabase.OnlineUser.Id, answer2, dutyid, null, null, null, TaskPriorityEnum.VeryImportant); break;
                            case 2: dutyService.ChangeDutyInfo(InMemoryDatabase.OnlineUser.Id, answer2, dutyid, null, null, null, TaskPriorityEnum.Important); break;
                            case 3: dutyService.ChangeDutyInfo(InMemoryDatabase.OnlineUser.Id, answer2, dutyid, null, null, null, TaskPriorityEnum.Normalpriority); break;
                            case 4: dutyService.ChangeDutyInfo(InMemoryDatabase.OnlineUser.Id, answer2, dutyid, null, null, null, TaskPriorityEnum.NotImportant); break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
                break;
            case 4:
                Console.Write("Pleas enter duty's id in order to remove it: ");
                int RemovingId = int.Parse(Console.ReadLine()!);
                dutyService.RemoveDuty(RemovingId, InMemoryDatabase.OnlineUser.Id);
                break;
            case 5:
                Console.Write("Please enter the duty id that you want to change it's status:");
                int StatusChangingId = int.Parse(Console.ReadLine()!);
                Console.Write("Please enter set new status for this duty: (1.In process 2.Done 3.Cancelled");
                int NewStatuse = int.Parse(Console.ReadLine()!);
                dutyService.ChangeDutyStatus(StatusChangingId, NewStatuse, InMemoryDatabase.OnlineUser.Id);
                break;
            case 6:
                Console.Write("Please entre the name of Duty: ");
                string SearchingName = Console.ReadLine()!;
                dutyService.SearchByName(InMemoryDatabase.OnlineUser.Id, SearchingName);
                break;
            case 7:Logout = true;break;
            default:
                break;
        }
    } while (!Logout);


}

