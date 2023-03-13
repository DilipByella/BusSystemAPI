using Microsoft.EntityFrameworkCore;
using BusSystem.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusSystem.API.Model;

namespace BusSystem.API.Repository
{
    public class TransactionRepo : ITransactionRepo
    {
        private BusDbContext _busDb;

        public TransactionRepo(BusDbContext busDb)
        {
            _busDb = busDb;
        }

        #region GetAllTransactions
        public List<Transaction> GetAllTransaction()
        {
            List<Transaction> transactions = null;
            try
            {
                transactions = _busDb.transaction.ToList();

            }
            catch (Exception ex)
            {

            }
            return transactions;
        }

        #endregion

        #region GetTransaction
        public Transaction GetTransaction(int TransactionId)
        {
            Transaction transaction = null;
            try
            {
                transaction = _busDb.transaction.Find(TransactionId);
            }
            catch (Exception ex)
            {

            }
            return transaction;
        }
        #endregion

        #region SaveTransaction
        public string SaveTransaction(Transaction transaction)
        {
            try
            {
                _busDb.transaction.Add(transaction);
                _busDb.SaveChanges();
            }
            catch (Exception ex)
            {

            }

            return "Saved";
        }
        #endregion

        #region UpdateTransaction
        public string UpdateTransaction(Transaction transaction)
        {
            try
            {
                _busDb.Entry(transaction).State = EntityState.Modified;
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