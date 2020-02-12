import { Resource } from './utils/resource';

export class Owner extends Resource{
  firstname:string;
  lastname:string;
  fiscalName:string;
  address:string;
  telephone:number;
  email:string;
  rfc:string;
  subCategory:string;
}