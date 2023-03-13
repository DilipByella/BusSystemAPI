using BusSystem.API.Model;
using BusSystem.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusSystem.API.Services
{
    public class BankCredServices
    {
        private IBankCredRepo _bankcredRepository;
        public BankCredServices(IBankCredRepo bankcredRepository)
        {
            _bankcredRepository = bankcredRepository;
        }
        public string DeactBankCred(int BankCredId)
        {
            return _bankcredRepository.DeactBankCred(BankCredId);
        }
        public string SaveBankCred(BankCred bankCred)
        {
            return _bankcredRepository.SaveBankCred(bankCred);
        }
        public string UpdateBankCred(BankCred bankCred)
        {
            return _bankcredRepository.UpdateBankCred(bankCred);
        }
        public BankCred GetBankCred(int BankCredId)
        {
            return _bankcredRepository.GetBankCred(BankCredId);
        }
        public List<BankCred> GetAllBankCreds()
        {
            return _bankcredRepository.GetAllBankCreds();
        }
    }
}