using Microsoft.Extensions.DependencyInjection;
using System;

namespace MultiDictionary
{
    class Program
    {
        private static IServiceProvider serviceProvider;
        static void Main(string[] args)
        {
            RegisterServices();
            Console.WriteLine("Multi-Value Dictionary.");
            Console.WriteLine("Type commands followed by 'ENTER'");
            Console.WriteLine("Type Exit to Terminate");
            Console.WriteLine();
            try
            {
                ListenForInput();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ListenForInput()
        {
            var multiValDict = new MultiValueDictionary<string, string>();

            while (true)
            {
                Console.Write(">");
                string userInput = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(userInput))
                {
                    try
                    {
                        var dictHelper = serviceProvider.GetService<IMultiValueDictHelper>();

                        string[] cmdItems = userInput.Split(' ');

                        switch (cmdItems[0].ToUpper())
                        {
                            case "ADD":
                                dictHelper.Add(multiValDict,cmdItems);
                                break;
                            case "KEYS":
                                dictHelper.GetAllKeys(multiValDict);
                                break;
                            case "ALLMEMBERS":
                                dictHelper.GetAllMembers(multiValDict);
                                break;
                            case "MEMBERS":
                                dictHelper.GetKeyMember(multiValDict, cmdItems[1]);
                                break;
                            case "REMOVE":
                                dictHelper.RemoveRecord(multiValDict, cmdItems);
                                break;
                            case "REMOVEALL":
                                dictHelper.RemoveAllRecord(multiValDict, cmdItems[1]);
                                break;
                            case "CLEAR":
                                multiValDict.Clear();
                                Console.WriteLine(") Cleared.");
                                break;
                            case "KEYEXISTS":
                                Console.WriteLine(multiValDict.ContainsKey(cmdItems[1]));
                                break;
                            case "MEMBEREXISTS":
                                Console.WriteLine(multiValDict.Contains(cmdItems[1], cmdItems[2]));
                                break;
                            case "ITEMS":
                                dictHelper.GetAllItems(multiValDict);
                                break;
                            case "EXIT":
                                ExitApp();
                                break;
                            default:
                                Console.WriteLine("Invalid Command.");
                                break;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid Command.");
                        //throw;
                    }
                    
                }

            }
        }
        
        #region Dependency Injection & service life cycle maintainence

        private static void RegisterServices()
        {
            //create a collection/container to hold the services information
            var collection = new ServiceCollection(); 
            // add the service to the collection
            collection.AddSingleton<IMultiValueDictHelper, MultiValueDictHelper>();
            //to fetch the requested service from the container create serviceCollection
            serviceProvider = collection.BuildServiceProvider(); 
        }

        private static void DisposeServices()
        {
            if (serviceProvider == null)
            {
                return;
            }
            if (serviceProvider is IDisposable)
            {
                ((IDisposable)serviceProvider).Dispose();
            }
        }
        // exits the app
        private static void ExitApp()
        {
            Console.Write("Are you sure you want to exit the app?(Yes or No):");
            var resp = Console.ReadLine();
            if (resp.ToLower() == "yes")
            {
                DisposeServices();
                Environment.Exit(0);
            }
            if(resp.ToLower() == "no")
            {
                return;
            }
            else
            {
                ExitApp();
            }
        }
        #endregion
    }
}
