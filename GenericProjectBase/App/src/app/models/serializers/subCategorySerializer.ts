
import { SubCategory } from '../subcategory';

export class SubCategorySerializer {
  fromJson(json: any): SubCategory {
    const subCategory = new SubCategory();
    subCategory.id = json.id;
    subCategory.name = json.name;
    subCategory.description = json.description;
    subCategory.categoryId = json.categoryId;
    subCategory.category = json.category;

    return subCategory;
  }

  toJson(subCategory: SubCategory, accion:string): any {
    if (accion == "new") {
      return {
        name: subCategory.name,
        description: subCategory.description,
        categoryId: subCategory.categoryId,
        category: subCategory.category
      };
    }else if(accion == "edit"){
      return {
        id: subCategory.id,
        name: subCategory.name,
        description: subCategory.description,
        categoryId: subCategory.categoryId,
        category: subCategory.category
      };
    }
  }
}
