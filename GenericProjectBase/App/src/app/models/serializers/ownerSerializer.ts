import { Owner } from "../owner";
import { Actions } from 'src/app/utils/enums/actions';

export class OwnerSerializer {
  
  fromJson(json: any): Owner {
    const owner = new Owner();
    owner.id = json.id;
    owner.firstName = json.firstName;
    owner.lastName = json.lastName;
    owner.address = json.address;
    owner.email = json.email;
    owner.telephone = json.telephone;
    owner.rfc = json.rfc;
    // owner.cookedOn = moment(json.cookedOn, 'mm-dd-yyyy hh:mm');

    return owner;
  }

  toJson(owner: Owner, accion:Actions): any {
    if (accion == Actions.New) {
      return {
        firstName : owner.firstName,
        lastName : owner.lastName,
        address : owner.address,
        email : owner.email,
        telephone : +owner.telephone,
        rfc : owner.rfc
      };
    }else if(accion == Actions.Edit){
      
      return {
        id : owner.id,
        firstName : owner.firstName,
        lastName : owner.lastName,
        address : owner.address,
        email : owner.email,
        telephone : +owner.telephone,
        rfc : owner.rfc
      };
    }
    
  }
}
