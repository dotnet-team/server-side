import { Component, OnInit, Pipe, PipeTransform} from '@angular/core';
import { DataService } from './data.service';
import { Video } from './video';
import { ActivatedRoute, Route } from '@angular/router';
import { DomSanitizer } from '@angular/platform-browser';

@Pipe({ name: 'safe' })
export class SafePipe implements PipeTransform {
  constructor(private sanitizer: DomSanitizer) { }
  transform(url) {
    return this.sanitizer.bypassSecurityTrustResourceUrl(url);
  }
}

@Component({
  selector: 'app-videos-list',
  templateUrl: './videos-list.component.html',
  styleUrls: ['./videos-list.component.css'],
  providers: [DataService]
})

export class VideosListComponent implements OnInit {

  tableMode = true;
  videos: Video[] = new Array();
  video: Video;

  constructor(private dataService: DataService, private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.loadSideNavVideos();
  }

  loadSideNavVideos() {
    this.dataService.getSideNavVideos()
      .subscribe((data: Video[]) => this.videos = data);
  }
}
