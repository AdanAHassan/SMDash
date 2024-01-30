import { Component, Input } from '@angular/core';
import { ProgressDataType } from 'src/app/shared/types/ProgressDataType';

@Component({
  selector: 'app-progress-chart',
  templateUrl: './progress-chart.component.html',
  styleUrls: ['./progress-chart.component.css']
})
export class ProgressChartComponent {
  @Input() progressData: ProgressDataType[] | []= [
    {
      title: "Impressions",
      progress: [1950],
      total: 2000
    },
    {
      title: "Followers",
      progress: [1950],
      total: 2000
    },
    {
      title: "Impressions",
      progress: [2000],
      total: 2000
    },
    {
      title: "Impressions",
      progress: [1950],
      total: 2000
    }
  ]

  getPercentage(data: ProgressDataType): number {
    return (Math.floor((data.progress.reduce((a, b) => a + b, 0)/data.total)*100*100)/100)
  }

  getReduced(data: ProgressDataType): number{
    return data.progress.reduce((a, b) => a + b, 0)
  }

  getWidth(data: ProgressDataType): string {
    return `${this.getPercentage(data)}%`
  }

  ngOnInit(): void {
    console.log(this.progressData)
  }

  progressComplete(data: ProgressDataType): boolean {
    return data.progress.reduce((a, b) => a + b, 0) === data.total
  }

}
