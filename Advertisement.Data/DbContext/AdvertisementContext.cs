using System;
using System.Data.Entity;
using Advertisement.Entities;
using Core.FrameWork.Base;
using Core.FrameWork.Contract;
using Core.Security;
using Core.Security.Model;
using EntityFramework.Audit;
using EntityFramework.Extensions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Advertisement.DataAccess.DbContext
{
    public class AdvertismentDbContext :
        IdentityDbContext<SecurityUser, SecurityRole, Guid, SecurityUserLogin, SecurityUserRole, SecurityUserClaim>,
        IUnitOfWork
    {
        public AdvertismentDbContext()
            : base("MTAConnection")
        {
            _audit = this.BeginAudit();
            AuditConfiguration.Default.IsAuditable<Person>();
        }

        private AuditLogger _audit;

        public DbSet<Person> Persons { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : EntityBase
        {
            return base.Set<TEntity>();
        }


        public void SetModified<TEntity>(TEntity item) where TEntity : EntityBase
        {

            var entityInDb = Set<TEntity>().Find(item.Id);
            Entry(entityInDb).CurrentValues.SetValues(item);
            Entry(entityInDb).State = EntityState.Modified;
        }

        public int Commit()
        {
            var result = 0;
            try
            {
                result = base.SaveChanges();
                var log = _audit.LastLog;
                var xml = log.ToXml();
                return result;
            }
            catch (Exception e)
            {
                return result;
            }

        }

        public System.Data.Entity.DbSet<Advertisement.Common.Dto.PersonDto> PersonDtoes { get; set; }
    }
}
