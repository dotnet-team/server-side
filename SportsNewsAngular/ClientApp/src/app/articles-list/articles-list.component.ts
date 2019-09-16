import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Article } from './article';
import { ActivatedRoute, Route } from '@angular/router';

@Component({
  selector: 'app-articles-list',
  templateUrl: './articles-list.component.html',
  styleUrls: ['./article-list.component.css'],
  providers: [DataService]
})

export class ArticlesListComponent implements OnInit {

  tableMode = true;
  articles: Article[] = new Array();
  article: Article;
  teamId: any;
  sideNavId: any;

  constructor(private dataService: DataService, private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.sideNavId = this.route.snapshot.paramMap.get('sideNavId');
    this.teamId = this.route.snapshot.paramMap.get('teamId');

    if (this.sideNavId != null) {
      this.loadSideNavArticles(this.sideNavId);
    } else if (this.teamId != null) {
      this.loadTeamArticles(this.teamId);
    } 
  }

  loadSideNavArticles(sideNavId: number) {
    this.dataService.getSideNavArticles(sideNavId)
      .subscribe((data: Article[]) => this.articles = data);
  }

  loadTeamArticles(teamId: number) {
    this.dataService.getTeamArticles(teamId)
      .subscribe((data: Article[]) => this.articles = data);
  }

  
}


