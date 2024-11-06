import { Game, fetchGameDetails } from "./GamesApi.js";
import {bindControl} from "./bindable-model";

let modalGame = new Game(0, '', '');

const getThisGame = async function (this: HTMLAnchorElement): Promise<void> {
    let gameId: number = parseInt(this.dataset.edit, 10);
    const theGame = await fetchGameDetails(gameId);
    modalGame.name.value = theGame.name.value;

    alert(modalGame.name.value);
    document.getElementById('game-name').innerText = modalGame.name.value;
}

document.addEventListener('DOMContentLoaded', () => {
    const buttons = document.querySelectorAll('[data-edit]') as NodeListOf<HTMLAnchorElement>;
    for(const button of buttons) {
        button.onclick = getThisGame;
    }

    // bindControl(document.getElementById('game-name'), modalGame.name);
});
