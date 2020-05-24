import { Owner } from "../owner";
import { Actions } from 'src/app/utils/enums/actions';

export class OwnerSerializer {
  
  fromJson(json: any): Owner {
    const owner = new Owner();
    owner.id = json.id;
    owner.firstName = json.firstName;
    owner.lastName = json.lastName;
    owner.address = json.address;
    owner.telephone = json.telephone;
    owner.rfc = json.rfc;
    owner.idUser = json.idUser;
    // owner.cookedOn = moment(json.cookedOn, 'mm-dd-yyyy hh:mm');

    return owner;
  }

  toJson(owner: Owner, accion:Actions): any {
    if (accion == Actions.New) {
      return {
        firstName : owner.firstName,
        lastName : owner.lastName,
        address : owner.address,
        telephone : +owner.telephone,
        rfc : owner.rfc,
        idUser : +owner.idUser
      };
    }else if(accion == Actions.Edit){
      
      return {
        id : owner.id,
        firstName : owner.firstName,
        lastName : owner.lastName,
        address : owner.address,
        telephone : +owner.telephone,
        rfc : owner.rfc,
        idUser : +owner.idUser
      };
    }
    
  }
}
