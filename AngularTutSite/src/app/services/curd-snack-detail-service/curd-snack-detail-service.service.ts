import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { SnackDetail } from '../../snack-detail';
import { Observable } from 'rxjs';

const httpOptions = {
  observe: 'response'
};

@Injectable({
  providedIn: 'root'
})
export class CurdSnackDetailServiceService {
  apiUrl: string;

  constructor(private http: HttpClient) { this.apiUrl = 'http://localhost:58055/api/'; }

  getCurdSnackDetails(): Observable<HttpResponse<SnackDetail[]>>{
    return this.http.get<SnackDetail[]>(this.apiUrl + 'CurdSnackDetail', {observe: 'response'});
  };

  getCurdSnackDetail(data): Observable<HttpResponse<SnackDetail>>{
    return this.http.get<SnackDetail>(this.apiUrl + 'CurdSnackDetail/' + data, {observe: 'response'});
  };

  postCurdSnackDetail(id: number, data: SnackDetail){
    return this.http.post(this.apiUrl + 'CurdSnackDetail/' + id, data);
  }

  putCurdSnackDetail(id: number, data: SnackDetail){
    return this.http.put(this.apiUrl + 'CurdSnackDetail/' + id, data);
  }
}
