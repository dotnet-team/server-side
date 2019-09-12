import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable()
export class DataService {

  private url = '/Articles/getshowed';
  private getArticleurl = '/Articles/getbyid';

  constructor(private http: HttpClient) {
  }

  getSideNavArticles(sideNavId: number) {
     return this.http.get(this.url + '?sideNavId=' + sideNavId);
  }

  getTeamArticles(teamId: number) {
    return this.http.get(this.url + '?teamId=' + teamId);
  }

  getArticle(id?: number) {
    return this.http.get(this.getArticleurl + '?id=' + id);
  }

}
