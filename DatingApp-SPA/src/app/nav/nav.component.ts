import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  login(){
    this.authService.login(this.model).subscribe(next => {
      console.log('Logged in successfully');
    }, error => {
      console.error('Failed to login');
    });
  }

  loggedIn(){
    const token = localStorage.getItem('Token');
    return !!token;
  }

  logout(){
    localStorage.removeItem('Token');
    console.log('logged out');
  }
}
