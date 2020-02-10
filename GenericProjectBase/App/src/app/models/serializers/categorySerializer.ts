import { Category } from "../category";

export class CategorySerializer {
  fromJson(json: any): Category {
    const category = new Category();
    category.id = json.id;
    category.name = json.name;
    // category.cookedOn = moment(json.cookedOn, 'mm-dd-yyyy hh:mm');

    return category;
  }

  toJson(category: Category): any {
    return {
      id: category.id,
      name: category.name
    };
  }
}
