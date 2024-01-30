import { Component, Input, ViewChild } from '@angular/core';
import { ChartConfiguration, ChartOptions, ChartType } from 'chart.js';

@Component({
  selector: 'app-line-chart',
  templateUrl: './line-chart.component.html',
  styleUrls: ['./line-chart.component.css'],
})
export class LineChartComponent {
  @Input() lineChartData: ChartConfiguration['data'] = {
    datasets: [
      { data: [2, 24, 13, 18, 22, 15, 16, 21, 19, 25], label: "Followers" }
    ],
    labels: ["1", "2", "3", "4", "5", "6", "7", "8", "9", "10"],
  };

  public lineChartOptions: ChartOptions = {
    responsive: true,
    maintainAspectRatio: false,
    elements: {
      line: {
        tension: 0.5
      }
    }
  }
  public lineChartLegends: boolean = true
  public lineChartType: ChartType = 'line';
}
