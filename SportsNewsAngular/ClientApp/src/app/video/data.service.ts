import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable()
export class DataService {

  private getVideoeurl = '/Videos/getbyid';

  constructor(private http: HttpClient) {
  }


  getVideo(id?: number) {
    return this.http.get(this.getVideoeurl + "?Id=" + id);
  }

}
