import { Resource } from './resource';
import { Actions } from 'src/app/enums/actions';

export interface Serializer {
    fromJson(json: any): Resource;
    toJson(resource: Resource, action:Actions): any;
  }