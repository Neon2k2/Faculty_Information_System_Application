using Faculty_Information_System_Application.Data;
using System.Collections.Generic;
using System.Linq;

namespace Faculty_Information_System_Application.Repositories
{
    public class PublicationRepository : IPublicationRepository
    {
        private FacultyInformationSystemContext _db;
        public PublicationRepository(FacultyInformationSystemContext context)
        {
            this._db = context;

        }
        public Publication AddPublication(Publication publish)
        {
            _db.Publications.Add(publish);
            _db.SaveChanges();

            return publish;
        }

        public bool DeletePublication(int publicationId)
        {
            var publish = _db.Publications.FirstOrDefault(e => e.PublicationId == publicationId);
            if (publish != null)
            {
                _db.Publications.Remove(publish);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Publication> GetPublication()
        {
            var publishList = _db.Publications;
            return publishList;
        }

        public Publication SearchPublication(int publicationId)
        {
            var publish = _db.Publications.FirstOrDefault(e => e.PublicationId == publicationId);
            if (publish != null)
            {
                return publish;
            }
            else
            {
                return null;
            }
        }

        public void UpdatePublication(int publicationId, Publication publish)
        {
            var newPublish = _db.Publications.FirstOrDefault(e => e.PublicationId == publicationId);
            if (newPublish != null)
            {
                newPublish.Faculty = publish.Faculty;
                newPublish.PublicationTitle = publish.PublicationTitle;
                newPublish.ArticleName = publish.ArticleName;
                newPublish.PublisherName = publish.PublisherName;
                newPublish.CitationDate = publish.CitationDate;
                _db.SaveChanges();
            }
            
        }
    }
}
