import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Team } from './team'

@Injectable()
export class DataService {

  private updateTeamurl = "/Teams/Update";
  private getallTeamurl = "/Teams/getall";
  private createTeamurl = "/Teams/Create";
  private deleteTeamurl = "/Teams/Delete";
  private getSideNavByIdurl = '/SideNavs/getbyid';
  private getallSideNavurl = "/SideNavs/getall";


  constructor(private http: HttpClient) {
  }


  updateTeam(team: Team) {
    return this.http.put(this.updateTeamurl + '/' + team.Id, team);
  }

  getTeam(id?: number) {
    return this.http.get(this.getallTeamurl + "?sideNavId=" + id);
  }

  createTeam(team: Team) {
    return this.http.post(this.createTeamurl, team);
  }

  deleteTeam(id: number) {
    return this.http.delete(this.deleteTeamurl + '/' + id);
  }

  getSideNav(id?: number) {
    return this.http.get(this.getSideNavByIdurl + '?id=' + id);
  }

  getSideNavs() {
    return this.http.get(this.getallSideNavurl);
  }
}
