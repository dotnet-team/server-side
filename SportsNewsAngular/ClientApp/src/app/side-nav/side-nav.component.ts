import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { SideNavModel, Team, Article, Video } from './sidenav';
import { ActivatedRoute, Route } from '@angular/router';


@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.css'],
  providers: [DataService]
})
export class SideNavComponent implements OnInit {

  sidenavs: SideNavModel[];
  teams: Team[];
  tableMode: boolean = true;
  articles: Article[];
  router: any;
  videos: Video[];

  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.loadSideNavs();
  }

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

  loadArticle(id?: number) {
      this.dataService.getArticles(id)
        .subscribe((data: Article[]) => this.articles = data);
  }

  loadVideos() {
    this.dataService.getVideos()
      .subscribe((data: Video[]) => this.videos = data)
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

  onMouseOverOnVideos(event) {
    this.loadVideos();
  }
}


