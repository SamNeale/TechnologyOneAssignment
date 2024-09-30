import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AnswerDTO } from '../models/answer-dto';

@Injectable({
  providedIn: 'root'
})
export class NumberService {

  constructor(private http: HttpClient) {}

  getStringFromNumber(number: number): Observable<AnswerDTO>{

    console.log(number)

    const params = new HttpParams().set('number', number);
    
    const httpOptions = {
      params: params
    };

    return this.http.get<AnswerDTO>('https://localhost:7115/api/number', httpOptions);
  }
}
