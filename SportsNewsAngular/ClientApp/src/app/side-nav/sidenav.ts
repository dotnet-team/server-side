import { Data } from "@angular/router";

export class SideNavModel {
  constructor(
    public Id?: number,
    public Mame?: string,
    public IsShow?: boolean) { }
}

export class Team {
  constructor(
    public Id?: number,
    public Name?: string,
    public IsShow?: boolean,
    public SideNavId?: number) { }
}

export class Article {
  constructor(
    public Id?: number,
    public ImageUrl?: string,
    public Name?: string,
    public TeamId?: number,
    public Country?: string,
    public Title?: string,
    public Text?: string,
    public Date?: Data,
    public IsShow?: boolean,
    public UserId?: string) {}
}

export class Video {
  constructor(
    public Id?: number,
    public IsShow?: boolean,
    public VideoUrl?: string
  ) { }
}
