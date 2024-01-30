import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { platformType } from './shared/types/StringLiterals';
import { ClientType, PlatformDatasetType } from './shared/types/data/DBtypes';
import { ClientPageComponent } from './pages/client-page/client-page.component';
import { ErrorPageComponent } from './pages/error-page/error-page.component';

const routes: Routes = [
  { path: "home", component: HomePageComponent },
  { path: "", redirectTo: "/home", pathMatch: "full" },
  { path: "client/:name", component: ClientPageComponent },
  { path: "404", component: ErrorPageComponent }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
