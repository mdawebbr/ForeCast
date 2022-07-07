import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})

export class GenericService<T> {
    apiUrl: string;
    constructor(protected http: HttpClient, @Inject("apiUrl") protected _apiUrl: any) {
        this.apiUrl = _apiUrl;
    }

    GetAll() : Observable<T> {
        return this.http.get<T>(this.apiUrl);
    }

    Post(obj) : Observable<T> {
        return this.http.post<T>(this.apiUrl, obj);
    }

    GetAllCustom(url: string) : Observable<T> {
        return this.http.get<T>(url);
    }
}