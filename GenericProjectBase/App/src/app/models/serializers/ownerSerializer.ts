import { Owner } from "../owner";

export class OwnerSerializer {
  fromJson(json: any): Owner {
    const owner = new Owner();
    owner.id = json.id;
    owner.name = json.name;
    owner.fiscalName = json.fiscalName;
    owner.address = json.address;
    owner.email = json.email;
    owner.telephone = json.telephone;
    owner.rfc = json.rfc;
    owner.subCategory = json.subCategory;
    // owner.cookedOn = moment(json.cookedOn, 'mm-dd-yyyy hh:mm');

    return owner;
  }

  toJson(owner: Owner): any {
    return {
      id: owner.id,
      name: owner.name,
      fiscalName : owner.fiscalName,
      address : owner.address,
      email : owner.email,
      telephone : owner.telephone,
      rfc : owner.rfc,
      subCategory : owner.subCategory
    };
  }
}
