import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Router} from '@angular/router';


import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { Routes } from '@angular/router/src/config';
import { DashboardComponent } from './components/dashboard/dashboard.component';


const routes: Routes = [
  {path: "", redirectTo: 'dashboard', pathMatch: 'full'},
  {path: "dashboard", component: DashboardComponent}
]

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    DashboardComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
