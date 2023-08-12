import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MainView } from './main-view.component';

describe('MainViewComponent', () => {
  let component: MainView;
  let fixture: ComponentFixture<MainView>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MainView]
    });
    fixture = TestBed.createComponent(MainView);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
