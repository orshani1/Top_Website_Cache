using Microsoft.Extensions.Caching.Memory;
using Statistics.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Statistics.DB.Logic
{
    public class Logic<T>
    {
        public DateTime LastVisited { get; set; }
        public DateTime YesterDay { get; set; }
        public List<Website> Websites { get; set; } = new List<Website>();
        public WebSystem system = new WebSystem();


        public Logic()
        {
            YesterDay = DateTime.Today.AddDays(-1);
            LastVisited = system.LastVisited;
        }   

        private MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

        public T GetOrCreate(object key, Func<T> createItem)
        {
            T chacheEntry;
            if (!_cache.TryGetValue(key, out chacheEntry))
            {
                chacheEntry = createItem();

                _cache.Set(key, chacheEntry);
            }
            return chacheEntry;
        }
        public List<Website> GetPopolurSites()
        {
            
            using (var db = new ApplicationContext())
            {
                if (!db.Systems.Any())
                {
                    system.LastVisited = DateTime.Today;
                    db.Systems.Add(system);
                    db.SaveChanges();
                }
                else
                {
                    db.Systems.Select(s => s).ToList().ForEach(s => db.Remove(s));
                    db.SaveChanges();
                    system.LastVisited = DateTime.Today;
                    db.Systems.Add(system);
                    db.SaveChanges();
                }
                LastVisited = db.Systems.Select(c => c.LastVisited).FirstOrDefault();
            }
            if (LastVisited < YesterDay.AddDays(1))
            {
                LastVisited = DateTime.Today;
                using (var db = new ApplicationContext())
                {
                    return Websites = db.Websites.Select(website => website).OrderByDescending(w => w.NumberOfEnters).Take(100).ToList();
                }
            }
            return Websites;

        }
       
    }
}
