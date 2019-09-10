import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SideNav } from './sidenav'

@Injectable()
export class DataService {

  private updateSideNavurl = "/SideNavs/Update";
  private getallSideNavurl = "/SideNavs/getall";
  private createSideNavurl = "/SideNavs/Create";
  private deleteSideNavurl = "/SideNavs/Delete";


  constructor(private http: HttpClient) {
  }


  updateSideNav(sideNav: SideNav) {
    return this.http.put(this.updateSideNavurl + '/' + sideNav.Id, sideNav);
  }

  getSideNav() {
    return this.http.get(this.getallSideNavurl);
  }

  createSideNav(sideNav: SideNav) {
    return this.http.post(this.createSideNavurl, sideNav);
  }

  deleteSideNav(id: number) {
    return this.http.delete(this.deleteSideNavurl + '/' + id);
  }
}
