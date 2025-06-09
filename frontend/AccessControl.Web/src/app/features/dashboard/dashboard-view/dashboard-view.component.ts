import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardService } from '../dashboard-service';
import { AuthService } from '../../auth/auth.service';

@Component({
  selector: 'app-dashboard-view',
  imports: [CommonModule],
  templateUrl: './dashboard-view.component.html',
  styleUrl: './dashboard-view.component.css'
})
export class DashboardViewComponent {

  public dashboardService = inject(DashboardService);
  public authService = inject(AuthService);
  public dados: any = "";
  
  public stringToken: any = this.authService.getAccessToken().then((token: string) => {
    console.log('Access Token:', token);
    return token;
  });

  ngOnInit(): void {
    this.dashboardService.getWeatherForecastList().subscribe({
      next: (data) => {
        this.dados = JSON.stringify(data);
        console.log('Weather data retrieved successfully:', this.dados);
        return;
      },
      error: (error) => {
        this.dados = `Error retrieving weather data. Error: ${error}`;
        return;
      },
      // complete: () => {
      //   this.dados = 'Weather forecast list retrieved successfully.';
      // }
    });
  }
}
