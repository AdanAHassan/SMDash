import { Component, OnInit } from '@angular/core';
import { HelperService } from 'src/app/services/helper/helper.service';
import { ClientService } from 'src/app/services/client/client.service';
import { ClientType, PlatformDatasetType } from 'src/app/shared/types/data/DBtypes';
import { PlatformDatasetService } from 'src/app/services/platform-dataset/platform-dataset.service';
import { ClientRenderType } from 'src/app/shared/types/data/RenderTypes';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  constructor(
    private _clientService: ClientService,
    private _platformDatasetService: PlatformDatasetService,
    public helperService: HelperService
  ){
    this.loadingArr = Array(this.perPage).fill(0)
  }

  loadingArr: number[] = []

  dataGroup: ClientRenderType[] = []

  total: number = 0
  pageIndex: number = 1
  perPage: number = 5
  loading: boolean = false

  getKeys(data: object):string[] {
    return Object.keys(data)
  }

  getValues(data: object): any {
    return Object.values(data)
  }

  isFlat(x: any): boolean {
    return !Array.isArray(x)
  }

  getPosition(x: any, clientItem: ClientRenderType): string {
    let arr = this.getValues(clientItem)
    let res = arr.indexOf(x)
    // console.log(res)
    if (res === 0) return "left"
    if (res === arr.length - 1) return "right"
    return "N/A"
  }

  isLeft(x: string): boolean {
    return x === "left"
  }

  isRight(x: string): boolean {
    return x === "right"
  }

  goToPrevPage(): void {
    this.loading = true
    this.pageIndex--
    this.getClients()
    this.loading = false
  }

  goToNextPage(): void {
    this.loading = true
    this.pageIndex++
    this.getClients()
    this.loading = false

  }

  getClients(index: number = this.pageIndex, size: number = this.perPage): void {
    this._clientService.getPaginatedClients(index, size).subscribe(res => {
      console.log(res)
      this.total = res.total
      this.dataGroup = []
      res.data.map((x: ClientType) => {
      let newData: ClientRenderType = {id: x.id, name: x.name, platforms: []}
        this.dataGroup.push(newData)
        this._platformDatasetService.getPlatformDatasetByClientId(x.id).subscribe(response => {
          response.map((y: PlatformDatasetType) => {
            this.dataGroup[this.dataGroup.indexOf(newData)].platforms.push(y.platform)
          })
        })
      })
      console.log(this.dataGroup)
    })
  }


  ngOnInit(): void {
    this.getClients()
  }
}


//  Best option is to fetch only the client ids, pass them down to components dynamically and use the client id to make the individual api calls
