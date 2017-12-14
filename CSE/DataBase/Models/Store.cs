using System.ComponentModel.DataAnnotations;

namespace DataBase.Models
{
    public class Store
    {
        [Key]
        public short Id { get; set; }
        public string Name { get; set; }
    }
}
