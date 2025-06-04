import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../../services/user.service';
import { CartService } from '../../services/cart.service';
import { User } from '../../interfaces/user';
import { ErrorsDirective } from '../../../directivs/errors.directive';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, ErrorsDirective],
  templateUrl: './login.component.html',
  styleUrl: './login.component.less'
})
export class LoginComponent {
  loginForm: FormGroup = new FormGroup([]);
  #r: Router = inject(Router);
  #userS: UserService = inject(UserService);
  #cartS: CartService = inject(CartService);

  ngOnInit() {
    this.restart();
  }

  //אתחול הטופס
  restart() {
    this.loginForm = new FormGroup({
      "Email": new FormControl(null, [Validators.required, Validators.email]),
      "Password": new FormControl(null, [Validators.required]),
    });
  }

  get getEmail() { return this.loginForm.get("Email"); }
  get getPassword() { return this.loginForm.get("Password"); }

  //התחברות לשרת ועדכון המשתמש בסרויס
  login() {
    const u: User = { email: this.getEmail?.value, password: this.getPassword?.value }
    this.#userS.login(u).subscribe(
      data => {
        const user = { ...data };
        this.#userS.currentUser.next(user);
        alert("שלום לך " + user.firstName + " " + user.lastName + "!");
        this.#r.navigate(['products']);
      },
      err => console.log(err)
    );
  }

  //ניתוב לדף הרשמה
  register() {
    this.#r.navigate(["registration"]);
  }
}