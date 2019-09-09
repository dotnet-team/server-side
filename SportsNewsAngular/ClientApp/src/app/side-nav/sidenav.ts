import { Data } from "@angular/router";

export class SideNav {
  constructor(
    public id?: number,
    public name?: string,
    public isShow?: boolean) { }
}

export class Team {
  constructor(
    public id?: number,
    public name?: string,
    public isShow?: boolean,
    public sideNavId?: number) { }
}

export class Article {
  constructor(
    public id?: number,
    public name?: string,
    public teamId?: number,
    public country?: string,
    public title?: string,
    public text?: string,
    public date?: Data,
    public udserId?: string) {}
}
