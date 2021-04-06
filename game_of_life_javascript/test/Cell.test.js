import { expect } from 'chai';
import CellState from '../CellState';
import Cell from '../Cell';

describe('Cell', () => {
    it('Should be initialized with a cellState', () => {
        const aliveCell = new Cell(CellState.ALIVE);
        expect(aliveCell.state).to.equal(CellState.ALIVE);

        const deadCell = new Cell(CellState.DEAD);
        expect(deadCell.state).to.equal(CellState.DEAD);
    });

    it('Should die if it has fewer than 2 live neighbours', () => {
        const cell = new Cell(CellState.ALIVE);
        const nextState = cell.getNextState(1);
        expect(nextState).to.equal(CellState.DEAD);
    });

    it('Should live with 2 or 3 live neighbours', () => {
        const cell = new Cell(CellState.ALIVE);
        const nextStateWith2Neighbours = cell.getNextState(2);
        expect(nextStateWith2Neighbours).to.equal(CellState.ALIVE);

        const nextStateWith3Neighbours = cell.getNextState(3);
        expect(nextStateWith3Neighbours).to.equal(CellState.ALIVE);
    });
});