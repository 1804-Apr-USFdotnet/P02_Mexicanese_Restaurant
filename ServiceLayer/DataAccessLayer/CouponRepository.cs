using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public class CouponRepository : ICouponRepository
    {
        private readonly MexicaneseModel _repoContext;
        public CouponRepository(MexicaneseModel context)
        {
            _repoContext = context;
        }

        public Coupon GetByID(int ID)
        {
            return _repoContext.Coupons.Find(ID);
        }

        public void AddCoupon(Coupon Cpn)
        {
            _repoContext.Coupons.Add(Cpn);
            _repoContext.SaveChanges();
        }

        public void DeleteCoupon(Coupon Cpn)
        {
            var delete = _repoContext.Coupons.Find(Cpn.id);
            _repoContext.Coupons.Remove(delete);
            _repoContext.SaveChanges();
        }

        public IEnumerable<Coupon> GetAllCoupons()
        {
            return _repoContext.Coupons;
        }

        public void ModifyCoupon(Coupon Cpn)
        {
            var modify = _repoContext.Coupons.Find(Cpn.id);
            _repoContext.Entry(modify).CurrentValues.SetValues(Cpn);
            _repoContext.SaveChanges();
        }

        public void SaveCoupons()
        {
            _repoContext.SaveChanges();
        }
    }
}