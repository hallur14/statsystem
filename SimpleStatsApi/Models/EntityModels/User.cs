namespace SimpleStatsApi.Models.EntityModels
{
    public class User
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int isDeleted { get; set; }
        public string email { get; set; }
    
    }
}