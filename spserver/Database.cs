using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using spserver.Models;
using spserver.Utilities;

namespace spserver
{
    class Database
    {
        private const string DatabaseFile = "data.json";

        private static Database _database;

        public List<UserAccount> UserAccounts { get; }
        public List<ChatMessage> ChatMessages { get; }

        private Database()
        {
            UserAccounts = new List<UserAccount>();
            ChatMessages = new List<ChatMessage>();
        }

        private static Database LoadDatabases()
        {
            if (File.Exists(DatabaseFile))
            {
                try
                {
                    BetterConsole.WriteLog("Loading database.");
                    var json = File.ReadAllText(DatabaseFile);
                    return JsonConvert.DeserializeObject<Database>(json);
                }
                catch (Exception)
                {
                    BetterConsole.WriteLog("There was an error loading the database.");
                }
            }

            BetterConsole.WriteLog("Initializing new database.");
            return new Database();
            
        }

        public void SaveDatabases()
        {
            try
            {
                BetterConsole.WriteLog("Saving database.");
                var json = JsonConvert.SerializeObject(this);
                File.WriteAllText(DatabaseFile, json);
            }
            catch (Exception)
            {
                BetterConsole.WriteLog("There was an error saving the database.");
            }
        }

        public static Database GetDatabase()
        {
            return _database ?? (_database = LoadDatabases());
        }
    }
}
