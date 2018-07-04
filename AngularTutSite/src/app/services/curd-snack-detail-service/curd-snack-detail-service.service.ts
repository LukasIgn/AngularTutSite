import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { SnackDetail } from '../../snack-detail';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'})
};

@Injectable({
  providedIn: 'root'
})
export class CurdSnackDetailServiceService {
  apiUrl: string;

  constructor(private http: HttpClient) { this.apiUrl = 'http://localhost:58055/api/'; }

  getCurdSnackDetails(){
    return this.http.get<SnackDetail[]>(this.apiUrl + 'CurdSnackDetail', httpOptions);
  };

  getCurdSnackDetail(data){
    return this.http.get<SnackDetail>(this.apiUrl + 'CurdSnackDetail?id=' + data, httpOptions);
  };

  postCurdSnackDetail(data: SnackDetail){
    return this.http.post(this.apiUrl + 'CurdSnackDetail', data, httpOptions);
  }

  putCurdSnackDetail(data: SnackDetail){
    return this.http.put(this.apiUrl + 'CurdSnacks', data, httpOptions);
  }
}
