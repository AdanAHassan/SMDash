import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ErrorObserver, catchError, first, mergeMap, of } from 'rxjs';
import { HelperService } from 'src/app/services/helper/helper.service';
import { PlatformDatasetService } from 'src/app/services/platform-dataset/platform-dataset.service';
import { PlatformMetricService } from 'src/app/services/platform-metric/platform-metric.service';
import { genericCardType } from 'src/app/shared/types/CustomChartTypes';
import { PlatformDatasetRenderType, PlatformMetricRenderType } from 'src/app/shared/types/data/RenderTypes';

@Component({
  selector: 'app-client-page',
  templateUrl: './client-page.component.html',
  styleUrls: ['./client-page.component.css']
})
export class ClientPageComponent implements OnInit  {
  constructor(
    private activatedRoute: ActivatedRoute,
    private route: Router,
    private _platformDatasetService: PlatformDatasetService,
    private _platformMetricService: PlatformMetricService,
    public helperService: HelperService,
  ){
    this.loadingArr = Array(4).fill(0)
  }

  loadingArr: number[] = []

  displayData: PlatformMetricRenderType[] = []
  displayIndex: number = 0
  displayType: genericCardType["type"] = "progress"
  clientName: string = "Client"

  chartTypes: genericCardType["type"][] = ["progress", "line", "table"]

  isNumber(x: any): boolean{
    return typeof x === "number"
  }

  setPlatform(id: number): void {
    this.displayData = this.getPlatformMetrics(id)
  }

  setDisplayType(newType: genericCardType["type"]): void {
    this.displayType = newType
  }

  setDisplayIndex(newIndex: number): void {
    // console.log(this.displayData[newIndex])
    this.displayIndex = newIndex
  }

  dataGroup: PlatformDatasetRenderType[] = []

  getPlatformDataset(): PlatformDatasetRenderType[] {

    let mainData: PlatformDatasetRenderType[] = []

    this.activatedRoute.url.pipe(first()).pipe(
      mergeMap((res1) => {
        let name = this._platformDatasetService.getPlatformDatasetByClientName(res1[1].path)
        this.clientName = res1[1].path
        console.log(this.clientName)
        return name
        }),
      mergeMap((res2: PlatformDatasetRenderType[]) => {
        res2.map((x, i) => {
          if(i===0) this.setPlatform(x.id)
          mainData.push(x)
        })
        let res3: any[] = []
        return res3
      }),
    ).subscribe((res: PlatformMetricRenderType[]) => {
    }, error => {
      console.log(error)
      if(error.status === 404) {
        this.route.navigate(["/404"])
      }
      return of(error)
    })
    return mainData
  }

  getPlatformMetrics(parentId: number): PlatformMetricRenderType[] {
    let mainData: PlatformMetricRenderType[] = []
    this._platformMetricService.getPlatformMetricByParentId(parentId).subscribe((res: PlatformMetricRenderType[]) => {
      res.map(x => mainData.push(x))
    })
    return mainData
  }

  ngOnInit(): void {
    this.dataGroup = this.getPlatformDataset()
    console.log(this.displayData)
  }
}

// After much time spent changing data on the client side I will do all the work on the server and fetch what I need as I need it
