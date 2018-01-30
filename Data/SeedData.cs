// This file was constructed by Jason Figuroa and the source code can be found here : https://github.com/spooky-oysters/bangazon
// This will seed the database with dummy data if the tables are empty


/*****************************************************************/
/* If seeded data is no longer required this file can be deleted */
/*****************************************************************/

using System;
using System.Linq;
using BangazonApi;
using BangazonApi.Data;
using BangazonApi.Models;
using Microsoft.Extensions.DependencyInjection;

namespace BangazonApi.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            context.Database.EnsureCreated();

            /**************************/
            /* Seeding Computer Table */
            /**************************/
            if (!context.Computer.Any())
            {
                context.Computer.Add(new Computer { Serial = "11202", Purchased = Convert.ToDateTime("01/23/2017") });
                context.Computer.Add(new Computer { Serial = "11203", Purchased = Convert.ToDateTime("01/23/2017") });
                context.Computer.Add(new Computer { Serial = "11204", Purchased = Convert.ToDateTime("01/23/2017") });
                context.Computer.Add(new Computer { Serial = "11205", Purchased = Convert.ToDateTime("01/23/2017") });
                context.Computer.Add(new Computer { Serial = "11206", Purchased = Convert.ToDateTime("01/23/2017") });
                context.Computer.Add(new Computer { Serial = "11207", Purchased = Convert.ToDateTime("01/23/2017") });
                context.Computer.Add(new Computer { Serial = "11208", Purchased = Convert.ToDateTime("01/23/2017") });

                context.Computer.Add(new Computer { Serial = "98209", Purchased = Convert.ToDateTime("03/11/2017") });
                context.Computer.Add(new Computer { Serial = "98210", Purchased = Convert.ToDateTime("03/11/2017") });
                context.Computer.Add(new Computer { Serial = "98211", Purchased = Convert.ToDateTime("03/11/2017") });
                context.Computer.Add(new Computer { Serial = "98212", Purchased = Convert.ToDateTime("03/11/2017") });
                context.Computer.Add(new Computer { Serial = "98213", Purchased = Convert.ToDateTime("03/11/2017") });
                context.Computer.Add(new Computer { Serial = "98214", Purchased = Convert.ToDateTime("03/11/2017") });
                context.Computer.Add(new Computer { Serial = "98215", Purchased = Convert.ToDateTime("03/11/2017") });
                context.Computer.Add(new Computer { Serial = "98216", Purchased = Convert.ToDateTime("03/11/2017") });
                context.Computer.Add(new Computer { Serial = "98217", Purchased = Convert.ToDateTime("03/11/2017") });

                context.Computer.Add(new Computer { Serial = "33315", Purchased = Convert.ToDateTime("05/21/2017") });
                context.Computer.Add(new Computer { Serial = "33316", Purchased = Convert.ToDateTime("05/21/2017") });
                context.Computer.Add(new Computer { Serial = "33317", Purchased = Convert.ToDateTime("05/21/2017") });
                context.Computer.Add(new Computer { Serial = "33318", Purchased = Convert.ToDateTime("05/21/2017") });
                context.Computer.Add(new Computer { Serial = "33319", Purchased = Convert.ToDateTime("05/21/2017") });
                context.Computer.Add(new Computer { Serial = "33320", Purchased = Convert.ToDateTime("05/21/2017") });
                context.Computer.Add(new Computer { Serial = "33321", Purchased = Convert.ToDateTime("05/21/2017") });

                /*****************************************************/
                /* Uncomment the following if we need more computers */
                /*****************************************************/
                // context.Computer.Add(new Computer { Name = "MacBook Pro", SerialNumber =  "10676", PurchaseDate = Convert.ToDateTime("08/21/2017") });
                // context.Computer.Add(new Computer { Name = "MacBook Pro", SerialNumber =  "10677", PurchaseDate = Convert.ToDateTime("08/21/2017") });
                // context.Computer.Add(new Computer { Name = "MacBook Pro", SerialNumber =  "10678", PurchaseDate = Convert.ToDateTime("08/21/2017") });
                // context.Computer.Add(new Computer { Name = "MacBook Pro", SerialNumber =  "10679", PurchaseDate = Convert.ToDateTime("08/21/2017") });
                // context.Computer.Add(new Computer { Name = "MacBook Pro", SerialNumber =  "10680", PurchaseDate = Convert.ToDateTime("08/21/2017") });
                // context.Computer.Add(new Computer { Name = "MacBook Pro", SerialNumber =  "10681", PurchaseDate = Convert.ToDateTime("08/21/2017") });
                // context.Computer.Add(new Computer { Name = "MacBook Pro", SerialNumber =  "10682", PurchaseDate = Convert.ToDateTime("08/21/2017") });
                // context.Computer.Add(new Computer { Name = "MacBook Pro", SerialNumber =  "10683", PurchaseDate = Convert.ToDateTime("08/21/2017") });
                // context.Computer.Add(new Computer { Name = "MacBook Pro", SerialNumber =  "10684", PurchaseDate = Convert.ToDateTime("08/21/2017") });
                // context.Computer.Add(new Computer { Name = "MacBook Pro", SerialNumber =  "10685", PurchaseDate = Convert.ToDateTime("08/21/2017") });
                // context.Computer.Add(new Computer { Name = "MacBook Pro", SerialNumber =  "10686", PurchaseDate = Convert.ToDateTime("08/21/2017") });
                // context.Computer.Add(new Computer { Name = "MacBook Pro", SerialNumber =  "10687", PurchaseDate = Convert.ToDateTime("08/21/2017") });

                context.SaveChanges();
            }

            /*********************************/
            /* Seeding Training Table */
            /*********************************/
            if (!context.Training.Any())
            {
                context.Training.Add(new Training { Name = "AngualarJS Course", Start = Convert.ToDateTime("02/12/2018"), End = Convert.ToDateTime("02/16/2017"), Capacity = 25 });
                context.Training.Add(new Training { Name = "IT Security Training", Start = Convert.ToDateTime("03/19/2017"), End = Convert.ToDateTime("03/23/2017"), Capacity = 25 });
                context.Training.Add(new Training { Name = "Operating Systems Concepts", Start = Convert.ToDateTime("02/26/2017"), End = Convert.ToDateTime("03/02/2017"), Capacity = 25 });
                context.Training.Add(new Training { Name = "Systems Architecture", Start = Convert.ToDateTime("04/16/2017"), End = Convert.ToDateTime("04/20/2017"), Capacity = 25 });
                context.Training.Add(new Training { Name = "Business Analysis", Start = Convert.ToDateTime("04/16/2017"), End = Convert.ToDateTime("04/20/2017"), Capacity = 25 });
                context.Training.Add(new Training { Name = "Project Management", Start = Convert.ToDateTime("04/16/2017"), End = Convert.ToDateTime("04/20/2017"), Capacity = 25 });
                context.SaveChanges();
            }

            /****************************/
            /* Seeding Department Table */
            /****************************/
            if (!context.Department.Any())
            {
                context.Department.Add(new Department { Name = "IT", Budget = 899000 });
                context.Department.Add(new Department { Name = "Admin", Budget = 500000 });
                context.Department.Add(new Department { Name = "Human Resources", Budget = 650000 });
                context.Department.Add(new Department { Name = "Engineering", Budget = 1200000 });
                context.SaveChanges();
            }

            /**************************/
            /* Seeding Employee Table */
            /**************************/
            if (!context.Employee.Any())
            {
                /* IT Department */
                int deptId = (from b in context.Department
                              where b.Name.Equals("IT")
                              select b.Id).Single();

                context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Kenneth", LastName = "Allen", IsSupervisor = 0 });
                context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "John", LastName = "Smith", IsSupervisor = 0 });
                context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Jane", LastName = "Doe", IsSupervisor = 0 });
                context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Dan", LastName = "Williams", IsSupervisor = 1 });
                context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Ben", LastName = "Taylor", IsSupervisor = 0 });

                /* Admin Department */
                deptId = (from b in context.Department
                          where b.Name.Equals("Admin")
                          select b.Id).Single();

                context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Maria", LastName = "Guerrera", IsSupervisor = 0 });
                context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Justin", LastName = "Johnson", IsSupervisor = 1 });
                context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Michelle", LastName = "Nyuen", IsSupervisor = 0 });
                context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Henry", LastName = "Mall", IsSupervisor = 0 });
                context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "George", LastName = "Davidson", IsSupervisor = 0 });

                /* Engineering Deparment */
                deptId = (from b in context.Department
                          where b.Name.Equals("Engineering")
                          select b.Id).Single();

                context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Dave", LastName = "Blazen", IsSupervisor = 0 });
                context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Frank", LastName = "Dolton", IsSupervisor = 1 });
                context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Michael", LastName = "Yu", IsSupervisor = 0 });
                context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Teresa", LastName = "Evans", IsSupervisor = 0 });
                context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Susan", LastName = "Lee", IsSupervisor = 0 });

                /* Human Resources Department */
                deptId = (from b in context.Department
                          where b.Name.Equals("Human Resources")
                          select b.Id).Single();

                context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Richard", LastName = "Leinecker", IsSupervisor = 0 });
                context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Mark", LastName = "Llewelyn", IsSupervisor = 1 });
                context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Sarah", LastName = "Angell", IsSupervisor = 0 });
                context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Victor", LastName = "Richardson", IsSupervisor = 0 });
                context.Employee.Add(new Employee { DepartmentId = deptId, FirstName = "Jose", LastName = "Campos", IsSupervisor = 0 });

                context.SaveChanges();
            }

            /**********************************/
            /* Seeding ComputerEmployee Table */
            /**********************************/
            if (!context.ComputerEmployee.Any())
            {
                int employeeId = (from e in context.Employee
                                  where e.LastName.Equals("Allen") && e.FirstName.Equals("Kenneth")
                                  select e.Id).Single();

                int computerId = (from c in context.Computer
                                  where c.Serial.Equals("33315")
                                  select c.Id).Single();

                context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId });

                employeeId = (from e in context.Employee
                              where e.LastName.Equals("Smith") && e.FirstName.Equals("John")
                              select e.Id).Single();

                computerId = (from c in context.Computer
                              where c.Serial.Equals("98210")
                              select c.Id).Single();

                context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId });

                employeeId = (from e in context.Employee
                              where e.LastName.Equals("Doe") && e.FirstName.Equals("Jane")
                              select e.Id).Single();

                computerId = (from c in context.Computer
                              where c.Serial.Equals("98214")
                              select c.Id).Single();

                context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId });

                employeeId = (from e in context.Employee
                              where e.LastName.Equals("Williams") && e.FirstName.Equals("Dan")
                              select e.Id).Single();

                computerId = (from c in context.Computer
                              where c.Serial.Equals("11205")
                              select c.Id).Single();

                context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId });

                employeeId = (from e in context.Employee
                              where e.LastName.Equals("Taylor") && e.FirstName.Equals("Ben")
                              select e.Id).Single();

                computerId = (from c in context.Computer
                              where c.Serial.Equals("98213")
                              select c.Id).Single();

                context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId });

                employeeId = (from e in context.Employee
                              where e.LastName.Equals("Guerrera") && e.FirstName.Equals("Maria")
                              select e.Id).Single();

                computerId = (from c in context.Computer
                              where c.Serial.Equals("33319")
                              select c.Id).Single();

                context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId });

                employeeId = (from e in context.Employee
                              where e.LastName.Equals("Johnson") && e.FirstName.Equals("Justin")
                              select e.Id).Single();

                computerId = (from c in context.Computer
                              where c.Serial.Equals("11208")
                              select c.Id).Single();

                context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId });

                employeeId = (from e in context.Employee
                              where e.LastName.Equals("Nyuen") && e.FirstName.Equals("Michelle")
                              select e.Id).Single();

                computerId = (from c in context.Computer
                              where c.Serial.Equals("98209")
                              select c.Id).Single();

                context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId });

                employeeId = (from e in context.Employee
                              where e.LastName.Equals("Mall") && e.FirstName.Equals("Henry")
                              select e.Id).Single();

                computerId = (from c in context.Computer
                              where c.Serial.Equals("33316")
                              select c.Id).Single();

                context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId });

                employeeId = (from e in context.Employee
                              where e.LastName.Equals("Davidson") && e.FirstName.Equals("George")
                              select e.Id).Single();

                computerId = (from c in context.Computer
                              where c.Serial.Equals("98211")
                              select c.Id).Single();

                context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId });

                employeeId = (from e in context.Employee
                              where e.LastName.Equals("Blazen") && e.FirstName.Equals("Dave")
                              select e.Id).Single();

                computerId = (from c in context.Computer
                              where c.Serial.Equals("98212")
                              select c.Id).Single();

                context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId });

                employeeId = (from e in context.Employee
                              where e.LastName.Equals("Dolton") && e.FirstName.Equals("Frank")
                              select e.Id).Single();

                computerId = (from c in context.Computer
                              where c.Serial.Equals("11202")
                              select c.Id).Single();

                context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId });

                employeeId = (from e in context.Employee
                              where e.LastName.Equals("Yu") && e.FirstName.Equals("Michael")
                              select e.Id).Single();

                computerId = (from c in context.Computer
                              where c.Serial.Equals("33320")
                              select c.Id).Single();

                context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId });

                employeeId = (from e in context.Employee
                              where e.LastName.Equals("Evans") && e.FirstName.Equals("Teresa")
                              select e.Id).Single();

                computerId = (from c in context.Computer
                              where c.Serial.Equals("33317")
                              select c.Id).Single();

                context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId });

                employeeId = (from e in context.Employee
                              where e.LastName.Equals("Lee") && e.FirstName.Equals("Susan")
                              select e.Id).Single();

                computerId = (from c in context.Computer
                              where c.Serial.Equals("98216")
                              select c.Id).Single();

                context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId });

                employeeId = (from e in context.Employee
                              where e.LastName.Equals("Leinecker") && e.FirstName.Equals("Richard")
                              select e.Id).Single();

                computerId = (from c in context.Computer
                              where c.Serial.Equals("33321")
                              select c.Id).Single();

                context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId });

                employeeId = (from e in context.Employee
                              where e.LastName.Equals("Llewelyn") && e.FirstName.Equals("Mark")
                              select e.Id).Single();

                computerId = (from c in context.Computer
                              where c.Serial.Equals("11203")
                              select c.Id).Single();

                context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId });

                employeeId = (from e in context.Employee
                              where e.LastName.Equals("Angell") && e.FirstName.Equals("Sarah")
                              select e.Id).Single();

                computerId = (from c in context.Computer
                              where c.Serial.Equals("98217")
                              select c.Id).Single();

                context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId });

                employeeId = (from e in context.Employee
                              where e.LastName.Equals("Richardson") && e.FirstName.Equals("Victor")
                              select e.Id).Single();

                computerId = (from c in context.Computer
                              where c.Serial.Equals("98215")
                              select c.Id).Single();

                context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId });

                employeeId = (from e in context.Employee
                              where e.LastName.Equals("Campos") && e.FirstName.Equals("Jose")
                              select e.Id).Single();

                computerId = (from c in context.Computer
                              where c.Serial.Equals("33318")
                              select c.Id).Single();

                context.ComputerEmployee.Add(new ComputerEmployee { EmployeeId = employeeId, ComputerId = computerId });

                context.SaveChanges();
            }

            /**********************************/
            /* Seeding TrainingEmployee Table */
            /**********************************/
            if (!context.EmployeeTraining.Any())
            {
                int trainingId = (from tp in context.Training
                                  where tp.Name.Equals("IT Security Training")
                                  select tp.Id).Single();

                var employees = context.Employee;

                foreach (var e in employees)
                {
                    context.EmployeeTraining.Add(new EmployeeTraining { TrainingId = trainingId, EmployeeId = e.Id });
                }

                trainingId = (from tp in context.Training
                              where tp.Name.Equals("Project Management")
                              select tp.Id).Single();

                foreach (var e in employees)
                {
                    if (e.IsSupervisor == 1)
                    {
                        context.EmployeeTraining.Add(new EmployeeTraining { TrainingId = trainingId, EmployeeId = e.Id });
                    }
                }

                trainingId = (from tp in context.Training
                              where tp.Name.Equals("Business Analysis")
                              select tp.Id).Single();

                int departmentId = (from d in context.Department
                                    where d.Name.Equals("Human Resources")
                                    select d.Id).Single();

                foreach (var e in employees)
                {

                    if (e.Id == departmentId)
                    {
                        context.EmployeeTraining.Add(new EmployeeTraining { TrainingId = trainingId, EmployeeId = e.Id });
                    }
                }

                trainingId = (from tp in context.Training
                              where tp.Name.Equals("AngualarJS Course")
                              select tp.Id).Single();

                departmentId = (from d in context.Department
                                where d.Name.Equals("IT")
                                select d.Id).Single();

                foreach (var e in employees)
                {

                    if (e.DepartmentId == departmentId)
                    {
                        context.EmployeeTraining.Add(new EmployeeTraining { TrainingId = trainingId, EmployeeId = e.Id });
                    }
                }

                trainingId = (from tp in context.Training
                              where tp.Name.Equals("Operating Systems Concepts")
                              select tp.Id).Single();

                foreach (var e in employees)
                {

                    if (e.DepartmentId == departmentId)
                    {
                        context.EmployeeTraining.Add(new EmployeeTraining { TrainingId = trainingId, EmployeeId = e.Id });
                    }
                }

                trainingId = (from tp in context.Training
                              where tp.Name.Equals("Systems Architecture")
                              select tp.Id).Single();

                foreach (var e in employees)
                {

                    if (e.DepartmentId == departmentId)
                    {
                        context.EmployeeTraining.Add(new EmployeeTraining { TrainingId = trainingId, EmployeeId = e.Id });
                    }
                }

                context.SaveChanges();
            }

            /*********************************/
            /* Seeding ProductType Table */
            /*********************************/
            if (!context.ProductType.Any())
            {
                context.ProductType.Add(new ProductType { Description = "Jewelry & Accessories" });
                context.ProductType.Add(new ProductType { Description = "Clothing & Shoes" });
                context.ProductType.Add(new ProductType { Description = "Home & Living" });
                context.ProductType.Add(new ProductType { Description = "Arts & Collectibles" });

                context.SaveChanges();
            }

            /**************************/
            /* Seeding Customer Table */
            /**************************/
            if (!context.Customer.Any())
            {
                /********************************************************************************/
                /* commented out customers can be uncommented if we need or want more customers */
                /********************************************************************************/

                context.Customer.Add(new Customer { FirstName = "Stacy", LastName = "Gauger", LastActive = Convert.ToDateTime("01/24/2018") });
                context.Customer.Add(new Customer { FirstName = "Stephan", LastName = "Adams", LastActive = Convert.ToDateTime("01/26/2018") });
                context.Customer.Add(new Customer { FirstName = "Belle", LastName = "Martin", LastActive = Convert.ToDateTime("01/25/2018") });
                context.Customer.Add(new Customer { FirstName = "Jeraldine", LastName = "Chenard", LastActive = Convert.ToDateTime("01/27/2018") });
                context.Customer.Add(new Customer { FirstName = "Mila", LastName = "Lone", LastActive = Convert.ToDateTime("01/28/2018") });

                context.Customer.Add(new Customer { FirstName = "Samara", LastName = "Mello", LastActive = Convert.ToDateTime("12/27/2017") });
                context.Customer.Add(new Customer { FirstName = "Justin", LastName = "Kohr", LastActive = Convert.ToDateTime("01/22/2018") });
                context.Customer.Add(new Customer { FirstName = "Debbie", LastName = "Mansell", LastActive = Convert.ToDateTime("01/21/2018") });
                context.Customer.Add(new Customer { FirstName = "Tyron", LastName = "Hawkes", LastActive = Convert.ToDateTime("01/27/2018") });
                context.Customer.Add(new Customer { FirstName = "Beau", LastName = "Lampkins", LastActive = Convert.ToDateTime("01/27/2018") });

                context.Customer.Add(new Customer { FirstName = "William", LastName = "Gallaway", LastActive = Convert.ToDateTime("01/26/2018") });
                context.Customer.Add(new Customer { FirstName = "Vicente", LastName = "Duby", LastActive = Convert.ToDateTime("01/21/2018") });
                context.Customer.Add(new Customer { FirstName = "Michael", LastName = "Yu", LastActive = Convert.ToDateTime("12/07/2017") });
                context.Customer.Add(new Customer { FirstName = "Addie", LastName = "Fisher", LastActive = Convert.ToDateTime("11/22/2017") });
                context.Customer.Add(new Customer { FirstName = "Callie", LastName = "Eckron", LastActive = Convert.ToDateTime("01/25/2018") });

                context.Customer.Add(new Customer { FirstName = "Toni", LastName = "Rasch", LastActive = Convert.ToDateTime("12/21/2017") });
                context.Customer.Add(new Customer { FirstName = "Gail", LastName = "Aviles", LastActive = Convert.ToDateTime("01/21/2018") });
                context.Customer.Add(new Customer { FirstName = "Loreta", LastName = "Balmer", LastActive = Convert.ToDateTime("01/20/2018") });
                context.Customer.Add(new Customer { FirstName = "Selina", LastName = "Fairchild", LastActive = Convert.ToDateTime("01/24/2018") });
                context.Customer.Add(new Customer { FirstName = "Albert", LastName = "Lewis", LastActive = Convert.ToDateTime("01/18/2018") });

                context.SaveChanges();
            }

            /*************************/
            /* Seeding Product Table */
            /*************************/
            if (!context.Product.Any())
            {
                int customerId = (from c in context.Customer
                                  where c.LastName.Equals("Gauger") && c.FirstName.Equals("Stacy")
                                  select c.Id).Single();

                int productTypeId = (from pc in context.ProductType
                                     where pc.Description.Equals("Clothing & Shoes")
                                     select pc.Id).Single();

                context.Product.Add(new Product { CustomerId = customerId, Description = "A beautifully knitted hat for a toddler girl.", Name = "Knit Hat", Price = 2500, ProductTypeId = productTypeId, Quantity = 2 });
                context.Product.Add(new Product { CustomerId = customerId, Description = "A beautifully knitted scarf for a toddler girl.", Name = "Knit Scarf", Price = 2500, ProductTypeId = productTypeId, Quantity = 4 });
                context.Product.Add(new Product { CustomerId = customerId, Description = "A beautifully knitted mittens for a toddler girl.", Name = "Knit Mittens", Price = 2500, ProductTypeId = productTypeId, Quantity = 3 });

                customerId = (from c in context.Customer
                              where c.LastName.Equals("Adams") && c.FirstName.Equals("Stephan")
                              select c.Id).Single();

                productTypeId = (from pc in context.ProductType
                                 where pc.Description.Equals("Arts & Collectibles")
                                 select pc.Id).Single();

                context.Product.Add(new Product { CustomerId = customerId, Description = "A beautiful oil painting of a beach during sunset.", Name = "Sunset Painting", Price = 22500, ProductTypeId = productTypeId, Quantity = 1 });
                context.Product.Add(new Product { CustomerId = customerId, Description = "A beautiful oil painting a cafe in Paris.", Name = "Paris Cafe Painting", Price = 35000, ProductTypeId = productTypeId, Quantity = 1 });

                customerId = (from c in context.Customer
                              where c.LastName.Equals("Martin") && c.FirstName.Equals("Belle")
                              select c.Id).Single();

                productTypeId = (from pc in context.ProductType
                                 where pc.Description.Equals("Jewelry & Accessories")
                                 select pc.Id).Single();

                context.Product.Add(new Product { CustomerId = customerId, Description = "A beautiful handmade beaded bracelet.", Name = "Beaded Bracelet", Price = 2850, ProductTypeId = productTypeId, Quantity = 7 });
                context.Product.Add(new Product { CustomerId = customerId, Description = "A beautiful handmade charm bracelet.", Name = "Charm Bracelet", Price = 4200, ProductTypeId = productTypeId, Quantity = 3 });

                customerId = (from c in context.Customer
                              where c.LastName.Equals("Chenard") && c.FirstName.Equals("Jeraldine")
                              select c.Id).Single();

                productTypeId = (from pc in context.ProductType
                                 where pc.Description.Equals("Home & Living")
                                 select pc.Id).Single();

                context.Product.Add(new Product { CustomerId = customerId, Description = "A very warm beautifully hand crafted quilt.", Name = "Handmade Quilt", Price = 15525, ProductTypeId = productTypeId, Quantity = 4 });

                customerId = (from c in context.Customer
                              where c.LastName.Equals("Lone") && c.FirstName.Equals("Mila")
                              select c.Id).Single();

                productTypeId = (from pc in context.ProductType
                                 where pc.Description.Equals("Arts & Collectibles")
                                 select pc.Id).Single();

                context.Product.Add(new Product { CustomerId = customerId, Description = "An elephant themed, wooden, hand decorated trinket box.", Name = "Elephant Trinket Box", Price = 2175, ProductTypeId = productTypeId, Quantity = 3 });
                context.Product.Add(new Product { CustomerId = customerId, Description = "An owl themed, wooden, hand decorated trinket box.", Name = "Owl Trinket Box", Price = 2175, ProductTypeId = productTypeId, Quantity = 3 });

                context.SaveChanges();
            }

            /*****************************/
            /* Seeding PaymentType Table */
            /*****************************/
            if (!context.PaymentType.Any())
            {
                context.PaymentType.Add(new PaymentType { Description = "PayPal" });
                context.PaymentType.Add(new PaymentType { Description = "Apple Pay" });
                context.PaymentType.Add(new PaymentType { Description = "VISA" });
                context.PaymentType.Add(new PaymentType { Description = "Master Card" });
                context.SaveChanges();
            }

            /*****************************/
            /* Seeding Payment     Table */
            /*****************************/
            if (!context.Payment.Any())
            {
                context.Payment.Add(new Payment { AccountNumber = 123456789, CustomerId = 1, PaymentTypeId = 1 });
                context.Payment.Add(new Payment { AccountNumber = 234523452, CustomerId = 1, PaymentTypeId = 2 });
                context.Payment.Add(new Payment { AccountNumber = 345634567, CustomerId = 2, PaymentTypeId = 3 });
                context.Payment.Add(new Payment { AccountNumber = 234523456, CustomerId = 3, PaymentTypeId = 4 });
                context.Payment.Add(new Payment { AccountNumber = 523452623, CustomerId = 4, PaymentTypeId = 1 });
                context.Payment.Add(new Payment { AccountNumber = 123412343, CustomerId = 4, PaymentTypeId = 2 });
                context.Payment.Add(new Payment { AccountNumber = 725835686, CustomerId = 5, PaymentTypeId = 3 });
                context.Payment.Add(new Payment { AccountNumber = 346235476, CustomerId = 6, PaymentTypeId = 4 });
                context.Payment.Add(new Payment { AccountNumber = 088675434, CustomerId = 7, PaymentTypeId = 1 });
                context.Payment.Add(new Payment { AccountNumber = 653424356, CustomerId = 8, PaymentTypeId = 2 });
                context.Payment.Add(new Payment { AccountNumber = 875456345, CustomerId = 9, PaymentTypeId = 3 });
                context.Payment.Add(new Payment { AccountNumber = 087657456, CustomerId = 10, PaymentTypeId = 3 });
                context.Payment.Add(new Payment { AccountNumber = 123434457, CustomerId = 11, PaymentTypeId = 4 });
                context.Payment.Add(new Payment { AccountNumber = 456776876, CustomerId = 12, PaymentTypeId = 1 });
                context.Payment.Add(new Payment { AccountNumber = 456543452, CustomerId = 13, PaymentTypeId = 2 });
                context.Payment.Add(new Payment { AccountNumber = 976046345, CustomerId = 14, PaymentTypeId = 3 });
                context.Payment.Add(new Payment { AccountNumber = 123443523, CustomerId = 15, PaymentTypeId = 4 });
                context.Payment.Add(new Payment { AccountNumber = 046673452, CustomerId = 16, PaymentTypeId = 1 });
                context.Payment.Add(new Payment { AccountNumber = 124556433, CustomerId = 17, PaymentTypeId = 2 });
                context.Payment.Add(new Payment { AccountNumber = 457334512, CustomerId = 18, PaymentTypeId = 3 });
                context.Payment.Add(new Payment { AccountNumber = 864562345, CustomerId = 19, PaymentTypeId = 4 });
                context.Payment.Add(new Payment { AccountNumber = 864526345, CustomerId = 20, PaymentTypeId = 2 });
                context.Payment.Add(new Payment { AccountNumber = 543645425, CustomerId = 20, PaymentTypeId = 3 });
                context.Payment.Add(new Payment { AccountNumber = 656548794, CustomerId = 18, PaymentTypeId = 4 });
                context.Payment.Add(new Payment { AccountNumber = 654385567, CustomerId = 17, PaymentTypeId = 1 });
                context.SaveChanges();
            }

            if (!context.Orders.Any())
            {
                context.Orders.Add(new Orders { CustomerId = 1, PaymentId = 1, Time = Convert.ToDateTime("02/16/2017") });
                context.Orders.Add(new Orders { CustomerId = 2, PaymentId = 1 });
                context.Orders.Add(new Orders { CustomerId = 2, PaymentId = 1, Time = Convert.ToDateTime("02/16/2017") });
                context.Orders.Add(new Orders { CustomerId = 3, PaymentId = 1, Time = Convert.ToDateTime("02/16/2017") });
                context.Orders.Add(new Orders { CustomerId = 4, PaymentId = 1 });
                context.Orders.Add(new Orders { CustomerId = 5, PaymentId = 1, Time = Convert.ToDateTime("02/16/2017") });
                context.Orders.Add(new Orders { CustomerId = 7, PaymentId = 1, Time = Convert.ToDateTime("02/16/2017") });
                context.Orders.Add(new Orders { CustomerId = 8, PaymentId = 1, Time = Convert.ToDateTime("02/16/2017") });
                context.Orders.Add(new Orders { CustomerId = 10, PaymentId = 1 });
                context.Orders.Add(new Orders { CustomerId = 11, PaymentId = 1, Time = Convert.ToDateTime("02/16/2017") });
                context.Orders.Add(new Orders { CustomerId = 12, PaymentId = 1, Time = Convert.ToDateTime("02/16/2017") });
                context.Orders.Add(new Orders { CustomerId = 13, PaymentId = 1, Time = Convert.ToDateTime("02/16/2017") });
                context.Orders.Add(new Orders { CustomerId = 14, PaymentId = 1, Time = Convert.ToDateTime("02/16/2017") });
                context.Orders.Add(new Orders { CustomerId = 15, PaymentId = 1 });
                context.Orders.Add(new Orders { CustomerId = 16, PaymentId = 1, Time = Convert.ToDateTime("02/16/2017") });
                context.Orders.Add(new Orders { CustomerId = 17, PaymentId = 1, Time = Convert.ToDateTime("02/16/2017") });
                context.Orders.Add(new Orders { CustomerId = 18, PaymentId = 1 });
                context.Orders.Add(new Orders { CustomerId = 19, PaymentId = 1, Time = Convert.ToDateTime("02/16/2017") });
                context.Orders.Add(new Orders { CustomerId = 20, PaymentId = 1, Time = Convert.ToDateTime("02/16/2017") });
                context.SaveChanges();
            }

            if (!context.ProductOrder.Any())
            {
                context.ProductOrder.Add(new ProductOrder { ProductId = 1, OrdersId = 1 });
                context.ProductOrder.Add(new ProductOrder { ProductId = 1, OrdersId = 1 });
                context.ProductOrder.Add(new ProductOrder { ProductId = 1, OrdersId = 1 });
                context.ProductOrder.Add(new ProductOrder { ProductId = 2, OrdersId = 1 });
                context.ProductOrder.Add(new ProductOrder { ProductId = 2, OrdersId = 1 });
                context.ProductOrder.Add(new ProductOrder { ProductId = 2, OrdersId = 2 });
                context.ProductOrder.Add(new ProductOrder { ProductId = 3, OrdersId = 2 });
                context.ProductOrder.Add(new ProductOrder { ProductId = 3, OrdersId = 3 });
                context.ProductOrder.Add(new ProductOrder { ProductId = 3, OrdersId = 4 });
                context.ProductOrder.Add(new ProductOrder { ProductId = 4, OrdersId = 5 });
                context.ProductOrder.Add(new ProductOrder { ProductId = 4, OrdersId = 5 });
                context.ProductOrder.Add(new ProductOrder { ProductId = 5, OrdersId = 6 });
                context.ProductOrder.Add(new ProductOrder { ProductId = 6, OrdersId = 7 });
                context.ProductOrder.Add(new ProductOrder { ProductId = 6, OrdersId = 7 });
                context.ProductOrder.Add(new ProductOrder { ProductId = 7, OrdersId = 8 });
                context.ProductOrder.Add(new ProductOrder { ProductId = 7, OrdersId = 8 });
                context.ProductOrder.Add(new ProductOrder { ProductId = 8, OrdersId = 9 });
                context.ProductOrder.Add(new ProductOrder { ProductId = 9, OrdersId = 10 });
                context.ProductOrder.Add(new ProductOrder { ProductId = 10, OrdersId = 10 });
                context.SaveChanges();
            }
        }
    }
}
