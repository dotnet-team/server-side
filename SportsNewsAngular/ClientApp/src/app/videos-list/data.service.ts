import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable()
export class DataService {

  private url = '/Videos/getshowed';

  constructor(private http: HttpClient) {
  }

  getSideNavVideos() {
    return this.http.get(this.url);
  }


}
