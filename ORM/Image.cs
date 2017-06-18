using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ORM
{
    public class Image
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        public string ImagePath { get; set; }

        public virtual Post Post { get; set; }
    }
}