import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable()
export class DataService {

  private getArticleurl = '/Articles/getbyid';

  constructor(private http: HttpClient) {
  }


  getArticle(id?: number) {
    return this.http.get(this.getArticleurl + '?id=' + id);
  }

}
