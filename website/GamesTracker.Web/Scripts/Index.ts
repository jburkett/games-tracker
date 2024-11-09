import '../lib/bootstrap/dist/js/bootstrap.bundle.min.js';
import {Game, fetchGameDetails, updateGame} from "./GamesApi.js";
import {bindControl, Observable} from "./bindable-model.js";

interface ModalEvent extends Event {
    relatedTarget: HTMLElement;
}

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
    if(boundGame.id.value > 0) {
        const game = boundGame.toGame();
        const isSaved = await updateGame(game);
        if(isSaved) {
            window.location.reload()
        }

    }
}

let isFillModalRunning = false;

const fillModal = async function (event: ModalEvent): Promise<void> {
    if (isFillModalRunning) return;
    isFillModalRunning = true;    const button = event.relatedTarget as HTMLButtonElement;
    const gameId = parseInt(button.dataset.edit, 10);

    let theGame: Game = {id: 0, name: "", description: ""};

    if(gameId > 0) {
        theGame = await fetchGameDetails(gameId);
    }
    boundGame.updateFromGame(theGame);

    isFillModalRunning = false;
}

document.addEventListener('DOMContentLoaded', () => {
    const myModalEl = document.getElementById('detailsModal')
    myModalEl.addEventListener('show.bs.modal', fillModal);

    document.getElementById("save-button")?.addEventListener("click", saveGame);

    bindGame();
});
