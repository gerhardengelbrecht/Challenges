import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { retry, catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class WebapiService {
  
  private baseUrl;
  constructor(private http: HttpClient) { 
    this.baseUrl = environment.apiUrl;
  }

  get<T>(url: string) {
    let reqHeaders = new HttpHeaders({'Content-Type': 'application/json'});
    return this.http.get<T>(this.baseUrl + url, {
      headers: reqHeaders
    })
      .pipe(
        retry(3),
        catchError(this.handleError)
      )
  }

  post<T>(url: string, dto: T) {
    let reqHeaders = new HttpHeaders({'Content-Type': 'application/json'});
    // let postheader = new HttpHeaders({ 'Content-Type': 'multipart/form-data'});
    return this.http.post<T>(this.baseUrl + url, dto, {
      headers: reqHeaders
    })
      .pipe(
        retry(3), // retry a failed request up to 3 times
        catchError(this.handleError) // then handle the error
      );
  }

  delete<T>(url: string, dto) {
    let reqHeaders = new HttpHeaders({'Content-Type': 'application/json'});
    const options = {
      headers: reqHeaders,
      body: dto
    }
    return this.http.delete<T>(this.baseUrl + url, options)
      .pipe(
        retry(3), // retry a failed request up to 3 times
        catchError(this.handleError) // then handle the error
      );
  }

  put<T>(url: string, dto: T) {
    let reqHeaders = new HttpHeaders({'Content-Type': 'application/json'});
    return this.http.put<T>(this.baseUrl + url, dto, {
      headers: reqHeaders
    })
      .pipe(
        retry(3), // retry a failed request up to 3 times
        catchError(this.handleError) // then handle the error
      );
  }

  handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    // return an observable with a user-facing error message
    return throwError(
      'Something bad happened; please try again later.');
  }
}
