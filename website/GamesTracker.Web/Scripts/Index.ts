import '../lib/bootstrap/dist/js/bootstrap.bundle.min.js';
import {Game, fetchGameDetails, updateGameDetails} from "./GamesApi.js";
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

    public toGame(): Game {
        return {
            id: this.id.value,
            name: this.name.value,
            description: this.description.value
        };
    }
}

let boundGame = new BindableGame(0, "", "");

const getThisGame = async function (this: HTMLAnchorElement): Promise<void> {
    let gameId: number = parseInt(this.dataset.edit, 10);
    const theGame = await fetchGameDetails(gameId);

    boundGame.updateFromGame(theGame);
}

const bindGame = () => {
    document.querySelectorAll("[data-bind]").forEach((elem: HTMLElement) => {
        const key = elem.getAttribute("data-bind");
        if(key){
            const obs = (boundGame as any)[key] as Observable<any>;
            bindControl(elem, obs);
        }
    });
}

const saveGame = async function (): Promise<void> {
    const game = boundGame.toGame();
    const isSaved = await updateGameDetails(game);
    if(isSaved) {
        window.location.reload()
    }
}

document.addEventListener('DOMContentLoaded', () => {
    const buttons = document.querySelectorAll('[data-edit]') as NodeListOf<HTMLAnchorElement>;
    for(const button of buttons) {
        button.onclick = getThisGame;
    }

    document.getElementById("save-button")?.addEventListener("click", saveGame);

    bindGame();
});
