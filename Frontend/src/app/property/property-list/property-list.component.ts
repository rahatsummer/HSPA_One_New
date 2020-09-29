import { Component, OnInit } from '@angular/core';
import { HousingService } from 'src/app/services/housing.service';

import { ActivatedRoute } from '@angular/router';
import { IProperty } from 'src/app/model/iproperty';
import { IPropertyBase } from 'src/app/model/ipropertybase';


@Component({
  selector: 'app-property-list',
  templateUrl: './property-list.component.html',
  styleUrls: ['./property-list.component.css']
})
export class PropertyListComponent implements OnInit {

  SellRent = 1;

  properties: IPropertyBase[];

  Today = new Date();
  City = '';
  SearchCity = '';
  SortbyParam = '';
  SortDirection= 'asc';


  constructor(private route: ActivatedRoute, private housingService: HousingService) { }

  ngOnInit(): void {
    if (this.route.snapshot.url.toString()){
      this.SellRent = 2; // we are on rent property url else we are on buy url
    }
    this.housingService.getAllProperties(this.SellRent).subscribe(
      data => {
      this.properties = data;
      console.log(data);
    }, error => {
      console.log('httperror:');
      console.log(error);
    }
  );



    // this.http.get('data/properties.json').subscribe (
    //   data => {
    //     this.properties =data;
    //     console.log(data);
    //   }
    // );
  }

  onCityFilter(){
    this.SearchCity = this.City;

  }

  onCityFilterClear(){
    this.SearchCity = '';
    this.City = '';
  }

  onSortDirection(){
    if(this.SortDirection === 'desc'){
      this.SortDirection = 'asc';
    }
    else {
      this.SortDirection = 'desc';
    }

  }


}
