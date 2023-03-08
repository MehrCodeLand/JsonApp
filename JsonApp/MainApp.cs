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
        private static readonly string filePath = @"C:\JsonAppFile\JsonFile.json";
        public static void Main()
        {
            CreateJsonFile();
            
            WriteData();

            ReadJsonFile();
        }

        #region Write Json File

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
            File.WriteAllText(filePath, jsonStr);
        }


        #endregion

        #region Read Json File

        // Find file and deserialize our obj
        public static void ReadJsonFile()
        {
            /*
             * NOTIC-> First you must convert JSON file
             * to str to read that!
            */
            List<User> users = new List<User>();
            string jsonStrFile = File.ReadAllText(filePath);
            users = JsonConvert.DeserializeObject<List<User>>(jsonStrFile);

            ShowJsonFile(users);
        }

        // show our data to user
        public static void ShowJsonFile(List<User> users)
        {
            int userCount = 1;
            foreach(var user in users)
            {
                Console.WriteLine("" +
                    $"User:{userCount}\n" +
                    $"Username:{user.Username}\n" +
                    $"Password:{user.Password}\n" +
                    $"- - -");
            }

            ShowEndMessage();
        }

        // end message !
        public static void ShowEndMessage()
        {
            Console.WriteLine("\n---MehrCodeLand---");
        }

        #endregion


    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
