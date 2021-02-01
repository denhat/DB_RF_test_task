using DB_RF_test_task.Repositories.Criteria;
using DB_RF_test_task.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DB_RF_test_task.Repositories.Repositories
{
    public interface ICitizensRepository
    {
        Task<CitizenEntity> GetAsync(int id);
        Task<CitizenEntity[]> SearchAsync(SearchCriteria criteria, int? skip, int? take);
        Task CreateAsync(CitizenEntity[] entities);
        Task UpdateAsync(CitizenEntity[] entities);
        Task DeleteAsync(int[] ids);
    }

    public class CitizensRepository : ICitizensRepository
    {
        public async Task<CitizenEntity> GetAsync(int id)
        {
            using (var context = new CitizensContext())
            {
                var entity = await context.Citizens.FirstOrDefaultAsync(a => a.id == id).ConfigureAwait(false);
                if (entity == null)
                {
                    throw new Exception($"Citizen with such ID is not found. ID = {id}");
                }

                return entity;
            }
        }

        public async Task<CitizenEntity[]> SearchAsync(SearchCriteria criteria, int? skip, int? take)
        {
            criteria = criteria ?? new SearchCriteria();

            using (var context = new CitizensContext())
            {
                IQueryable<CitizenEntity> qresult = context.Citizens;

                //search filters
                if (criteria.Ids != null && criteria.Ids.Any())
                {
                    qresult = qresult.Where(a => criteria.Ids.Contains(a.id));
                }
                if (!string.IsNullOrEmpty(criteria.FirstName))
                {
                    qresult = qresult.Where(a => a.first_name != null && a.first_name.ToLower().Contains(criteria.FirstName.ToLower()));
                }
                if (!string.IsNullOrEmpty(criteria.LastName))
                {
                    qresult = qresult.Where(a => a.last_name != null && a.last_name.ToLower().Contains(criteria.LastName.ToLower()));
                }
                if (!string.IsNullOrEmpty(criteria.Patronymic))
                {
                    qresult = qresult.Where(a => a.patronymic != null && a.patronymic.ToLower().Contains(criteria.Patronymic.ToLower()));
                }
                if (!string.IsNullOrEmpty(criteria.Inn))
                {
                    qresult = qresult.Where(a => a.inn != null && a.inn.ToLower().Contains(criteria.Inn.ToLower()));
                }
                if (!string.IsNullOrEmpty(criteria.Snils))
                {
                    qresult = qresult.Where(a => a.snils != null && a.snils.ToLower().Contains(criteria.Snils.ToLower()));
                }
                if (criteria.BirthDates != null && criteria.BirthDates.Any())
                {
                    qresult = qresult.Where(a => a.birth_date.HasValue && criteria.BirthDates.Contains(a.birth_date.Value));
                }
                if (criteria.DeathDates != null && criteria.DeathDates.Any())
                {
                    qresult = qresult.Where(a => a.death_date.HasValue && criteria.DeathDates.Contains(a.death_date.Value));
                }

                //getting a part of result
                if (skip.HasValue)
                {
                    qresult = qresult.Skip(skip.Value);
                }
                if (take.HasValue)
                {
                    qresult = qresult.Take(take.Value);
                }

                //query executing and getting actual results
                var result = qresult.ToArray();

                return result;
            }
        }

        public async Task CreateAsync(CitizenEntity[] entities)
        {
            if (entities == null || !entities.Any())
            {
                return;
            }

            using (var context = new CitizensContext())
            {
                var cdate = DateTime.UtcNow;
                foreach (var entity in entities)
                {
                    entity.cdate = entity.udate = cdate;
                    context.Citizens.Add(entity);
                }

                await context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task UpdateAsync(CitizenEntity[] entities)
        {
            if (entities == null || !entities.Any())
            {
                return;
            }

            using (var context = new CitizensContext())
            {
                DateTime oldCdate;
                DateTime udate = DateTime.UtcNow;
                foreach (var entity in entities)
                {
                    var oldEntity = await context.Citizens.FirstOrDefaultAsync(a => a.id == entity.id).ConfigureAwait(false);
                    if (oldEntity == null)
                    {
                        throw new Exception($"Citizen with such ID is not found. ID = {entity.id}");
                    }

                    oldCdate = oldEntity.cdate;
                    entity.CopyTo(oldEntity);
                    oldEntity.cdate = oldCdate;
                    oldEntity.udate = udate;
                }

                await context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        public async Task DeleteAsync(int[] ids)
        {
            if (ids == null || !ids.Any())
            {
                throw new ArgumentNullException("Citizen IDs are not specified");
            }

            using (var context = new CitizensContext())
            {
                foreach (var id in ids)
                {
                    var oldEntity = await context.Citizens.FirstOrDefaultAsync(a => a.id == id).ConfigureAwait(false);
                    if (oldEntity == null)
                    {
                        throw new Exception($"Citizen with such ID is not found. ID = {id}");
                    }
                    context.Citizens.Remove(oldEntity);
                }

                await context.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}
