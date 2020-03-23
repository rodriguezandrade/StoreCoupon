using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models.Dtos
{
    public class Store_CategoryDetails : Store_CategoryDto
    {
        public string Store { get; set; }
        public string Category { get; set; }
    }
}
