
using ProductionOperation;
using System.Linq;

List<Operation> operations = new List<Operation> 
{ 
 new Operation() { Id = 1, Start = new DateTime(2023,05,20,07,30,00), End = new DateTime(2023,05,20,08,30,00), Status = "Üretim", StopReason = ""},
 new Operation() { Id = 2, Start = new DateTime(2023,05,20,08,30,00), End = new DateTime(2023,05,20,12,00,00), Status = "Üretim", StopReason = "" },
 new Operation() { Id = 3, Start = new DateTime(2023,05,20,12,00,00), End = new DateTime(2023,05,20,13,00,00), Status = "Üretim", StopReason = "" },
 new Operation() { Id = 4, Start = new DateTime(2023,05,20,13,00,00), End = new DateTime(2023,05,20,13,45,00), Status = "Üretim", StopReason = "Arıza"},
 new Operation() { Id = 4, Start = new DateTime(2023,05,20,13,45,00), End = new DateTime(2023,05,20,17,30,00), Status = "Üretim", StopReason = ""},
};
List<StandardStop> standardStops = new List<StandardStop>
{
 new StandardStop() { Id = 1, Start = new DateTime(2023,05,20,10,00,00), End = new DateTime(2023,05,20,10,15,00), StopReason = "Çay Molası"},
  new StandardStop() { Id = 1, Start = new DateTime(2023,05,20,12,00,00), End = new DateTime(2023,05,20,12,30,00), StopReason = "Yemek Molası"},
   new StandardStop() { Id = 1, Start = new DateTime(2023,05,20,15,00,00), End = new DateTime(2023,05,20,15,15,00), StopReason = "Çay Molası"},
};

List<Operation> combinedOperations = new List<Operation>(operations);
foreach (var standardStop in standardStops)
{
    var overlappedOperations = operations.Where(x => x.Start < standardStop.End && x.End > standardStop.Start).ToList();
    if (overlappedOperations.Any())
    {
        foreach (var operation in overlappedOperations)
        {
            if (operation.Start < standardStop.Start)
            {
                combinedOperations.Add(new Operation()
                {
                    Id = operation.Id,
                    Start = operation.Start,
                    End = standardStop.Start,
                    Status = operation.Status,
                    StopReason = operation.StopReason
                });
            }
            combinedOperations.Add(new Operation()
            {
                Id = standardStop.Id,
                Start = standardStop.Start,
                End = standardStop.End,
                Status = "StandardStop",
                StopReason = standardStop.StopReason
            });
            if (operation.End > standardStop.End)
            {
                combinedOperations.Add(new Operation()
                {
                    Id = operation.Id,
                    Start = standardStop.End,
                    End = operation.End,
                    Status = operation.Status,
                    StopReason = operation.StopReason
                });
            }
            combinedOperations.Remove(operation);
        }
    }
    else
    {
        combinedOperations.Add(new Operation()
        {
            Id = standardStop.Id,
            Start = standardStop.Start,
            End = standardStop.End,
            Status = "StandardStop",
            StopReason = standardStop.StopReason
        });
    }
}

var sortedOperations = combinedOperations.OrderBy(x => x.Start);

// Tablonun çerçevesini oluşturun
Console.WriteLine("+------------------+------------------+-----------------+--------------+");
Console.WriteLine("|       Start      |       End        |      Status     |  Stop Reason |");
Console.WriteLine("+------------------+------------------+-----------------+--------------+");

// Tablonun içeriğini yazdırın
foreach (var operation in sortedOperations)
{
    Console.WriteLine("| {0,12} | {1,14} | {2,15} | {3,12} |",
        operation.Start.ToString("dd.MM.yyyy HH:mm"),
        operation.End.ToString("dd.MM.yyyy HH:mm"),
        operation.Status,
        operation.StopReason);
}

// Tablonun alt çerçevesini oluşturun
Console.WriteLine("+------------------+------------------+-----------------+--------------+");

Console.ReadLine();