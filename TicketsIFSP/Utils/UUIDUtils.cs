namespace TicketsIFSP.Utils
{
    public static class UUIDUtils
    {

        public static string GenerateUUID()
        {
            return Guid.NewGuid().ToString();
        }

        public static bool IsValidUUID(string uuid)
        {
            return Guid.TryParse(uuid, out _);
        }


    }
}
