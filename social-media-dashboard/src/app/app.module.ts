import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DataCardComponent } from './cards/data-card/data-card.component';
import { LineChartComponent } from './charts/line-chart/line-chart.component';
import { BarChartComponent } from './charts/bar-chart/bar-chart.component';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { ClientPageComponent } from './pages/client-page/client-page.component';
import { NavbarComponent } from './other/navbar/navbar.component';
import { ProgressChartComponent } from './charts/progress-chart/progress-chart.component';
import { NgChartsModule } from 'ng2-charts';
import { NgIconsModule } from '@ng-icons/core';
import { iconoirEyeEmpty, iconoirAddUser, iconoirHeart, iconoirMessage, iconoirInstagram, iconoirFacebookTag, iconoirTwitter, iconoirYoutube, iconoirCheck, iconoirEditPencil } from "@ng-icons/iconoir";
import { customIconQuote, customIconRetweet } from './other/icons';
import { typHome } from "@ng-icons/typicons"
import { TableChartComponent } from './charts/table-chart/table-chart.component';
import { HttpClientModule } from "@angular/common/http";
import { GenericCardComponent } from './cards/generic-card/generic-card.component';
import { PaginationComponent } from './other//pagination/pagination.component';
import { LoadingChartComponent } from './charts/loading-chart/loading-chart.component';
import { LoadingCardComponent } from './cards/loading-card/loading-card.component';
import { ErrorPageComponent } from './pages/error-page/error-page.component';


@NgModule({
  declarations: [
    AppComponent,
    DataCardComponent,
    LineChartComponent,
    BarChartComponent,
    HomePageComponent,
    ClientPageComponent,
    NavbarComponent,
    ProgressChartComponent,
    TableChartComponent,
    GenericCardComponent,
    PaginationComponent,
    LoadingChartComponent,
    LoadingCardComponent,
    ErrorPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgChartsModule.forRoot({
      defaults: {
        responsive: true,
        maintainAspectRatio: false,
      },
      generateColors: true,
    }),
    NgIconsModule.withIcons({ iconoirEyeEmpty, iconoirAddUser, iconoirHeart, iconoirMessage, iconoirInstagram, iconoirTwitter, iconoirFacebookTag, iconoirYoutube, iconoirCheck, iconoirEditPencil, customIconRetweet, customIconQuote, typHome })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
