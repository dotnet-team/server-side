import { Data } from "@angular/router";

export class Article {
  constructor(
    public id?: number,
    public name?: string,
    public teamId?: number,
    public country?: string,
    public title?: string,
    public text?: string,
    public date?: Data,
    public udserId?: string) { }
}
