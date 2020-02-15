using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models.Dtos
{
   public class SubCategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public ICollection<CategoryDto> Categories { get; set; }

    }
}
