using System;

namespace Repository.Models.Dtos
{
    public class StoreCategoryDto
    {
        public Guid Id { get; set; }
        public Guid IdStore { get; set; }
        public Guid IdCategoryStore { get; set; }
    }
}
