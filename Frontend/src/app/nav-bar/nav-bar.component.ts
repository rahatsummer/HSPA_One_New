import { Component, OnInit } from '@angular/core';
import { AlertifyService } from '../services/alertify.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  loggineUser: string;

  constructor(private alertify : AlertifyService) { }

  ngOnInit() {
  }

  loggedin(){
    this.loggineUser = localStorage.getItem('token');
    return this.loggineUser;
  }

  onLogout(){
    localStorage.removeItem('token');
    this.alertify.success('you are logged out!');
  }

}
