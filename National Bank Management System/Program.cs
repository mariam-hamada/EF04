
using Microsoft.EntityFrameworkCore;
using National_Bank_Management_System;
using National_Bank_Management_System.Entites;

namespace National_Bank_Managemen_tSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BankDbContext())
            {
                db.Database.Migrate();
            }

            bool exit = false;

            while (!exit)
            {
                Console.Clear();

                Console.WriteLine("======================================");
                Console.WriteLine("       National Bank - Management");
                Console.WriteLine("======================================");
                Console.WriteLine("1) Add a new Customer");
                Console.WriteLine("2) Open a new Account for a Customer");
                Console.WriteLine("3) Update Account Status (Active / Closed)");
                Console.WriteLine("4) Remove an Account from a Customer");
                Console.WriteLine("5) List all Customers (with accounts)");
                Console.WriteLine("0) Exit");
                Console.WriteLine("---------------------------------------");

                int choice = ReadInt("Enter choice: ");
                Console.Clear();

                try
                {
                    switch (choice)
                    {
                        case 1:
                            AddCustomer();
                            break;

                        case 2:
                            OpenAccount();
                            break;

                        case 3:
                            UpdateAccountStatus();
                            break;

                        case 4:
                            RemoveAccount();
                            break;

                        case 5:
                            ListCustomers();
                            break;

                        case 0:
                            exit = true;
                            Console.WriteLine("Thank you for using National Bank!");
                            continue;

                        default:
                            Console.WriteLine("Invalid choice! Please select from 0 to 5.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }

                Console.WriteLine();
                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadKey();
                
            }
            Console.Clear();

        }


        static void AddCustomer()
        {
            using var db = new BankDbContext();

            Console.WriteLine("\n---Add New Customer ---");

            string fullName = ReadRequiredString("Full Name     : ");

            string nationalId = ReadRequiredString("National ID   : ");

            DateTime dob = ReadDate("Date of Birth :(yyyy-MM-dd) ");

            string email = ReadEmail("Email         : ");

            string phone = ReadRequiredString("Phone Number  : ");

            string address = ReadRequiredString("Address       : ");

            int customerType = ReadInt(
                "Customer Type:\n" +
                "      1) Individual\n " +
                "     2) Business \n"+
                "  Choice:");
            string type;

            switch (customerType)
            {
                case 1:
                    type = "Individual";
                    break;

                case 2:
                    type = "Business";
                    break;

                default:
                    Console.WriteLine("Invalid Choice!");
                    return;
            }

            bool exists = db.Customers.Any(
                c => c.NationalId == nationalId);

            if (exists)
            {
                Console.WriteLine("Customer with this National ID already exists!");
                return;
            }

            Customer customer = new Customer
            {
                FullName = fullName,
                NationalId = nationalId,
                Email = email,
                PhoneNumber = phone,
                Address = address,
                DateOfBirth = dob,
                CustomerType = type
            };

            db.Customers.Add(customer);

            db.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"\nCustomer created successfully. CustomerId =  {customer.Id}");

            Console.ResetColor();
        }


        static void OpenAccount()
        {
            using var db = new BankDbContext();

            Console.WriteLine("\n--- Open New Account ---");

            string accountNumber = ReadRequiredString("Account Number   : ");

            int accountType = ReadInt("Account Type: \n"
                                     +"    1) Savings\n "
                                     +"   2) Checking\n"+
                                      "    3) Business\n"+
                                      "  Choice:");
            string type;

            switch (accountType)
            {
                case 1:
                    type = "Savings";
                    break;

                case 2:
                    type = "Checking";
                    break;

                case 3:
                    type = "Business";
                    break;

                default:
                    Console.WriteLine("Invalid Choice!");
                    return;
            }

            int branchCode = ReadInt("Branch Code      : ");

            int customerId = ReadInt("Customer ID      : ");

            int ownershipType = ReadInt(
                "Ownership Role:\n"+
                "    1) Primary\n"+
                "    2) CoHolder\n"+
                "  Choice:");
            string OwnerShip;

            switch (ownershipType)
            {
                case 1:
                    OwnerShip = "Primary";
                    break;

                case 2:
                    OwnerShip = "CoHolder";
                    break;

                default:
                    Console.WriteLine("Invalid Choice!");
                    return;
            }

            if (db.Accounts.Any(
                a => a.AccountNumber == accountNumber))
            {
                Console.WriteLine("Account number already exists!");
                return;
            }


            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine($"\nValidating branch '{branchCode}' and customer #{customerId}...");

            Console.ResetColor();


            Branch branch = db.Branches.Find(branchCode);

            if (branch == null)
            {
                Console.WriteLine("Branch does not exist!");
                return;
            }



            Customer customer = db.Customers.Find(customerId);

            if (customer == null)
            {
                Console.WriteLine("Customer does not exist!");
                return;
            }



            Account account = new Account
            {
                AccountNumber = accountNumber,
                AccountType = type,
                CurrentBalance = 0,
                OpeningDate = DateTime.Now,
                BranchCode = branchCode
            };



            CustomerAccount customerAccount = new CustomerAccount
            {
                AccountNumber = accountNumber,
                CustomerId = customerId,
                OwnershipStartDate = DateTime.Now,
                OwnershipType = OwnerShip,
                AccountStatus = "Active"
            };

            db.Accounts.Add(account);

            db.CustomerAccounts.Add(customerAccount);

            db.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"\nAccount '{accountNumber}' created and linked to customer {customerId} as Primary owner");

            Console.ResetColor();
        }



        static void UpdateAccountStatus()
        {
            using var db = new BankDbContext();

            Console.WriteLine("\n--- Update Account Status ---");

            string accountNumber =
                ReadRequiredString("Account Number : ");

            int customerId = ReadInt("Customer ID    : ");

            int newStatusChoice = ReadInt(
                "New Status:\n" +
                "    1) Active\n" +
                "    2) Closed\n" +
                "  Choice: ");

            string newStatus;
            switch(newStatusChoice){
                case 1:
                newStatus = "Active";
                break;
            case 2:
                newStatus = "Closed";
                break;
            default:
                Console.WriteLine("Invalid choice!");
                return;
            }

            CustomerAccount customerAccount =
                db.CustomerAccounts.Find(customerId, accountNumber);

            if (customerAccount == null)
            {
                Console.WriteLine("Customer account relationship not found!");
                return;
            }



            customerAccount.AccountStatus = newStatus;

            db.SaveChanges();

            Console.WriteLine(
                $"Status updated to {customerAccount.AccountStatus}");
        }


        static void RemoveAccount()
        {
            using var db = new BankDbContext();

            Console.WriteLine("\n--- Remove Account From Customer ---");

            string accountNumber =
                ReadRequiredString("Account Number  : ");

            int customerId = ReadInt("Customer ID     : ");

            CustomerAccount customerAccount =
                db.CustomerAccounts.Find(customerId, accountNumber);

            if (customerAccount == null)
            {
                Console.WriteLine("Customer account relationship not found!");
                return;
            }

            db.CustomerAccounts.Remove(customerAccount);

            db.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine( "Ownership link deleted.");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"    That was the last owner - account '{customerAccount.AccountNumber}' was also removed");
            Console.ResetColor();
        }


        static void ListCustomers()
        {
            using var db = new BankDbContext();

            Console.WriteLine("\n--- All Customers ---");


            var customers = db.Customers
                .Include(c => c.CustomerAccounts)
                    .ThenInclude(ca => ca.Account)
                    .ThenInclude(a => a.Branch)
                .ToList();

            if (!customers.Any())
            {
                Console.WriteLine("No customers found!");
                return;
            }

            foreach (var customer in customers)
            {
                Console.WriteLine($"#{customer.Id}   {customer.FullName}  ({customer.CustomerType})");
               

                if (!customer.CustomerAccounts.Any())
                {
                    Console.WriteLine("        (no accounts) ");
                }

                foreach (var ca in customer.CustomerAccounts)
                {

                    Console.WriteLine( $"        {ca.Account.AccountNumber}      {ca.Account.AccountType}     Balance:    {ca.Account.CurrentBalance}     {ca.OwnershipType}     {ca.AccountStatus}    @ {ca.Account.Branch.Name}   ");
                }
            }
        }




        static int ReadInt(string message)
        {
            int value;

            while (true)
            {
                Console.Write(message);

                if (int.TryParse(Console.ReadLine(), out value))
                    return value;

                Console.WriteLine("Invalid number! Try again.");
            }
        }

        static string ReadRequiredString(string message)
        {
            while (true)
            {
                Console.Write(message);

                string value = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(value))
                    return value.Trim();

                Console.WriteLine("This field is required!");
            }
        }

        static string ReadEmail(string message)
        {
            while (true)
            {
                string email = ReadRequiredString(message);

                if (email.Contains("@") &&
                    email.Contains(".") &&
                    email.IndexOf("@") > 0)
                {
                    return email;
                }

                Console.WriteLine("Invalid email format!");
            }
        }

        static DateTime ReadDate(string message)
        {
            while (true)
            {
                Console.Write(message);

                if (DateTime.TryParse(
                    Console.ReadLine(), out DateTime date)
                    && date < DateTime.Today)
                {
                    return date;
                }

                Console.WriteLine("Invalid date! Enter a valid past date.");
            }
        }

        static string ReadChoice(
            string message,
            string option1,
            string option2)
        {
            while (true)
            {
                Console.Write(message);

                string value = Console.ReadLine()?.Trim();

                if (string.Equals(value, option1,
                    StringComparison.OrdinalIgnoreCase))
                    return option1;

                if (string.Equals(value, option2,
                    StringComparison.OrdinalIgnoreCase))
                    return option2;

                Console.WriteLine(
                    $"Please enter {option1} or {option2}.");
            }
        }
    }
}
