import { Component, Input, OnInit, Output } from '@angular/core';
import { ChessBoard, ChessPieceType, ChessPosition, ChessPositions } from '../../models/ChessModel/ChessModel';

const pieceMap = new Map<ChessPieceType, string>([
  ['p', 'assets/bp.png'],
  ['r', 'assets/br.png'],
  ['n', 'assets/bn.png'],
  ['b', 'assets/bb.png'],
  ['q', 'assets/bq.png'],
  ['k', 'assets/bk.png'],
  ['P', 'assets/wp.png'],
  ['R', 'assets/wr.png'],
  ['N', 'assets/wn.png'],
  ['B', 'assets/wb.png'],
  ['Q', 'assets/wq.png'],
  ['K', 'assets/wk.png'],
]);

@Component({
  selector: 'app-chess-board',
  templateUrl: './chess-board.component.html',
  styleUrls: ['./chess-board.component.scss']
})
export class ChessBoardComponent {
  @Input({ required: true }) board!: ChessBoard;

  positions = ChessPositions;
  
  pieceMap = pieceMap;

  click(position: ChessPosition) {
    this.board.select(position);
  }
}
