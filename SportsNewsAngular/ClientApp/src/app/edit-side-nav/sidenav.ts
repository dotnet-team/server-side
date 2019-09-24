export class SideNav {
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

