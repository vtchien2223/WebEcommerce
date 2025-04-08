namespace DoAnCoSoWeb.Models
{
    public class Tinhtrangcomment
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<Comment>? Comments { get; set; }
    }
}
