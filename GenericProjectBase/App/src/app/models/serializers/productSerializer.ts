import { Product } from "../product";
import { Actions } from 'src/app/utils/guards/enums/actions';
    
    export class ProductSerializer {
      fromJson(json: any): Product {
        const product = new Product();
        product.id = json.id;
        product.name = json.name;
        product.description = json.description;
        product.price = json.price;
        return product;
      }
    
      toJson(product: Product, accion:Actions): any {
        
          if (accion == Actions.New) {
            return {
              name : product.name,
              description : product.description,
              price : product.price,
            };
          }else if(accion == Actions.Edit){
            return {
              id : product.id,
              name : product.name,
              description : product.description,
              price : product.price,
            };
          }
      }
    }