import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.css']
})
export class PaginationComponent implements OnInit{

  @Input() pageIndex: number = 1
  @Input() total: number = 0
  @Input() perPage: number = 10
  @Input() maxPages: number = 0
  @Input() loading: boolean = false

  @Output() goPrev = new EventEmitter<boolean>();
  @Output() goNext = new EventEmitter<boolean>();

  constructor(){}

  ngOnInit(): void {

  }

  clickPrev(): void {
    console.log(this.loading)
    if(this.pageIndex > 1 && !this.loading) {
      this.goPrev.emit(true)
      console.log("clicked")
    }
  }

  clickNext(): void {
    if(!this.isLastPage() && !this.loading) this.goNext.emit(true)
  }

  isLastPage(): boolean {
    return this.perPage * this.pageIndex >= this.total
  }
}
