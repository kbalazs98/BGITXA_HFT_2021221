using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BGITXA_HFT_2021221.Models;

namespace BGITXA_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            RestService rest = new RestService("http://localhost:9910");
            System.Threading.Thread.Sleep(5000);

            bool isRunning = true;
            while (isRunning)
            {
                int input;
                Console.WriteLine("Select from the list below!");
                Console.WriteLine("[1] Televisions");
                Console.WriteLine("[2] Brands");
                Console.WriteLine("[3] Orders");
                Console.WriteLine("[4] Queries");
                Console.WriteLine("[5] Exit");

                try
                {
                    input = int.Parse(Console.ReadLine());
                    Console.Clear();
                    switch (input)
                    {
                        case 1:
                            ModifyingTelevisions(rest);
                            break;
                        case 2:
                            ModifyingBrands(rest);
                            break;
                        case 3:
                            ModifyingOrders(rest);
                            break;
                        case 4:
                            Queries(rest);
                            break;
                        case 5:
                            isRunning = false;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                catch (FormatException f)
                {
                    Console.Clear();
                    Console.WriteLine(f.Message);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.Clear();
                    Console.WriteLine("No such an option");
                }
            }
        }
        public static void ModifyingTelevisions(RestService rest)
        {
            Console.WriteLine("Which action do you wish to perform?");

            Console.WriteLine("[1] List all tvs");
            Console.WriteLine("[2] List a tv based on Id");
            Console.WriteLine("[3] Create a new tv");
            Console.WriteLine("[4] Update a given tv");
            Console.WriteLine("[5] Delete a given tv");
            try
            {
                int input = int.Parse(Console.ReadLine());
                Console.Clear();
                string path = "/Television";
                switch (input)
                {
                    case 1:
                        Listitems<Television>(rest, path);
                        break;
                    case 2:
                        ListOne<Television>(rest, path);
                        break;
                    case 3:
                        Create<Television>(rest, path);
                        break;
                    case 4:
                        Update<Television>(rest, path);
                        break;
                    case 5:
                        Delete<Television>(rest, path);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            catch (FormatException f)
            {
                Console.Clear();
                Console.WriteLine(f.Message);
            }
            catch (ArgumentException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }
        public static void ModifyingOrders(RestService rest)
        {
            Console.WriteLine("Which action do you wish to perform?");

            Console.WriteLine("[1] List all orders");
            Console.WriteLine("[2] List an order based on Id");
            Console.WriteLine("[3] Create a new order");
            Console.WriteLine("[4] Update a given order");
            Console.WriteLine("[5] Delete a given order");
            try
            {
                int input = int.Parse(Console.ReadLine());
                Console.Clear();
                string path = "/Order";
                switch (input)
                {
                    case 1:
                        Listitems<Order>(rest, path);
                        break;
                    case 2:
                        ListOne<Order>(rest, path);
                        break;
                    case 3:
                        Create<Order>(rest, path);
                        break;
                    case 4:
                        Update<Order>(rest, path);
                        break;
                    case 5:
                        Delete<Television>(rest, "/Television");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(); ;
                }
            }
            catch (FormatException f)
            {
                Console.Clear();
                Console.WriteLine(f.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }
        public static void ModifyingBrands(RestService rest)
        {
            Console.WriteLine("Which action do you wish to perform?");

            Console.WriteLine("[1] List all brands");
            Console.WriteLine("[2] List a brand based on Id");
            Console.WriteLine("[3] Create a new brand");
            Console.WriteLine("[4] Update a given brand");
            Console.WriteLine("[5] Delete a given brand");
            string path = "/Brand";
            try
            {
                int input = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (input)
                {
                    case 1:
                        Listitems<Brand>(rest, path);
                        break;
                    case 2:
                        ListOne<Order>(rest, path);
                        break;
                    case 3:
                        Create<Brand>(rest, path);
                        break;
                    case 4:
                        Update<Brand>(rest, path);
                        break;
                    case 5:
                        Delete<Television>(rest, "/Television");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            catch (FormatException f)
            {
                Console.Clear();
                Console.WriteLine(f.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }
        public static void Queries(RestService rest)
        {
            Console.WriteLine("Which query do you wish to list?");

            Console.WriteLine("[1] List the average price of brands");
            Console.WriteLine("[2] List the number of tvs in the orders");
            Console.WriteLine("[3] List the average price of the orders");
            Console.WriteLine("[4] List the orders sorted by price");
            Console.WriteLine("[5] Get the cheapest tv of the brand");
            try
            {
                int input = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (input)
                {
                    case 1:
                        AveragePriceOfBrand(rest);
                        break;
                    case 2:
                        CountTvByOrder(rest);
                        break;
                    case 3:
                        AveragePriceOfOrder(rest);
                        break;
                    case 4:
                        OrdersInOrderByPrice(rest);
                        break;
                    case 5:
                        CheapestTvOfTheBrand(rest);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            catch (FormatException f)
            {
                Console.Clear();
                Console.WriteLine(f.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }
        public static void Listitems<T>(RestService rest, string path)
        {
            Console.WriteLine($"API Path: {path}");
            if (typeof(T) == typeof(Television))
            {
                var alltv = rest.Get<Television>(path);
                foreach (var tv in alltv)
                {
                    Console.WriteLine($"[{tv.Id}] Model: {tv.Model} Price: {tv.Price} BrandID: {tv.BrandId} OderID: {tv.OrderId} ");
                }
            }
            if (typeof(T) == typeof(Order))
            {
                var allorder = rest.Get<Order>(path);
                foreach (var order in allorder)
                {
                    Console.WriteLine($"[{order.Id}] {order.CustomerName}");
                    foreach (var tv in order.Televisions)
                    {
                        Console.WriteLine($"        Televisions: [{tv.Id}], Model: {tv.Model}");
                    }
                    Console.WriteLine();
                }
            }
            if (typeof(T) == typeof(Brand))
            {
                var allbrand = rest.Get<Brand>(path);
                foreach (var brand in allbrand)
                {
                    Console.WriteLine($"[{brand.Id}] {brand.Name}");
                    foreach (var tv in brand.Televisions)
                    {
                        Console.WriteLine($"        Televisions: [{tv.Id}], Model: { tv.Model}");
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.Clear();
        }
        public static void ListOne<T>(RestService rest, string path)
        {
            Console.WriteLine($"API Path: {path}");
            if (typeof(T) == typeof(Television))
            {
                try
                {
                    Console.WriteLine("Which id do you want to get?");
                    int id = int.Parse(Console.ReadLine());
                    Console.Clear();

                    var tv = rest.Get<Television>(id, path);
                    if (tv == null)
                    {
                        Console.WriteLine("The id doesnt exist in the database");
                    }
                    else
                    {
                        Console.WriteLine($"[{tv.Id}] Model: {tv.Model} Price: {tv.Price} BrandID: {tv.BrandId} OrderID: {tv.OrderId} ");
                    }

                }
                catch (FormatException e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }
            }
            if (typeof(T) == typeof(Order))
            {
                try
                {
                    Console.WriteLine("Which id do you want to get?");
                    int id = int.Parse(Console.ReadLine());
                    Console.Clear();

                    var order = rest.Get<Order>(id, path);
                    if (order == null)
                    {
                        Console.WriteLine("The id doesnt exist in the database");
                    }
                    else
                    {
                        Console.WriteLine($"[{order.Id}] CustomerName: {order.CustomerName}");
                        foreach (var tv in order.Televisions)
                        {
                            Console.WriteLine($"        Televisions: [{tv.Id}], Model: { tv.Model}");
                        }
                    }
                }
                catch (FormatException e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }
            }
            if (typeof(T) == typeof(Brand))
            {
                try
                {
                    Console.WriteLine("Which id do you want to get?");
                    int id = int.Parse(Console.ReadLine());
                    Console.Clear();

                    var brand = rest.Get<Brand>(id, path);

                    if (brand == null)
                    {
                        Console.WriteLine("The id doesnt exist in the database");
                    }
                    else
                    {
                        Console.WriteLine($"[{brand.Id}] {brand.Name}");
                        foreach (var tv in brand.Televisions)
                        {
                            Console.WriteLine($"        Televisions: [{tv.Id}], Model: { tv.Model}");
                        }
                    }
                }
                catch (FormatException e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.Clear();
        }
        public static void Create<T>(RestService rest, string path)
        {
            Console.WriteLine($"API Path: {path}");
            if (typeof(T) == typeof(Television))
            {
                try
                {
                    Console.WriteLine("Please enter the model!");
                    string model = Console.ReadLine();

                    Console.WriteLine("Please enter the price!");
                    int price = int.Parse(Console.ReadLine());

                    Console.WriteLine("Please enter the id of the brand!");
                    int brandId = int.Parse(Console.ReadLine());

                    Console.WriteLine("Please enter the id of the order!");
                    int ordeID = int.Parse(Console.ReadLine());
                    try
                    {
                        rest.Post(new Television() { Model = model, Price = price, BrandId = brandId, OrderId = ordeID }, "/Television");
                    }
                    catch (System.Net.Http.HttpRequestException)
                    {
                        //FK constraint
                        //if you enter 0 for any of the id's the server will return null and wont notify the user sadly, but if you enter null or "" for the model 
                        // the response.EnsureSuccessStatusCode() throws a HttpRequestException.. 
                        // i dont notify the user with this HttpRequestException to avoid inconsistency, just catching
                    }
                }
                catch (FormatException e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }
                Console.Clear();
                Console.WriteLine("check if it was succesfull");
                Console.WriteLine("press enter to continue");
                Console.ReadLine();
                Console.Clear();
            }

            if (typeof(T) == typeof(Order))
            {
                try
                {
                    Console.WriteLine("Please enter the name of the customer");
                    rest.Post(new Order() { CustomerName = Console.ReadLine() }, "/Order");

                }
                catch (FormatException e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }
                Console.Clear();
                Console.WriteLine("Succesfully added");
            }

            if (typeof(T) == typeof(Brand))
            {
                try
                {
                    Console.WriteLine("Please enter the name of the brand");
                    rest.Post(new Brand() { Name = Console.ReadLine() }, "/Brand");

                }
                catch (FormatException e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }
                Console.Clear();
                Console.WriteLine("Succesfully added");
            }


        }
        public static void Update<T>(RestService rest, string path)
        {
            Console.WriteLine($"API Path: {path}");
            if (typeof(T) == typeof(Television))
            {
                try
                {
                    Console.WriteLine("Please enter the ID-(The system will update the tv with the corresponding id in the database)!");
                    int id = int.Parse(Console.ReadLine());

                    Console.WriteLine("Please enter the model!");
                    string model = Console.ReadLine();

                    Console.WriteLine("Please enter the price!");
                    int price = int.Parse(Console.ReadLine());

                    Console.WriteLine("Please enter the id of the brand!");
                    int brandId = int.Parse(Console.ReadLine());

                    Console.WriteLine("Please enter the id of the order!");
                    int ordeID = int.Parse(Console.ReadLine());

                    try
                    {
                        rest.Post(new Television() { Model = model, Price = price, BrandId = brandId, OrderId = ordeID }, "/Television");
                    }
                    catch (System.Net.Http.HttpRequestException)
                    {
                        //same thing applie here
                    }
                }
                catch (FormatException f)
                {
                    Console.Clear();
                    Console.WriteLine(f.Message);
                }

                Console.Clear();
                Console.WriteLine("check if it was succesfull");
                Console.WriteLine("press enter to continue");
                Console.ReadLine();
                Console.Clear();
            }

            if (typeof(T) == typeof(Order))
            {
                try
                {
                    Console.WriteLine("Please enter the ID-(The system will update the tv with the corresponding id in the database)!");
                    int id = int.Parse(Console.ReadLine());

                    Console.WriteLine("Please enter the name of the customer");
                    string name = Console.ReadLine();

                    rest.Put(new Order() { Id = id, CustomerName = name }, "/Order");
                }
                catch (FormatException f)
                {
                    Console.Clear();
                    Console.WriteLine(f.Message);
                }
                Console.Clear();
                Console.WriteLine("check if it was succesfull");
                Console.WriteLine("press enter to continue");
                Console.ReadLine();
                Console.Clear();
            }

            if (typeof(T) == typeof(Brand))
            {
                try
                {
                    Console.WriteLine("Please enter the ID-(The system will update the tv with the corresponding id in the database)!");
                    int id = int.Parse(Console.ReadLine());

                    Console.WriteLine("Please enter the name of the brand");
                    string name = Console.ReadLine();

                    rest.Put(new Brand() { Id = id, Name = name }, "/Brand");
                }
                catch (FormatException f)
                {
                    Console.Clear();
                    Console.WriteLine(f.Message);
                }

                Console.Clear();
                Console.WriteLine("check if it was succesfull");
                Console.WriteLine("press enter to continue");
                Console.ReadLine();
                Console.Clear();
            };
        }
        public static void Delete<T>(RestService rest, string path)
        {
            Console.WriteLine($"API Path: {path}");
            if (typeof(T) == typeof(Television))
            {
                try
                {
                    Console.WriteLine("which id do you want to delete?");
                    int todelete = int.Parse(Console.ReadLine());
                    rest.Delete(todelete, "/Television");
                }
                catch (FormatException f)
                {
                    Console.Clear();
                    Console.WriteLine(f.Message);
                }
            }

            if (typeof(T) == typeof(Order))
            {
                Console.WriteLine("Important note: Deleting an order which has televisions is not possible.Try deleting the televisions tvs firts.");
                try
                {
                    Console.WriteLine("which id do you want to delete?");
                    int todelete = int.Parse(Console.ReadLine());
                    rest.Delete(todelete, "/Order");
                }
                catch (FormatException f)
                {
                    Console.Clear();
                    Console.WriteLine(f.Message);
                }
            }

            if (typeof(T) == typeof(Brand))
            {
                Console.WriteLine("Important note: Deleting an brand which has televisions is not possible.Try deleting the televisions tvs firts.");
                try
                {
                    Console.WriteLine("which id do you want to delete?");
                    int todelete = int.Parse(Console.ReadLine());
                    rest.Delete(todelete, "/Brand");
                }
                catch (FormatException f)
                {
                    Console.Clear();
                    Console.WriteLine(f.Message);
                }
            }
            Console.WriteLine("check if the delete was succesfull");
            Console.WriteLine("press enter to contiune");   //if wrong id is given it doesnt do anything, it is handled on the serverside
            Console.ReadLine();
            Console.Clear();
        }

        public static void AveragePriceOfBrand(RestService rest)
        {
            Console.WriteLine($"API Path: /noncrud/AveragePriceOfBrand");
            var AveragePriceOfBrand = rest.Get<KeyValuePair<string, double>>("/noncrud/AveragePriceOfBrand");
            foreach (var brand in AveragePriceOfBrand)
            {
                Console.WriteLine($"The average price of {brand.Key} is {brand.Value}");
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.Clear();
        }
        public static void CountTvByOrder(RestService rest)
        {
            Console.WriteLine($"API Path: /noncrud/CountTvByOrder");
            var CountTvByOrder = rest.Get<KeyValuePair<string, int>>("/noncrud/CountTvByOrder");
            foreach (var brand in CountTvByOrder)
            {
                Console.WriteLine($"{brand.Key} bought {brand.Value} number of tvs");
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.Clear();
        }
        public static void AveragePriceOfOrder(RestService rest)
        {
            Console.WriteLine($"API Path: /noncrud/AveragePriceOfOrder");
            var AveragePriceOfOrder = rest.Get<KeyValuePair<string, double>>("/noncrud/AveragePriceOfOrder");
            foreach (var brand in AveragePriceOfOrder)
            {
                Console.WriteLine($"The average price of {brand.Key} is {brand.Value}");
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.Clear();
        }
        public static void OrdersInOrderByPrice(RestService rest)
        {
            Console.WriteLine($"API Path: /noncrud/OrdersInOrderByPrice");
            var OrdersInOrderByPrice = rest.Get<Order>("/noncrud/OrdersInOrderByPrice");
            foreach (var order in OrdersInOrderByPrice)
            {
                Console.WriteLine($"{order.CustomerName}");
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.Clear();
        }
        public static void CheapestTvOfTheBrand(RestService rest)
        {
            Console.WriteLine($"API Path: /noncrud/CheapestTvOfTheBrand");
            try
            {
                Console.WriteLine("Which brand?(id)");
                int id = int.Parse(Console.ReadLine());
                var CheapestTvOfTheBrand = rest.Get<Television>(id, "/noncrud/CheapestTvOfTheBrand");
                if (CheapestTvOfTheBrand == null)
                {
                    Console.Clear();
                    Console.WriteLine("there is no such brand with the given id");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"The cheapest tv is {CheapestTvOfTheBrand.Model} with the price of: {CheapestTvOfTheBrand.Price}");
                }

            }
            catch (FormatException f)
            {
                Console.Clear();
                Console.WriteLine(f.Message);
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
