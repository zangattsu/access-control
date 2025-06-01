import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardService } from '../dashboard-service';

@Component({
  selector: 'app-dashboard-view',
  imports: [CommonModule],
  templateUrl: './dashboard-view.component.html',
  styleUrl: './dashboard-view.component.css'
})
export class DashboardViewComponent {

  public dashboardService = inject(DashboardService);
  public dados: any = "";
  
  ngOnInit(): void {
    this.dashboardService.getWeatherForecastList().subscribe({
      next: (data) => {
        this.dados = JSON.stringify(data);
        return;
      },
      error: (error) => {
        console.error(error);
        this.dados = `$Error retrieving weather data. Error: ${error}`;
        return;
      },
      complete: () => {
        //this.dados = 'Weather forecast list retrieved successfully.';
      }
    });
  }
}
