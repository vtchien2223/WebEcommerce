namespace DoAnCoSoWeb.Models
{
    public class Rank
    {
        public int Id { get; set; }
        public string TenRank { get; set; }
        public List<Account>? Accounts { get; set; }
    }
}
