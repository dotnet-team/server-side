import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable()
export class DataService {

  private url = "/Articles/getall";


  constructor(private http: HttpClient) {
  }


  getArticles(id?: number) {
    if (id == null) {
      return this.http.get(this.url);
    }
    return this.http.get(this.url + '?sideNavId=' + id);

  }

}
