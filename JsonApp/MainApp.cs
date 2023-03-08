using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;


// first install Newtonsoft.Json !
namespace JsonApp
{
    public class MainApp
    {
        public static void Main()
        {
            CreateJsonFile();
            
            WriteData();
        }

        // create Folder and File in drive C
        public static void CreateJsonFile()
        {
            if (!File.Exists(@"C:\JsonAppFile\JsonFile.json"))
            {
                System.IO.Directory.CreateDirectory(@"C:\JsonAppFile");
                var myFile = File.Create(@"C:\JsonAppFile\JsonFile.json");
                myFile.Close();
            }
            else
            {
                File.Delete(@"C:\JsonAppFile\JsonFile.json");
                System.IO.Directory.Delete(@"C:\JsonAppFile");
                CreateJsonFile();
            }
        }
        
        // create our fake data
        public static List<User> CreateData()
        {
            List<User> users = new List<User>();
            User user1 = new User()
            {
                Username = "mehrshad",
                Password = "1234",
            };

            User user2 = new User()
            {
                Username = "Aria",
                Password = "4321",
            };

            users.Add(user1);
            users.Add(user2);

            return users;
        }

        // convert our data to the json file
        public static string CreateJsonString()
        {
            var jsonStr = JsonConvert.SerializeObject(CreateData());
            return jsonStr;
        }

        // main function and write all data to json file
        public static void WriteData()
        {
            var jsonStr = CreateJsonString();
            var path = @"C:\JsonAppFile\JsonFile.json";
            File.WriteAllText(path, jsonStr);
        }
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
