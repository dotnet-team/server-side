import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Video } from './video';
import { ActivatedRoute, Route } from '@angular/router';

@Component({
  selector: 'app-video',
  templateUrl: './video.component.html',
  providers: [DataService]
})

export class VideoComponent implements OnInit {

  tableMode = true;
  videos: Video[] = new Array();
  video: Video;
  Id: any;

  constructor(private dataService: DataService, private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.Id = this.route.snapshot.paramMap.get('Id');
    this.loadVideo(this.Id);
  }

  loadVideo(id?: number) {
    this.dataService.getVideo(id)
      .subscribe((data: Video) => this.video = data);
  }

}


