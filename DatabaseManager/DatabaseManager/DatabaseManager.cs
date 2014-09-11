using DatabaseManager.Models;
using System;
using System.Collections.Generic;

namespace DatabaseManager
{
    public static class DatabaseContextManager
    {
        public static String GetPathPhoto(String photoId)
        {
            using (var context = DatabaseContext.Create())
            {
                return context.GetPathPhoto(photoId);
            }
        }

        public static void AddPhoto(PhotoModel model)
        {
            using (var context = DatabaseContext.Create())
            {
                context.AddPhoto(model);
            }
        }

        public static List<PhotoModel> GetAllPhotosUser(String userId)
        {
            using (var context = DatabaseContext.Create())
            {
                return context.GetAllPhotosUser(userId);
            }
        }

        public static List<PhotoModel> GetPhotosUserNotPresentation(String userId)
        {
            using (var context = DatabaseContext.Create())
            {
                return context.GetPhotosUserNotPresentation(userId);
            }
        }

        public static void AddPresentation(PresentationExModel model)
        {
            using (var context = DatabaseContext.Create())
            {
                context.AddPresentation(model);
            }
        }

        public static List<PresentationExModel> GetAllPresentation()
        {
            using (var context = DatabaseContext.Create())
            {
                return context.GetAllPresentation();
            }
        }
    }
}
