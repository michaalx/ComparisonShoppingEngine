using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Models
{
    public class Record
    {
        [Key]
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [ForeignKey("Store")]
        public short StoreId { get; set; }
        public Store Store { get; set; }
    }
}
