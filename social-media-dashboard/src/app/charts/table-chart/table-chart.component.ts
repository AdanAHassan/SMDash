import { Component, Input } from '@angular/core';
import { HelperService } from 'src/app/services/helper/helper.service';
import { metricType } from 'src/app/shared/types/StringLiterals';
import { TableDataType, TimeSpanTypes } from 'src/app/shared/types/TableCardType';

@Component({
  selector: 'app-table-chart',
  templateUrl: './table-chart.component.html',
  styleUrls: ['./table-chart.component.css']
})
export class TableChartComponent {

  constructor(public helperService: HelperService){}

  @Input() dataGroup: TableDataType[] = []


  calculateTotal(type: metricType): number {
    return this.dataGroup.map(x => x.values.filter(y => y.metric.toLowerCase() === type.toLowerCase()).map(x => x.value)).flat().reduce((p, c) => p + c, 0)
  }

  getValue(item: TableDataType): number[]{
    return item.values.map(x => x.value)
  }

  getMetrics(): metricType[]{
    if(this.dataGroup.length === 0) return []
    return this.dataGroup[0].values.map(x => x.metric)
  }



}
