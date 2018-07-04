import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Snack } from '../../snack';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'})
};

@Injectable({
  providedIn: 'root'
})

export class CurdSnackService {
  apiUrl: string;

  constructor(private http: HttpClient) { this.apiUrl = 'http://localhost:58055/api/'; }

  getCurdSnacks(){
    return this.http.get<Snack[]>(this.apiUrl + 'CurdSnacks', httpOptions);
  };

  postCurdSnacks(data: Snack){
    return this.http.post(this.apiUrl + 'CurdSnacks', data, httpOptions);
  }

  putCurdSnacks(data: Snack[]){
    return this.http.put(this.apiUrl + 'CurdSnacks', JSON.stringify(data), httpOptions);
  }
}