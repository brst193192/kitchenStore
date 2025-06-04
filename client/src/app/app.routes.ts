import { Routes } from '@angular/router';
import { HomePageComponent } from './components/home-page/home-page.component';
import { ProductsComponent } from './components/products/products.component';
import { PaymentComponent } from './components/payment/payment.component';
import { LoginComponent } from './components/login/login.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { DetailsComponent } from './components/details/details.component';
import { OrdersComponent } from './components/orders/orders.component';
import { CartComponent } from './components/cart/cart.component';

export const routes: Routes = [
    {path:"", component:HomePageComponent},
    {path:"products", component:ProductsComponent},
    {path:"cart", component:CartComponent},
    {path:"payment", component:PaymentComponent},
    {path:"login", component:LoginComponent},
    {path:"registration", component:RegistrationComponent},
    {path:"details/:id", component:DetailsComponent},
    {path:"orders", component:OrdersComponent},
];
