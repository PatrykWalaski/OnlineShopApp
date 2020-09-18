import { Component, OnInit } from '@angular/core';
import { BasketService } from './basket/basket.service';
import { AccountService } from './account/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'Skinet';
  token: string;

  constructor(
    private basketService: BasketService,
    private accountService: AccountService
  ) {}

  ngOnInit(): void {
    this.loadBasket();
    this.token = localStorage.getItem('token');
    this.loadCurrentUser();
  }

  loadCurrentUser() {
    if (this.token) {
      this.accountService.loadCurrentUser(this.token).subscribe(
        () => {
          console.log('User Loaded');
        },
        (error) => {
          console.log(error);
        }
      );
    }
    else
    {
      this.accountService.setCurrentUserToNull();
    }
  }

  loadBasket() {
    this.basketService.loadBasket();
  }
}
