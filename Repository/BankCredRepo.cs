using BusSystem.API.Model;
using Microsoft.EntityFrameworkCore;
using BusSystem.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusSystem.API.Repository
{
    public class BankCredRepo : IBankCredRepo
    {
        private BusDbContext _busDb;

        public BankCredRepo(BusDbContext busDb)
        {
            _busDb = busDb;
        }
        public string DeactBankCred(int BankCredId)
        {
            string Result = string.Empty;
            BankCred delete;

            try
            {
                delete = _busDb.bankCred.Find(BankCredId);

                if (delete != null)
                {
                    //_busDb.busDb.Remove(delete);
                    delete.isActive = false;
                    _busDb.SaveChanges();
                    Result = "200";
                }
            }
            catch (Exception ex)
            {
                Result = "400";
            }
            finally
            {
                delete = null;
            }
            return Result;
        }
        #region GetAllBankCred
        public List<BankCred> GetAllBankCreds()
        {
            List<BankCred> bankcred = null;
            try
            {
                bankcred = _busDb.bankCred.ToList();
            }
            catch (Exception ex)
            {

            }
            return bankcred;

        }
        #endregion


        #region GetBankCred
        public BankCred GetBankCred(int BankCredId)
        {

            BankCred bankcred = null;
            try
            {
                bankcred = _busDb.bankCred.Find(BankCredId);
                return bankcred;
            }
            catch (Exception ex)
            {

            }
            return bankcred;
        }
        #endregion

        #region SaveBankCred
        public string SaveBankCred(BankCred bankcred)
        {
            try
            {

                _busDb.bankCred.Add(bankcred);
                _busDb.SaveChanges();
            }
            catch (Exception ex)
            {

            }

            return "Saved";
        }
        #endregion

        #region UpdateBankCred
        public string UpdateBankCred(BankCred bankcred)
        {
            try
            {
                _busDb.Entry(bankcred).State = EntityState.Modified;
                _busDb.SaveChanges();
            }
            catch (Exception ex)
            {

            }

            return "Updated";
        }
        #endregion
    }
}