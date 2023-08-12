import { TestBed } from '@angular/core/testing';

import { GameConnectionFactory } from './gamehub.service';

describe('GamehubService', () => {
  let service: GameConnectionFactory;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GameConnectionFactory);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
