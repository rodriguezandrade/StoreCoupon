import { Owner } from "../owner";
import { Store } from '../store';

export class StoreSerializer {
  
  fromJson(json: any): Store {
    const store = new Store();
    store.id = json.id;
    store.name = json.name;
    store.fiscalName = json.fiscalName;
    store.address = json.address;
    store.telephone = json.telephone;
    store.email = json.email;
    store.rfc = json.rfc;
    store.subCategoryId = json.subCategoryId;
    // store.cookedOn = moment(json.cookedOn, 'mm-dd-yyyy hh:mm');

    return store;
  }

  toJson(store: Store, accion:string): any {
    if (accion == "new") {
      return {
        name : store.name,
        fiscalName : store.fiscalName,
        address : store.address,
        telephone : +store.telephone,
        email : store.email,
        rfc : store.rfc,
        subCategoryId : store.subCategoryId
      };
    }else if(accion == "edit"){
      
      return {
        id : store.id,
        name : store.name,
        fiscalName : store.fiscalName,
        address : store.address,
        telephone : +store.telephone,
        email : store.email,
        rfc : store.rfc,
        subCategoryId : store.subCategoryId
      };
    }
    
  }
}
