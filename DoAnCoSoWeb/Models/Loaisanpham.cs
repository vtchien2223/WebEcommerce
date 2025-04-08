using System.ComponentModel.DataAnnotations;

namespace DoAnCoSoWeb.Models
{
    public class Loaisanpham
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Sanpham>? sanphams { get; set; }
    }
}
