using System.Collections.Generic;
using System.Linq;

namespace CoreAutomotive.Models
{
    public class PictureRepository : IPictureRepository
    {
        private readonly AppDbContext _appDbContext;

        public PictureRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Picture> GetAllPictures()
        {
            return _appDbContext.Pictures.ToList();
        }

        public List<Picture> GetPicturesByCarId(int carId)
        {
            return _appDbContext.Pictures.Where(p => p.CarId == carId).ToList();
        }

        public void AddPicture(Picture picture)
        {
            _appDbContext.Pictures.Add(picture);
            _appDbContext.SaveChanges();
        }
    }
}
