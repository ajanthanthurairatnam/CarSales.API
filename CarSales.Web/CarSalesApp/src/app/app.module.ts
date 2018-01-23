import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { SandboxComponent} from './components/sandbox.component';
import { DataService } from './services/data.service';
import { CarListComponent } from './components/car-list/car-list.component';
import { CarListSearchComponent } from './components/car-list-search/car-list-search.component';

@NgModule({
  declarations: [
    AppComponent,
    SandboxComponent,
    CarListComponent,
    CarListSearchComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule
  ],
  providers: [DataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
