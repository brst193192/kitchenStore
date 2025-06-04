import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from '../../interfaces/user';
import { UserService } from '../../services/user.service';
import { CartService } from '../../services/cart.service';
import { ErrorsDirective } from '../../../directivs/errors.directive';

@Component({
  selector: 'app-registration',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, ErrorsDirective],
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.less'
})
export class RegistrationComponent {
  registerForm: FormGroup = new FormGroup([]);
  #router: Router = inject(Router);
  #cartS: CartService = inject(CartService);
  #userS: UserService = inject(UserService);

  restart() {
    this.registerForm = new FormGroup({
      "Fname": new FormControl(null, [Validators.required, Validators.minLength(2)]),
      "Lname": new FormControl(null, [Validators.required, Validators.minLength(2)]),
      "Email": new FormControl(null, [Validators.required, Validators.email]),
      "Password": new FormControl(null, [Validators.required, Validators.minLength(4)]),
      "CheckPassword": new FormControl(null, [Validators.required]),
      "Birthday": new FormControl(null, [Validators.required]),
      "City": new FormControl(null, [Validators.required, Validators.minLength(2)]),
      "Street": new FormControl(null, [Validators.required, Validators.minLength(2)]),
      "BuildNumber": new FormControl(null, [Validators.min(1)]),
      "HouseNumber": new FormControl(null, [Validators.required, Validators.min(1)]),
    });
  }

  //אתחול הטופס
  ngOnInit() {
    this.restart();
  }

  get getFname() { return this.registerForm.controls['Fname'] }
  get getLname() { return this.registerForm.controls['Lname'] }
  get getEmail() { return this.registerForm.controls['Email'] }
  get getPassword() { return this.registerForm.controls['Password'] }
  get getCheckPassword() { return this.registerForm.controls['CheckPassword'] }
  get getBirthday() { return this.registerForm.controls['Birthday'] }
  get getCity() { return this.registerForm.controls['City'] }
  get getStreet() { return this.registerForm.controls['Street'] }
  get getBuildNumber() { return this.registerForm.controls['BuildNumber'] }
  get getHouseNumber() { return this.registerForm.controls['HouseNumber'] }

  //הרשמה לאתר
  register() {
    if (this.registerForm.invalid)
      alert("יש לתקן שדות שגויים!")
    if (this.getPassword.value != this.getCheckPassword.value)
      alert("ססמא לא תואמת!")
    else {
      const newUser: User=this.buildUser();
      debugger
      this.#userS.register(newUser).subscribe(
        data => {
          alert("שלום לך "+newUser.firstName+" "+newUser.lastName+" נרשמת בהצלחה!")
          this.#userS.currentUser.next({ ...data });
          this.#cartS.cart_prod.forEach(p => p.userId = data.id);
          this.#cartS.addManyToCart(this.#cartS.cart_prod)
          this.#router.navigate(['products']);
        },
        err => {
          console.log(err)
        }
      );
    }
  }

  //בנית אוביקט משתמש לפי הנתונים שבשדות
  buildUser(){
    const newUser: User = {
      firstName: this.getFname.value,
      lastName: this.getLname.value,
      email: this.getEmail.value,
      password: this.getPassword.value,
      address:
      {
        city: this.getCity.value,
        street: this.getStreet.value,
        buildNumber: this.getBuildNumber?.value,
        houseNumber: this.getHouseNumber.value
      },
      birthday: this.getBirthday.value,
    }
    return newUser;
  }

  //ניתוב לדף התחברות
  login() {
    this.#router.navigate(["login"]);
  }
}
