export class Game {
    id: number;
    name: string;
    description: string;
}

export const fetchGameDetails = async (id: number): Promise<Game> => {
    const url = `/api/Games/${id}`; // Root-relative URL

    try {
        const response = await fetch(url);
        if (response.ok) {
            const data = await response.json();
            console.log("Game Details:", data);
            return {id: data.id, name: data.name, description: data.description};
        } else {
            console.error(`HTTP error! status: ${response.status}`);
            return null;
        }
    } catch (error) {
        console.error("Could not fetch game details for ID", id, ":", error);
        return null;
    }
}

export const updateGame = async (game: Game): Promise<boolean> => {
    const url = `/api/Games/${game.id}`; // Root-relative URL

    const options = {
        method: "PUT",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(game)
    };

    try {
        const response = await fetch(url, options);
        if (response.ok) {
            console.log("Game details updated successfully");
            return true;
        } else {
            console.error(`HTTP error! status: ${response.status}`);
            return false;
        }
    } catch (error) {
        console.error("Could not update game details for ID", game.id, ":", error);
        return false;
    }
}

export const addGame = async (game: Game): Promise<number> => {
    const url = `/api/Games`; // Root-relative URL

    const options = {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(game)
    };

    try {
        const response = await fetch(url, options);
        if (response.ok) {
            const data = await response.json();
            console.log("Game added successfully with ID", data.id);
            return data.id;
        } else {
            console.error(`HTTP error! status: ${response.status}`);
            return -1;
        }
    } catch (error) {
        console.error("Could not add game details:", error);
        return -1;
    }
}

export const deleteGame = async (id: number): Promise<boolean> => {
    const url = `/api/Games/${id}`; // Root-relative URL

    const options = {
        method: "DELETE"
    };

    try {
        const response = await fetch(url, options);
        if (response.ok) {
            console.log("Game deleted successfully");
            return true;
        } else {
            console.error(`HTTP error! status: ${response.status}`);
            return false;
        }
    } catch (error) {
        console.error("Could not delete game details for ID", id, ":", error);
        return false;
    }
}