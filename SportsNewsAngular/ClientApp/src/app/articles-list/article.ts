import { Data } from '@angular/router';

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
    public UserId?: string) { }
}
