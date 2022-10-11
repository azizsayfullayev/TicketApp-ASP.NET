﻿namespace TicketApp.WebApi.Commons.Helpers
{
    public class ImageHelper
    {
        public static string MakeImageName(string filename)
        {
            string guid = Guid.NewGuid().ToString();
            return "IMG_" + guid + filename;
        }
    }
}