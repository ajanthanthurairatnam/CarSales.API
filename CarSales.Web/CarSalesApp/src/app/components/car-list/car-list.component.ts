import { Component, OnInit } from '@angular/core';
import { DataService } from '../../services/data.service';

@Component({
  selector: 'app-car-list',
  templateUrl: './car-list.component.html',
  styleUrls: ['./car-list.component.css']
})
export class CarListComponent implements OnInit {
  AdvertisementPageCount:number;
  
  constructor(public dataService:DataService)
  {
      this.dataService.getPageSettings().subscribe(PageSettings => {
          //console.log(users);
        //  console.log(AdvertisementPageCounts);
          this.AdvertisementPageCount = PageSettings.AdvertisementPageCount;  
          console.log(this.AdvertisementPageCount);      
      });
  }
  
  counter(i: number) {
    return new Array(i);
  }

  ngOnInit() {
  }

}
