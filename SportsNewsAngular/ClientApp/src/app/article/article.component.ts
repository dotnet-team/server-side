import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Article } from './article';
import { ActivatedRoute, Route } from '@angular/router';

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.css'],
  providers: [DataService]
})

export class ArticleComponent implements OnInit {

  tableMode = true;
  articles: Article[] = new Array();
  article: Article;
  articleId: any;

  constructor(private dataService: DataService, private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.articleId = this.route.snapshot.paramMap.get('articleId');

      this.loadArticle(this.articleId);
  }
  
  loadArticle(id?: number) {
    this.dataService.getArticle(id)
      .subscribe((data: Article) => this.article = data);
  }

}


