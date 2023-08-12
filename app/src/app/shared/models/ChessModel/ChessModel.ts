export const WhitePieceTypes = ['P', 'R','N', 'B', 'Q', 'K'] as const;
export const BlackPieceTypes = ['p', 'r','n', 'b', 'q', 'k'] as const;
export const PieceTypes = [...WhitePieceTypes, ...BlackPieceTypes] as const;

export type ChessPieceType = typeof PieceTypes[number];

export const ChessPositions = [
  'a8', 'b8', 'c8', 'd8', 'e8', 'f8', 'g8', 'h8',
  'a7', 'b7', 'c7', 'd7', 'e7', 'f7', 'g7', 'h7',
  'a6', 'b6', 'c6', 'd6', 'e6', 'f6', 'g6', 'h6',
  'a5', 'b5', 'c5', 'd5', 'e5', 'f5', 'g5', 'h5',
  'a4', 'b4', 'c4', 'd4', 'e4', 'f4', 'g4', 'h4',
  'a3', 'b3', 'c3', 'd3', 'e3', 'f3', 'g3', 'h3',
  'a2', 'b2', 'c2', 'd2', 'e2', 'f2', 'g2', 'h2',
  'a1', 'b1', 'c1', 'd1', 'e1', 'f1', 'g1', 'h1'
] as const;

export type ChessPosition = typeof ChessPositions[number];

export type ChessColor = 'white' | 'black';



export class ChessPiece {
    public type: ChessPieceType;

    get color() : ChessColor {
        return BlackPieceTypes.some(t => t == this.type) ? 'black' : 'white';
    }

    constructor(type: ChessPieceType) {
        if(!PieceTypes.some(p => p == type)) throw new Error(`Unkonw piece type '${type}'`);
        this.type = type;
    }
}

export type ChessAction = {
    from: ChessPosition,
    to: ChessPosition,
}

export class ChessBoard {
    private _turn: ChessColor;
    private _pieces: Map<ChessPosition, ChessPiece>;
    private _selected: ChessPosition | null;
    
    public actionCallback?: (action: ChessAction) => void

    get turn() {
      return this._turn;
    }

    get pieces() {
        return [...this._pieces.values()];
    }

    get selected() {
        return this._selected;
    }
  
    constructor(fen?: string) {
        this._turn = 'white';
        this._selected = null;
        this._pieces = this.parseFen(fen);
    }

    public load(fen: string) {
        this._pieces = this.parseFen(fen)
    }

    private parseFen(fen?: string) {
        const board = new Map<ChessPosition, ChessPiece>()
        if(!fen) return board;
        const split = fen.split(' ');
        const boardMatrix = split[0].split('/');
        this._turn = split[1] === 'w' ? 'white' : 'black';
      
        boardMatrix.forEach((column, colIndex) => {
            const rowName =  String(8 - colIndex);
            let rowIndex = 0;
            [...column].forEach((row) => {
                if(Number(row)) {
                    rowIndex += Number(row);
                } else {
                    const colName = String.fromCharCode('a'.charCodeAt(0) + rowIndex);
                    const piece = new ChessPiece(row as ChessPieceType);
                    const position = `${colName}${rowName}` as ChessPosition;
                    board.set(position, piece)
                    rowIndex += 1;
                }
            });
        });

        return board;
    }

    public select(position: ChessPosition) {
        if(this._selected) {
            const action: ChessAction = { from: this._selected, to: position };
            this.actionCallback?.(action);
            this._selected = null;
            return;
        }

        if(this._pieces.has(position)) {
            this._selected = position;
        }
    }
  
    public get(position: ChessPosition) {
        return this._pieces.get(position);
    }
  }