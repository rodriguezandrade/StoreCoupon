import { Resource } from './utils/resource';

export class Store extends Resource {
    name : string;
    fiscalName : string;
    address : string;
    telephone : number;
    email : string;
    rfc : string;
    subCategoryId : string;
    subCategory : string;
}