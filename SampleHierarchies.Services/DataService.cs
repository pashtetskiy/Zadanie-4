using Bank.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bank.Services
{
    public class DataService
    {
        private readonly string DATAPATH = "data.json";
        public void LoadData()
        {
            BankAccounts bank = new BankAccounts();
            bank.bankAccounts.Add(new BankAccount("dada", 21));
            bank.bankAccounts.Add(new BankAccount("d12a", 221));
            File.WriteAllText("Json.json", JsonConvert.SerializeObject(bank));
     
            string data = File.ReadAllText(DATAPATH);
            JsonConvert.DeserializeObject<BankAccounts>(data);
            Console.WriteLine(data);
        }
    }
}
