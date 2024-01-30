import { Component, Input } from '@angular/core';
import { HelperService } from 'src/app/services/helper/helper.service';
import { PlatformMetricType } from 'src/app/shared/types/data/DBtypes';
import { PlatformMetricRenderType } from 'src/app/shared/types/data/RenderTypes';

@Component({
  selector: 'app-data-card',
  templateUrl: './data-card.component.html',
  styleUrls: ['./data-card.component.css']
})
export class DataCardComponent {
  @Input() cardData: PlatformMetricRenderType = {
    id: 0,
    metric: "Loading",
    target: 0,
    progress: [],
    startDate: new Date,
    platformDatasetId: 0
  }
  constructor(public helperService: HelperService){
  }


  generateTitle(metric: string): string {
    return `${this.helperService.capitalizeFirstLetter(metric)} Dashboard`
  }

  percentageTarget(data: PlatformMetricRenderType): number {
    return (data.progress.reduce((a, b) => a + b, 0)/data.target)*100
  }
}
