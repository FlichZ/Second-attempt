using Newtonsoft.Json;
using System;
using System.Xml;
using System.Xml.Serialization;

namespace ConsoleApp11
{
    public class User
    {

        public string Name { get; set; }
        public int CharsPerMinute { get; set; }
        public float CharsPerSecond { get; set; }

        public User(string nameArg, int charsPerMinuteArg)
        {
            Name = nameArg;
            CharsPerMinute = charsPerMinuteArg;
            CharsPerSecond = (float)charsPerMinuteArg / 60;
        }

        public static List<User> Serializing(string name, int index)
        {
            string json = File.ReadAllText("C:\\P50-2-21\\OAIP Sophia\\ConsoleApp9\\record.json");
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json);
            User user = new User(name, index);
            users.Add(user);

            json = JsonConvert.SerializeObject(users);
            File.WriteAllText("C:\\P50-2-21\\OAIP Sophia\\ConsoleApp9\\record.json", json);

            return users;
        }
    }
    
}
