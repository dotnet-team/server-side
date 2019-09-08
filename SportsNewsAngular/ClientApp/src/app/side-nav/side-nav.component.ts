import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { SideNav, Team } from './sidenav';

@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.css'],
  providers: [DataService]
})
export class SideNavComponent implements OnInit {

  sidenav: SideNav = new SideNav();   // изменяемый товар
  sidenavs: SideNav[];
  team: Team = new Team();
  teams: Team[];
  tableMode: boolean = true;          // табличный режим

  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.loadSideNavs();
  }
  // получаем данные через сервис
  loadSideNavs() {
    this.dataService.getSideNavs()
      .subscribe((data: SideNav[]) => this.sidenavs = data);
  }

  loadTeams(id?: number) {
    this.dataService.getTeams(id)
      .subscribe((data: Team[]) => this.teams = data);
  }
  // сохранение данных
  save() {
    if (this.sidenav.id == null) {
      this.dataService.createSideNav(this.sidenav)
        .subscribe((data: SideNav) => this.sidenavs.push(data));
    } else {
      this.dataService.updateSideNav(this.sidenav)
        .subscribe(data => this.loadSideNavs());
    }
    this.cancel();
  }
  editProduct(p: SideNav) {
    this.sidenav = p;
  }
  cancel() {
    this.sidenav = new SideNav();
    this.tableMode = true;
  }
  delete(p: SideNav) {
    this.dataService.deleteSideNav(p.id)
      .subscribe(data => this.loadSideNavs());
  }
  add() {
    this.cancel();
    this.tableMode = false;
  }


  onMouseOver(event) {
    var target = event.target || event.srcElement || event.currentTarget;
    var idAttr = target.attributes.id;
    var value = idAttr.nodeValue;
    this.loadTeams(value);                               
  }
}


