﻿using RestWithASPNET5.Model.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNET5.Model
{
    [Table("books")]
    public class Book : BaseEntity
    {
        [Column("author")]
        public string Autor { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("price")]
        public decimal Price { get; set; }
        [Column("launch_date")]
        public DateTime LaunchDate { get; set; }
    }
}
