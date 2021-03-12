using System.Collections;
using System;
using System.IO;
using System.Text.Json;
using DAL;
using DAL.Entities;
using System.Linq;
using System.Collections.Generic;

namespace Services
{
    public class ImportDataService : IImportDataService
    {
        private readonly IDataContext context; 

        public ImportDataService(IDataContext context)
        {
            this.context = context;
        }

        public void ImportDataInDb() {
            using (StreamReader r = new StreamReader(@"gameofthrone.json")) {
                var json = r.ReadToEnd();
                GameOfThrone gameOfThrone = JsonSerializer.Deserialize<GameOfThrone>(json);
                context.GameOfThrones.Add(gameOfThrone);
                context.SaveChanges();
                Console.Write(gameOfThrone);
            }
        }

        public ICollection<string> GetNameOfEpisode(int seasonNumber) {
            var result = context.Episodes.Where(e => e.season == seasonNumber).Select(e => e.name).ToList();
            return result;            
        }
    }
}