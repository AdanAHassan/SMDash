import { Component } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  navArr: { text: string, link: string, available: boolean }[] = [
    { text: "Client list", link: "home", available: true },
    { text: "Add client", link: "add-client", available: false },
    { text: "Manage clients", link: "manage-clients", available: false }
  ]
}
