import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { SideNavModel, Team, Article } from './sidenav';

@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.css'],
  providers: [DataService]
})
export class SideNavComponent implements OnInit {

  sidenavs: SideNavModel[];
  teams: Team[];
  tableMode: boolean = true;          // табличный режим
  articles: Article[];

  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.loadSideNavs();
  }
  // получаем данные через сервис
  loadSideNavs() {
    this.dataService.getSideNavs()
      .subscribe((data: SideNavModel[]) => this.sidenavs = data);
  }

  loadTeams(id?: number) {
    this.dataService.getTeams(id)
      .subscribe((data: Team[]) => this.teams = data);
  }

  loadArticles(id?: number) {
    this.dataService.getArticles(id)
      .subscribe((data: Article[]) => this.articles = data);
  }


  onMouseOver(event) {
    var target = event.target || event.srcElement || event.currentTarget;
    var idAttr = target.attributes.id;
    var value = idAttr.nodeValue;
    this.loadTeams(value);                               
  }

  onMouseOverOnTeam(event) {
    var target = event.target || event.srcElement || event.currentTarget;
    var idAttr = target.attributes.id;
    var value = idAttr.nodeValue;
    this.loadArticles(value);
  }
}


