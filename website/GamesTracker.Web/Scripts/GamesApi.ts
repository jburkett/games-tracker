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

