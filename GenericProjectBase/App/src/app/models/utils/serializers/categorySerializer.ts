import { Category } from '../../category';

export class CategorySerializer {
  fromJson(json: any): Category {
    const category = new Category();
    category.id = json.id;
    category. = json.name;
    // pizza.cookedOn = moment(json.cookedOn, 'mm-dd-yyyy hh:mm');

    return pizza;
  }

  toJson(pizza: Pizza): any {
    return {
      id: pizza.id,
      name: pizza.name
    };
  }
}