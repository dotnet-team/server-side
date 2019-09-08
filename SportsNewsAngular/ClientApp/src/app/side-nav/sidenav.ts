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
