using BusSystem.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusSystem.API.Repository
{
    public interface IBankCredRepo
    {
        public string SaveBankCred(BankCred bankcred);
        public string UpdateBankCred(BankCred bankcred);
        public string DeactBankCred(int BankCredId);
        BankCred GetBankCred(int BankCredId);
        List<BankCred> GetAllBankCreds();
    }
}