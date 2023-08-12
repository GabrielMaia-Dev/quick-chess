import { ChessBoard } from "./ChessModel";

describe('AuthService', () => {
  let board = new ChessBoard('white');

  it('should be created', () => {
    expect(board).toBeTruthy();
  });
});
