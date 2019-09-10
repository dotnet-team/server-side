import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Article } from './article';
import { ActivatedRoute, Route } from '@angular/router'

@Component({
  selector: 'app-articles-list',
  templateUrl: './articles-list.component.html',
  providers: [DataService]
})
export class ArticlesListComponent implements OnInit {

  tableMode: boolean = true;          // табличный режим
  articles: Article[];
  teamId: any;
  sideNavId: any;


  constructor(private dataService: DataService, private route: ActivatedRoute) {
  }



  ngOnInit() {
    this.sideNavId = this.route.snapshot.paramMap.get('sideNavId');
    this.teamId = this.route.snapshot.paramMap.get('teamId');
    console.log(this.sideNavId);
    console.log(this.teamId);
    if (this.sideNavId != null) {
      this.loadSideNavArticles(this.sideNavId);
    }
    else if (this.teamId != null) {
      this.loadTeamArticles(this.teamId);
    } 

  }
  // получаем данные через сервис
  loadSideNavArticles(sideNavId: number) {
    this.dataService.getSideNavArticles(sideNavId)
      .subscribe((data: Article[]) => this.articles = data);
  }

  loadTeamArticles(teamId: number) {
    this.dataService.getTeamArticles(teamId)
      .subscribe((data: Article[]) => this.articles = data);
  }

}


