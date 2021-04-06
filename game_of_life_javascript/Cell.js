import CellState from "./CellState";

export default class Cell {
    constructor(state) {
        this.state = state;
    }

    getNextState(neighbours) {
        if (neighbours < 2) {
            return CellState.DEAD
        } else if (neighbours === 2 || neighbours === 3) {
            return CellState.ALIVE;
        }
    }
}