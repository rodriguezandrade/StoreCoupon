
import { SubCategory } from '../subcategory';
import { SubCategoryDto } from '../Dto/subCategoryDto';
import { Actions } from 'src/app/utils/enums/actions';

export class SubCategorySerializer {
  fromJson(json: any): SubCategoryDto{
    const subCategory = new SubCategoryDto();
    subCategory.id = json.id;
    subCategory.name = json.name;
    subCategory.description = json.description;
    subCategory.idSubCat = json.idSubCat;
    subCategory.categoryName = json.categoryName;
    return subCategory;
  }

  toJson(subCategory: SubCategory, accion:Actions): any {
    if (accion == Actions.New) {
      return {
        name: subCategory.name,
        description: subCategory.description,
        idSubCat: subCategory.idSubCat,
      };
    }else if(accion == Actions.Edit){
      return {
        id: subCategory.id,
        name: subCategory.name,
        description: subCategory.description,
        idSubCat: subCategory.idSubCat
      };
    }
  }
}
