using BusSystem.API.Model;
using Microsoft.EntityFrameworkCore;
using BusSystem.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusSystem.API.Repository
{
    public class QuotaRepo : IQuotaRepo
    {
        private BusDbContext _busDb;
        public QuotaRepo(BusDbContext busDbContext)
        {
            _busDb = busDbContext;
        }
        public string SaveQuota(Quota quota)
        {
            string stCode = string.Empty;
            try
            {
                _busDb.quotas.Add(quota);
                _busDb.SaveChanges();
                stCode = "200";
            }
            catch
            {
                stCode = "400";
            }
            return stCode;
        }

        public string DeactQuota(int QuotaId)
        {
            string Result = string.Empty;
            Quota delete;

            try
            {
                delete = _busDb.quotas.Find(QuotaId);

                if (delete != null)
                {
                    delete.isActive = false;
                    _busDb.SaveChanges();
                    Result = "Deactivated";
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

        public string UpdateQuota(Quota quota)
        {
            string Result = string.Empty;
            try
            {
                _busDb.Entry(quota).State = EntityState.Modified;
                _busDb.SaveChanges();
                Result = "200";
            }
            catch (Exception ex)
            {
                Result = "400";
            }
            return Result;
        }

        public Quota GetQuota(int QuotaId)
        {
            Quota quota = null;
            try
            {
                quota = _busDb.quotas.Find(QuotaId);
            }
            catch (Exception ex)
            {

            }
            return quota;
        }

        public List<Quota> GetAllQuotas()
        {

            List<Quota> quotas = null;
            try
            {
                quotas = _busDb.quotas.ToList();

            }
            catch (Exception ex)
            {

            }
            return quotas;

        }


    }
}