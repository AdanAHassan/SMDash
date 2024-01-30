import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoadingChartComponent } from './loading-chart.component';

describe('LoadingChartComponent', () => {
  let component: LoadingChartComponent;
  let fixture: ComponentFixture<LoadingChartComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [LoadingChartComponent]
    });
    fixture = TestBed.createComponent(LoadingChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
