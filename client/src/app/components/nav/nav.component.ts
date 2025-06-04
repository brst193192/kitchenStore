import { Component, Inject, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterLink } from '@angular/router';
import { UserService } from '../../services/user.service';
import { User } from '../../interfaces/user';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.less'
})
export class NavComponent {
  private rl: RouterLink = Inject(RouterLink);
  #userS: UserService = inject(UserService);
  noUser = "אין משתמש ממחובר";
  userName: string = this.noUser;
  r:Router=inject(Router);

  //עדכון שם המשתמש הנוכחי
  ngOnInit() {
    this.#userS.currentUser.subscribe(u => {
      if (u.id != null)
        this.userName = u.firstName + " " + u.lastName;
    })
  }

  // בעת לחיצה כפולה על שם המשתמש הוא ינותב לדף התחברות
  account() {
    if (this.userName == this.noUser) {
      this.r.navigate(["login"]);
    }
    else{
      this.#userS.currentUser.next({});
      this.userName = this.noUser;
    }
  }

}
