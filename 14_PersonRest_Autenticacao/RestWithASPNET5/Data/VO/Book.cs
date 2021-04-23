using RestWithASPNET5.Model.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNET5.Data.VO
{
    public class BookVO
    {
        public long Id { get; set; }
        public string Autor { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public DateTime LaunchDate { get; set; }
    }
}
