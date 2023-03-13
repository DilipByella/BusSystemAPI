using BusSystem.API.Model;
using BusSystem.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusSystem.API.Services
{
    public class QuotaServices
    {
        private IQuotaRepo _Iquota;
        public QuotaServices(IQuotaRepo Iquota)
        {
            _Iquota = Iquota;
        }
        public string SaveQuota(Quota quota)
        {
            return _Iquota.SaveQuota(quota);
        }
        public string UpdateQuota(Quota quota)
        {
            return _Iquota.UpdateQuota(quota);
        }
        public Quota GetQuota(int QuotaId)
        {
            return _Iquota.GetQuota(QuotaId);
        }
        public List<Quota> GetAllQuotas()
        {
            return _Iquota.GetAllQuotas();
        }
    }
}