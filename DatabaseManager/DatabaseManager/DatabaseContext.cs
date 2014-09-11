using DatabaseManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DatabaseManager
{
    class DatabaseContext : DbContext
    {
        public DbSet<PhotoModel> AspNetPhotos { get; set; }
        public DbSet<PresentationModel> AspNetPresentations { get; set; }

        private DatabaseContext() : base("DefaultConnection")
        {

        }

        public static DatabaseContext Create()
        {
            return new DatabaseContext();
        }

        public String GetPathPhoto(String photoId)
        {
            return AspNetPhotos.Where(p => p.PhotoId == photoId).FirstOrDefault().PhotoPath;
        }

        public void AddPhoto(PhotoModel model)
        {
            AspNetPhotos.Add(model);
            SaveChanges();
        }

        public List<PhotoModel> GetAllPhotosUser(String userId)
        {
            return AspNetPhotos.Where(p => p.UserId == userId).ToList();
        }

        public List<PhotoModel> GetPhotosUserNotPresentation(String userId)
        {
            return AspNetPhotos.Where(p => (p.UserId == userId && p.PresentationId == null)).ToList();
        }

        #region Function to get all presentation
        public List<PresentationExModel> GetAllPresentation()
        {
            return GetAllPresentationComplette(GetAllHeaderPresentation());
        }

        private List<PresentationExModel> GetAllPresentationComplette(List<PresentationModel> presentations)
        {
            var presentationsList = new List<PresentationExModel>();
            foreach (var a in presentations)
            {
                presentationsList.Add(new PresentationExModel()
                {
                    PresentationId = a.PresentationId,
                    UserId = a.UserId,
                    Photos = AspNetPhotos.Where(p => p.PresentationId == a.PresentationId).OrderBy(p => p.PositionNumber).ToList(),
                    PathBeginPhoto = a.PathBeginPhoto
                });
            }

            return presentationsList;
        }

        private List<PresentationModel> GetAllHeaderPresentation()
        {
            var presentations = AspNetPresentations.Where(p => p.PresentationId != null).ToList();

            //var presentations = AspNetPresentations.Select(p => new PresentationModel()
            //{
            //    PresentationId = p.PresentationId,
            //    UserId = p.UserId,
            //    PathBeginPhoto = p.PathBeginPhoto
            //}).ToList();

            return presentations != null ? presentations : null;
        }
        #endregion

        #region Function to add presentation
        public void AddPresentation(PresentationExModel model)
        {
            ConnectionPhotos(model);

            AspNetPresentations.Add(new PresentationModel() { 
                PresentationId = model.PresentationId,
                UserId = model.UserId,
                PathBeginPhoto = model.PathBeginPhoto
            });
            SaveChanges();
        }

        private void ConnectionPhotos(PresentationExModel model)
        {
            foreach (var a in model.Photos)
            {
                var photo = AspNetPhotos.Where(p => p.PhotoId == a.PhotoId).FirstOrDefault();
                if (photo != null)
                {
                    photo.PresentationId = a.PresentationId;
                    photo.PositionNumber = a.PositionNumber;
                }
            }
        }
        #endregion
    }
}
