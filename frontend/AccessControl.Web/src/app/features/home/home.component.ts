import { Component, inject, OnInit } from '@angular/core';
import { AuthService } from '../auth/auth.service';
import { DashboardService } from '../dashboard/dashboard-service';

@Component({
  selector: 'app-home',
  imports: [],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  public authService = inject(AuthService);

  logout() {
    // Mantendo a opção de redirecionar diretamente para o Okta
    this.authService.logout();
  }
}
