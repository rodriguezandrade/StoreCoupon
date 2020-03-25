
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
    let model = {
      name: subCategory.name,
      description: subCategory.description,
      idSubCat: subCategory.idSubCat
    }
    if (accion == Actions.New) {
      return model
    }else if(accion == Actions.Edit){
      let id = {id: subCategory.id};
      let modelid = {... id, ... model}
      return modelid;
    }
  }
}
