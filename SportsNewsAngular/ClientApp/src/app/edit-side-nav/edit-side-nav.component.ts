import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { SideNav} from './sidenav';


@Component({
  selector: 'app-edit-side-nav',
  templateUrl: './edit-side-nav.component.html',
  providers: [DataService]
})
export class EditSideNavComponent implements OnInit {

  tableMode: boolean = true;         
  sideNav: SideNav = new SideNav();
  sideNavs: SideNav[];

  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.loadSideNav();
  }

  loadSideNav() {
    this.dataService.getSideNav()
      .subscribe((data: SideNav[]) => this.sideNavs = data);
  }

  save() {
    if (this.sideNav.Id == null) {
      this.dataService.createSideNav(this.sideNav)
        .subscribe((data: SideNav) => this.sideNavs.push(data));
    } else {
      this.dataService.updateSideNav(this.sideNav)
        .subscribe(data => this.loadSideNav());
    }
    this.cancel();
  }
  editSideNav(s: SideNav) {
    this.sideNav = s;
  }
  cancel() {
    this.sideNav = new SideNav();
    this.tableMode = true;
  }
  delete(s: SideNav) {
    this.dataService.deleteSideNav(s.Id)
      .subscribe(data => this.loadSideNav());
  }
  add() {
    this.cancel();
    this.tableMode = false;
  }
}


