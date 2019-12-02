using System.Collections.Generic;

namespace CoreAutomotive.Models
{
    public interface IPictureRepository
    {
        List<Picture> GetAllPictures();
        List<Picture> GetPicturesByCarId(int carId);
        public void AddPicture(Picture picture);
        public void AddPictures(List<Picture> pictures);

    }
}
