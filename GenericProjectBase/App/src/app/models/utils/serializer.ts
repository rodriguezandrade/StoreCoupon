import { Resource } from './resource';
import { Actions } from 'src/app/utils/enums/actions';

export interface Serializer {
    fromJson(json: any): Resource;
    toJson(resource: Resource, action:Actions): any;
  }