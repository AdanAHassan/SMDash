import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TableChartComponent } from './table-chart.component';

describe('TableChartComponent', () => {
  let component: TableChartComponent;
  let fixture: ComponentFixture<TableChartComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TableChartComponent]
    });
    fixture = TestBed.createComponent(TableChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
