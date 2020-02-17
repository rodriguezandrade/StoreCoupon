import { Resource } from './resource';
import { Actions } from 'src/app/utils/guards/enums/actions';

export interface Serializer {
    fromJson(json: any): Resource;
    toJson(resource: Resource, action:Actions): any;
  }