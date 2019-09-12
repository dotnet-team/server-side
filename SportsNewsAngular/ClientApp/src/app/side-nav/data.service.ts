import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class DataService {

  private getallSideNavurl = "/SideNavs/getshowed";
  private getallTeamurl = "/Teams/getshowed";
  private getallArticleurl = "/Articles/getshowed";


  constructor(private http: HttpClient) {
  }

  getSideNavs() {
    return this.http.get(this.getallSideNavurl);
  }

  getTeams(id?: number) {
    if (id == null) {
      return this.http.get(this.getallTeamurl);
    }
    return this.http.get(this.getallTeamurl + '?sidenavid=' + id);
  }

  getArticles(id?: number) {
    if (id == null) {
      return this.http.get(this.getallArticleurl);
    }
    return this.http.get(this.getallArticleurl + '?teamid=' + id);

  }

}
