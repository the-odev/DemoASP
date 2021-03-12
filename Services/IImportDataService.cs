using System.Collections.Generic;

namespace Services
{
    public interface IImportDataService
    {
        void ImportDataInDb();

        ICollection<string> GetNameOfEpisode(int seasonNumber);
    }
}