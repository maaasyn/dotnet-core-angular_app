import {Component, Input, OnInit, OnChanges} from '@angular/core';
import {AuthService} from '../_services/auth.service';
import {AlertifyService} from '../_services/alertify.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {

  model: any = {};
  username: any;

  constructor(public authService: AuthService,
              private alertify: AlertifyService,
              private router: Router) {
  }


  ngOnInit(): void {
  }

  login() {
    this.authService.login(this.model).subscribe(next => {
        this.alertify.success('logged in successfuly');
      },
      error => {
        this.alertify.error('Error with login');
      },
      () => {
        this.router.navigate(['/members']);
      });
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  logout() {
    localStorage.removeItem('token');
    console.log('logged out');
    this.router.navigate(['home']);
  }
}
