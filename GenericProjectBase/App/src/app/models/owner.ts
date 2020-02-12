import { Resource } from './utils/resource';

export class Owner extends Resource{
  name:string;
  fiscalName:string;
  address:string;
  telephone:number;
  email:string;
  rfc:string;
  subCategory:string;
}