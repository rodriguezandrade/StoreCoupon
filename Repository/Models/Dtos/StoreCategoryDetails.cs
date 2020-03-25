using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models.Dtos
{
    public class StoreCategoryDetails : StoreCategoryDto
    {
        public string Store { get; set; }
        public string Category { get; set; }
    }
}
