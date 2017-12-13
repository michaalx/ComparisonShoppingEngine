﻿using System.ComponentModel.DataAnnotations;

namespace DataBase.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
