class Game {
    id: number;
    name: string;
    description: string;

    constructor(id: number, name: string, description: string) {
        this.id = id;
        this.name = name;
        this.description = description;
    }
}

const fetchGameDetails = async (id: number): Promise<Game> => {
    const url = `/api/Games/${id}`; // Root-relative URL

    try {
        const response = await fetch(url);
        if (response.ok) {
            const data = await response.json();
            console.log("Game Details:", data);
            return new Game(data.id, data.name, data.description);
        } else {
            console.error(`HTTP error! status: ${response.status}`);
            return null;
        }
    } catch (error) {
        console.error("Could not fetch game details for ID", id, ":", error);
        return null;
    }
}

const getThisGame = async function (this: HTMLAnchorElement): Promise<void> {
    let gameId: number = parseInt(this.dataset.edit, 10);
    let theGame: Game = await fetchGameDetails(gameId);

    alert(theGame.name)
}

document.addEventListener('DOMContentLoaded', () => {
    const buttons = document.querySelectorAll('[data-edit]') as NodeListOf<HTMLAnchorElement>;
    for(const button of buttons) {
        button.onclick = getThisGame;
    }
});
