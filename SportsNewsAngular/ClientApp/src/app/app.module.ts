import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { SideNavComponent } from './side-nav/side-nav.component';
import { ArticlesListComponent } from './articles-list/articles-list.component';
import { EditSideNavComponent } from './edit-side-nav/edit-side-nav.component';
import { ArticleComponent } from './article/article.component';
import { EditTeamComponent } from './edit-team/edit-team.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    CounterComponent,
    FetchDataComponent,
    SideNavComponent,
    ArticlesListComponent,
    EditSideNavComponent,
    ArticleComponent,
    EditTeamComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', component: ArticlesListComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
      { path: 'articles/sidenav/:sideNavId', component: ArticlesListComponent, canActivate: [AuthorizeGuard] },
      { path: 'articles/team/:teamId', component: ArticlesListComponent, canActivate: [AuthorizeGuard] },
      { path: 'article/:articleId', component: ArticleComponent, canActivate: [AuthorizeGuard] },
      { path: 'edit/sidenav', component: EditSideNavComponent, canActivate: [AuthorizeGuard] },
      { path: 'edit/team/:sideNavId', component: EditTeamComponent, canActivate: [AuthorizeGuard] },
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
