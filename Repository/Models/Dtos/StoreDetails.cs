using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models.Dtos
{
    public class StoreDetails : StoreDto
    {
        public string Owner { get; set; }
        public string SubCategorName { get; set; }
    }
}
