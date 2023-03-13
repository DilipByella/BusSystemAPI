using BusSystem.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusSystem.API.Repository
{
    public interface IQuotaRepo
    {
        public string SaveQuota(Quota quota);
        public string DeactQuota(int QuotaId);
        public string UpdateQuota(Quota quota);
        Quota GetQuota(int QuotaId);
        List<Quota> GetAllQuotas();

    }
}