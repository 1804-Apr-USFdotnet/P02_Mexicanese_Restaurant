import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './/app-routing.module';
import { RouterModule } from '@angular/router';
import { NavbarComponent } from './navbar/navbar.component';
import { HttpClientModule} from '@angular/common/http';
import { JumbotronComponent } from './jumbotron/jumbotron.component';
import { FormsModule } from "@angular/forms";

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    JumbotronComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
