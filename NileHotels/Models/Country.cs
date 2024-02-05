﻿using static Azure.Core.HttpHeader;
using NileHotels.Resources;
using System.ComponentModel.DataAnnotations;

namespace NileHotels.Models
{
    public class Country
    {
        [Display(Name = "ID", ResourceType = typeof(Resource))]
        public int Id { get; set; }


        [Display(Name = "NameAr", ResourceType = typeof(Resource))]
        public string NameAr { get; set; }


        [Display(Name = "NameEn", ResourceType = typeof(Resource))]
        public string NameEn { get; set; }
        public int ParentId { get; set; }

        public string InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual ICollection<Vendor> Vendor { get; set; }
        public virtual ICollection<Hotel> Hotel { get; set; }


    }
}
