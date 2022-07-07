import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class ApiConfig {
    constructor(private http: HttpClient) { }
    // //DEV
    // apiUrl = "http://localhost:51600"
    // rootUrl = 'http://localhost:4200'
    // ambiente = "DESENVOLVIMENTO"
    // timeSession = 900000;

    apiUrl = "http://localhost:51600"
    rootUrl = 'http://localhost:4200'
    ambiente = "DESENVOLVIMENTO"
    timeSession = 900000;
}
