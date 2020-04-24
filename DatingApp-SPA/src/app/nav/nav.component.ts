import {Component, Input, OnInit, OnChanges} from '@angular/core';
import {AuthService} from '../_services/auth.service';
import {AlertifyService} from '../_services/alertify.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {
  model: any = {};
  username: any;

  constructor(public authService: AuthService, private alertify: AlertifyService) {
  }

  //
  parseJwt() {
    const base64Url = localStorage.getItem('token').split('.')[1];
    const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    const jsonPayload = decodeURIComponent(atob(base64).split('').map((c) => {
      return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));
    return JSON.parse(jsonPayload);
  }

  ngOnInit(): void {
  }

  login() {
    this.authService.login(this.model).subscribe(next => {
        this.alertify.success('logged in successfuly'),
          this.username = this.parseJwt().unique_name;
      },
      error => {
        this.alertify.error('Error with login');
      });
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  logout() {
    localStorage.removeItem('token');
    console.log('logged out');
  }
}
