import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChessSessionView } from './chess-session-view.component';

describe('ChessSessionViewComponent', () => {
  let component: ChessSessionView;
  let fixture: ComponentFixture<ChessSessionView>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ChessSessionView]
    });
    fixture = TestBed.createComponent(ChessSessionView);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
