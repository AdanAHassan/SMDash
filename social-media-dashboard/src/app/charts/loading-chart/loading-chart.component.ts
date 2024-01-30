import { Component, Input, OnInit } from '@angular/core';
import { count, timer } from 'rxjs';

const loadingCounter = timer(0, 1000)

@Component({
  selector: 'app-loading-chart',
  templateUrl: './loading-chart.component.html',
  styleUrls: ['./loading-chart.component.css']
})
export class LoadingChartComponent implements OnInit{

  @Input() loadingBoolean: boolean = false
  count: number = 0
  loadingText: string = "Start"

  ngOnInit(): void {
    loadingCounter.subscribe(() => {
      this.loadingIncrement()
    })
  }

  loadingIncrement(){
    if(this.loadingBoolean) this.count++
    else this.count = 0
    this.loadingTextGenerator()
  }

  loadingTextGenerator() {
    if(this.count < 10) this.loadingText = "Loading..."
    else if(this.count < 60) this.loadingText = "One moment"
    else if(this.count < 180) this.loadingText = "Your connection seems to be slow, please refresh"
    else this.loadingText = "Unable to load chart"
  }
}
