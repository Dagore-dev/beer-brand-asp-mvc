using System;
using System.Collections.Generic;

namespace ASPModelViewController.Models
{
    public partial class Beer
    {
        public long BeerId { get; set; }
        public string Name { get; set; } = null!;
        public long? BrandId { get; set; }

        public virtual Brand? Brand { get; set; }
    }
}
