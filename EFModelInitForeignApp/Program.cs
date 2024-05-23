using EFModelInitForeignApp;
using System.Runtime.ConstrainedExecution;

using (EmployeeAppContext context = new())
{
    context.DeleteCreate();
    //context.HasData();

    List<Company> companies = null!;
    List<Employee> employees = null!;

    companies = new()
            {
                new() { Title = "Yandex" },
                new() { Title = "Ozon" },
                new() { Title = "Avito" }
            };
    employees = new()
            {
                new(){ Name = "Bobby", Age = 35, Company = companies[0] },
                new(){ Name = "Sammy", Age = 22, Company = companies[1] },
                new(){ Name = "Jommy", Age = 41, Company = companies[2] },
                new(){ Name = "Tommt", Age = 26, Company = companies[0] },
                new(){ Name = "Billy", Age = 48, Company = companies[1] },
                new(){ Name = "Kenny", Age = 31, Company = companies[0] },
            };

    context.Companies.AddRange(companies);
    context.Employees.AddRange(employees);

    context.SaveChanges();
}

//using (EmployeeAppContext context = new())
//{
//    foreach(var c in context.Companies)
//    {
//        Console.WriteLine($"Compant: {c.Title}");
//        foreach(var e in c.Employees.ToList())
//            Console.WriteLine($"\tName: {e.Name}, Age: {e.Age}");
//    }
//}


using(EmployeeAppContext context = new())
{
    foreach(var e in context.Employees)
        Console.WriteLine($"{e.Name}");
    Console.WriteLine();


    var company = context.Companies.FirstOrDefault(c => c.Id == 2);
    if(company is not null)
    {
        context.Companies.Remove(company);
    }
    context.SaveChanges();

    foreach (var e in context.Employees)
        Console.WriteLine($"{e.Name}");
}