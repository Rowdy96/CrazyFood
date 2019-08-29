import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RestaurantModule } from './restaurant/restaurant.module';
import { RestaurantDetailsModule } from './restaurant-details/restaurant-details.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RestaurantModule,
    HttpClientModule,
    RestaurantDetailsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
