import { Component } from '@angular/core';
import { ChartConfiguration, ChartOptions, ChartType } from 'chart.js';

@Component({
  selector: 'app-bar-chart',
  templateUrl: './bar-chart.component.html',
  styleUrls: ['./bar-chart.component.css']
})
export class BarChartComponent {
  public barChartData: ChartConfiguration['data'] = {
      datasets: [
        { data: [2, 24, 13, 18, 22, 15, 16, 21, 19, 25], label: "Followers" }
      ],
      labels: ["1", "2", "3", "4", "5", "6", "7", "8", "9", "10"],
    };

  public barChartOptions: ChartOptions = {
    responsive: true,
    elements: {
      line: {
        tension: 0.5
      }
    }
  }
  public barChartLegends: boolean = true
  public barChartType: ChartType = 'bar';
}
