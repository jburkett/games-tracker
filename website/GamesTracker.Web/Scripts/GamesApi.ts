import { Observable } from "./bindable-model.js";

export class Game {
    id: Observable<number>;
    name: Observable<string>;
    description: Observable<string>;

    constructor(id: number, name: string, description: string) {
        this.id = new Observable(id);
        this.name = new Observable(name);
        this.description = new Observable(description);
    }
}

export const fetchGameDetails = async (id: number): Promise<Game> => {
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

