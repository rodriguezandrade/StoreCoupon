import { Category } from "../category";
import { Actions } from 'src/app/utils/guards/enums/actions';

export class CategorySerializer {
  fromJson(json: any): Category {
    const category = new Category();
    category.id = json.id;
    category.name = json.name;
    // category.cookedOn = moment(json.cookedOn, 'mm-dd-yyyy hh:mm');

    return category;
  }

  toJson(category: Category, accion:Actions): any {
    
      if (accion == Actions.New) {
        return {
          name : category.name
        };
      }else if(accion == Actions.Edit){
        return {
          id : category.id,
          name : category.name
        };
      }
  }
}

