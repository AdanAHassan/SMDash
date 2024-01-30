import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { HelperService } from 'src/app/services/helper/helper.service';
import { defaultChart, genericCardType } from 'src/app/shared/types/CustomChartTypes';
import { ProgressDataType } from 'src/app/shared/types/ProgressDataType';
import { metricType } from 'src/app/shared/types/StringLiterals';
import { TableDataType, TimeSpanTypes } from 'src/app/shared/types/TableCardType';
import { PlatformMetricRenderType } from 'src/app/shared/types/data/RenderTypes';

@Component({
  selector: 'app-generic-card',
  templateUrl: './generic-card.component.html',
  styleUrls: ['./generic-card.component.css']
})
export class GenericCardComponent implements OnChanges {

  constructor(public helperService: HelperService){}

  @Input() inputData: PlatformMetricRenderType[] = [] as PlatformMetricRenderType[]
  @Input() inputType: genericCardType["type"] = {} as genericCardType["type"]
  @Input() inputLength: number = 0

  CardData: genericCardType = {
    type: "loading",
    data: [],
  }

  loadingCount: number = 0

  isLoading(): boolean {
    if(Array.isArray(this.CardData.data) && this.CardData.data.length === 0) {
      return true
    }
    else if (this.CardData.type === "loading"){
      return true
    }
    else if("datasets" in this.CardData.data && Array.isArray(this.CardData.data.datasets) && this.CardData.data.datasets.length === 0) return true
    else return false
  }

  convertToProgressData(data: PlatformMetricRenderType): ProgressDataType {
    let x: ProgressDataType = {title: data.metric, progress: data.progress, total: data.target}
    return x
  }

  convertToLineData(data: PlatformMetricRenderType): defaultChart["data"]["datasets"][number] {
    let x: defaultChart["data"]["datasets"][number] = { data: data.progress, label: data.metric }
    return x
  }

  convertToTableData(){}

  switchTimeline(data: PlatformMetricRenderType, tData: TableDataType[] = []): TableDataType[] {
    let days: number = data.progress.length
    if(days <= 7) {
      data.progress.map((v, i) => this.generateTable(tData, i, v, data.metric, "day"))
    }
    else if(days < 7*12)
      this.processProgress(data.progress, 7).map((v, i) => this.generateTable(tData, i, v, data.metric, "week"))
    else if(days < 7*4*12)
      this.processProgress(data.progress, 28).map((v, i) => this.generateTable(tData, i, v, data.metric, "month"))
    else
      this.processProgress(data.progress, 91).map((v, i) => this.generateTable(tData, i, v, data.metric, "quarter"))
    return tData
  }

  processProgress(arr: number[], interval: number): number[]{
    let intermediate: number = 0
    let returnArr: number[] = []
    for (let i = 0; i < arr.length; i++) {
      if(i % interval !== 0 || i === 0) intermediate+= arr[i]
      else {
        returnArr.push(intermediate)
        intermediate = 0
      }
    }
    if(intermediate !== 0) returnArr.push(intermediate)
    return returnArr
  }

  generateTable(arr: TableDataType[], index: number, value: number, metric: metricType, timespan: TimeSpanTypes){
    if(arr.filter(x => x.index === index).length > 0){
      arr.filter(x => x.index === index)[0].values.push({value: value, metric: metric})
    } else {
      arr.push({index: index, values: [{metric: metric, value: value}], timespan: timespan})
    }
  }


  convertSwitch(data: PlatformMetricRenderType[], chartType: genericCardType["type"]): genericCardType["data"] {
    let output: genericCardType["data"] = []
    switch (chartType) {
      case 'progress':
        let pArr: ProgressDataType[] = []
        data.map(x => pArr.push(this.convertToProgressData(x)))
        output = pArr
        break;
      case "line":
        let lArr: defaultChart["data"] = { datasets : []}
        data.map(x => lArr.datasets.push(this.convertToLineData(x)))
        lArr.labels = data[0].progress.map((v, i) => i)
        output = lArr
        break
      case 'table':
        let tArr: TableDataType[] = []
        data.map(x => tArr = this.switchTimeline(x, tArr))
        output = tArr
        break
      default:
        break
    }
    console.log(output)
    return output
  }

  ngOnChanges(changes: SimpleChanges) {
    if(changes["inputType"] && this.inputType !== "loading") {
      this.CardData.type = this.inputType
    }
    if(changes["inputLength"] && this.inputLength > 0) {
      this.CardData.data = this.convertSwitch(this.inputData, this.inputType)
    }
    if(changes["inputType"] && this.inputLength > 0){
      this.CardData.data = this.convertSwitch(this.inputData, this.inputType)
    }
  }
}
