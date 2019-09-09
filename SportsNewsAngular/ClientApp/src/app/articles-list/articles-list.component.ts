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
  id: number;
  sub: any;

  constructor(private dataService: DataService, private route: ActivatedRoute) { }



  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.id = params['id'];
    });
    this.loadArticles(this.id);
  }
  // получаем данные через сервис
  loadArticles(id?: number) {
    this.dataService.getArticles(id)
      .subscribe((data: Article[]) => this.articles = data);
  }

}


