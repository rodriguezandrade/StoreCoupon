import { Subject, Subscription } from 'rxjs';
import { Injectable, EventEmitter } from '@angular/core';

@Injectable()
export class HelperService {
    public popup: Subject<any> = new Subject<any>();
    invokeFirstComponentFunction = new EventEmitter();
    subsVar: Subscription;
    constructor() { }

    private modals: any[] = [];

    add(modal: any) {
        this.modals.push(modal);
    }

    remove(id: string) {
        this.modals = this.modals.filter(x => x.id !== id);
    }

    open(id: string) {
        let modal: any = this.modals.filter(x => x.id === id)[0];
        modal.open();
    }

    close(id: string) {
        let modal: any = this.modals.filter(x => x.id === id)[0];
        modal.close();
    }

}