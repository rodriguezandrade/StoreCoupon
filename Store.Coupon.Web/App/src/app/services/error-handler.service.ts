import { Injectable } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { throwError } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

@Injectable({
    providedIn: 'root'
})
export class HandleErrorService {

    constructor(private _toastr: ToastrService) { }

    handleError(err: HttpErrorResponse) {
        return throwError(err.error);
    }

    errorMessage(error: any) {
        const err = (error.ExceptionMessage) ? error.ExceptionMessage : error.Message;
        setTimeout(() => this._toastr.error(err));
    }

    errorMessageGeneral(error: any) {
        setTimeout(() => this._toastr.error(error));
    }
}
