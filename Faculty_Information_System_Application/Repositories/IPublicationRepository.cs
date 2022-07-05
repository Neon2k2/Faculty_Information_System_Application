using Faculty_Information_System_Application.Data;
using System.Collections.Generic;


namespace Faculty_Information_System_Application.Repositories
{
    public interface IPublicationRepository
    {
        Publication AddPublication(Publication publish);
        Publication SearchPublication(int publicationId);
        bool DeletePublication(int publicationId);
        IEnumerable<Publication> GetPublication();
        void UpdatePublication(int publicationId, Publication publish);
    }
}
