import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SideNav } from './sidenav';

@Injectable()
export class DataService {

  private getallurl = "/SideNavs/getall";
  private getbyidurl = "/SideNavs/getbyid";
  private cteateurl = "/SideNavs/create";
  private updateurl = "/SideNavs/update";
  private deleteurl = "/SideNavs/delete";


  constructor(private http: HttpClient) {
  }

  getSideNavs() {
    return this.http.get(this.getallurl);
  }

  getSideNav(id: number) {
    return this.http.get(this.getbyidurl + '/' + id);
  }

  createSideNav(sidenav: SideNav) {
    return this.http.post(this.cteateurl, sidenav);
  }
  updateSideNav(sidenav: SideNav) {

    return this.http.put(this.updateurl + '/' + sidenav.id, sidenav);
  }
  deleteSideNav(id: number) {
    return this.http.delete(this.deleteurl + '/' + id);
  }
}
