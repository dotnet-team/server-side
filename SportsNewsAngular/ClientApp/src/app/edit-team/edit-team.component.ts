import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { SideNav, Team } from './team';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-edit-team',
  templateUrl: './edit-team.component.html',
  providers: [DataService]
})
export class EditTeamComponent implements OnInit {

  tableMode: boolean = true;         
  team: Team = new Team();
  teams: Team[];
  sideNavId: any;
  sideNav: SideNav = new SideNav();
  sideNavs: SideNav[];

  constructor(private dataService: DataService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.sideNavId = this.route.snapshot.paramMap.get('sideNavId');

    this.loadSideNavById(this.sideNavId);
    this.loadTeam(this.sideNavId);
  }

  loadTeam(id?: number) {
    this.dataService.getTeam(id)
      .subscribe((data: Team[]) => this.teams = data);
  }

  save() {
    if (this.team.Id == null) {
      this.dataService.createTeam(this.team)
        .subscribe((data: Team) => this.teams.push(data));
    } else {
      this.dataService.updateTeam(this.team)
        .subscribe(data => this.loadTeam(this.sideNavId));
    }
    this.cancel();
  }
  editSideNav(s: Team) {
    this.loadSideNavs();
    this.team = s;
  }
  cancel() {
    this.team = new Team();
    this.tableMode = true;
  }
  delete(t: Team) {
    this.dataService.deleteTeam(t.Id)
      .subscribe(data => this.loadTeam());
  }
  add() {
    this.loadSideNavs();
    this.cancel();
    this.tableMode = false;
  }

  loadSideNavById(id?: number) {
    this.dataService.getSideNav(id)
      .subscribe((data: SideNav) => this.sideNav = data);
  }

  loadSideNavs() {
    this.dataService.getSideNavs()
      .subscribe((data: SideNav[]) => this.sideNavs = data);
  }

}


