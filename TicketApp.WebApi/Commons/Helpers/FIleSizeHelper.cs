namespace TicketApp.WebApi.Commons.Helpers
{
    public class FIleSizeHelper
    {
        public static double ByteToMb(double @byte)
        {
            return @byte / 1024 / 1024;
        }
    }
}
