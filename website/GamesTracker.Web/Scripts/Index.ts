import { Game, fetchGameDetails } from "./GamesApi.js";
import {bindControl, Observable} from "./bindable-model.js";

class BindableGame {
    id: Observable<number>;
    name: Observable<string>;
    description: Observable<string>;

    constructor(id: number, name: string, description: string) {
        this.id = new Observable(id);
        this.name = new Observable(name);
        this.description = new Observable(description);
    }

    public updateFromGame(game: Game): void {
        this.id.value = game.id;
        this.name.value = game.name;
        this.description.value = game.description;
    }
}

let boundGame = new BindableGame(0, "", "tofu");

const getThisGame = async function (this: HTMLAnchorElement): Promise<void> {
    let gameId: number = parseInt(this.dataset.edit, 10);
    const theGame = await fetchGameDetails(gameId);

    boundGame.updateFromGame(theGame);
}

document.addEventListener('DOMContentLoaded', () => {
    const buttons = document.querySelectorAll('[data-edit]') as NodeListOf<HTMLAnchorElement>;
    for(const button of buttons) {
        button.onclick = getThisGame;
    }

    // (document.getElementById('desc-text') as HTMLInputElement).value = boundGame.description;
    bindControl(document.getElementById('desc-text'), boundGame.description);
    bindControl(document.getElementById('desc-label'), boundGame.description);
});
