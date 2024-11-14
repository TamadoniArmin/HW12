using HW12;
using HW12.Service;

Console.WriteLine("***** Wellcome *****");
Console.WriteLine("Please Choese your wanted task:");
Console.WriteLine("1.Add new duty");
Console.WriteLine("2.Show all duties");
Console.WriteLine("3.Edit a duty's information");
Console.WriteLine("4.Remove duty");
Console.WriteLine("5.Change a duty status");
Console.WriteLine("6.Search for a duty by name");
DutyService dutyService = new DutyService();
try
{
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
				case 1:dutyService.AddDuty(name, ditaile, TaskPriorityEnum.VeryImportant, dateTime); break;
				case 2: dutyService.AddDuty(name, ditaile, TaskPriorityEnum.Important, dateTime); break;
                case 3: dutyService.AddDuty(name, ditaile, TaskPriorityEnum.Normalpriority, dateTime); break;
                case 4: dutyService.AddDuty(name, ditaile, TaskPriorityEnum.NotImportant, dateTime); break;
                default:
					break;
			}
			break;
		case 2:dutyService.ShowAllDuties();break;
		case 3:
            Console.Write("Please enter the duty's Id:");
			int dutyid = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Please enter the number of part of duty that you want to edit:(1.name 2.ditail 3.date 4.Priority");
			int answer2 = int.Parse(Console.ReadLine()!);
			switch (answer2)
			{
				case 1:
                    Console.WriteLine("Please enter the new name: ");
					string Newname= Console.ReadLine()!;
					dutyService.ChangeDutyInfo(answer2, dutyid, Newname, null, DateTime.Now, TaskPriorityEnum.Important);
					break;
				case 2:
                    Console.Write("Please enter new ditail:");
					var NewDitail = Console.ReadLine();
                    dutyService.ChangeDutyInfo(answer2, dutyid, null, NewDitail, DateTime.Now, TaskPriorityEnum.Important);
					break;
				case 3:
                    Console.Write("Please enter the new date of your duty: ");
					DateTime NewDate = Convert.ToDateTime(Console.ReadLine()!);
                    dutyService.ChangeDutyInfo(answer2, dutyid, null, null, NewDate, TaskPriorityEnum.Important);
					break;
				case 4:
                    Console.WriteLine("Please set this duty new Priority :(1.veryimportant 2.important 3.normalimportant 4.notimportant");
					int NewPriority = int.Parse(Console.ReadLine()!);
					switch (NewPriority)
					{
						case 1: dutyService.ChangeDutyInfo(answer2, dutyid, null, null, DateTime.Now, TaskPriorityEnum.VeryImportant);break;
						case 2: dutyService.ChangeDutyInfo(answer2, dutyid, null, null, DateTime.Now, TaskPriorityEnum.Important); break;
						case 3: dutyService.ChangeDutyInfo(answer2, dutyid, null, null, DateTime.Now, TaskPriorityEnum.Normalpriority); break;
						case 4: dutyService.ChangeDutyInfo(answer2, dutyid, null, null, DateTime.Now, TaskPriorityEnum.NotImportant); break;
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
			dutyService.RemoveDuty(RemovingId);
			break;
        case 5:
            Console.Write("Please enter the duty id that you want to change it's status:");
			int StatusChangingId = int.Parse(Console.ReadLine()!);
            Console.Write("Please enter set new status for this duty: (1.In process 2.Done 3.Cancelled");
			int NewStatuse = int.Parse(Console.ReadLine()!);
			dutyService.ChangeDutyStatus(StatusChangingId, NewStatuse);
			break;
		case 6:
            Console.Write("Please entre the name of Duty: ");
			string SearchingName = Console.ReadLine()!;
			dutyService.SearchByName(SearchingName);
			break;
        default:
			break;
	}
}
catch (Exception)
{

	throw;
}