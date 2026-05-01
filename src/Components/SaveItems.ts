export async function SaveFolder(folder: string) {
    const response = await fetch("http://localhost:5180/api/createCatalog", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ name: folder }),
    });

    console.log("status:", response.status);

    if (!response.ok) {
        const errorText = await response.text();
        throw new Error(`Save failed: ${response.status} ${errorText}`);
    }
}

export async function SaveApi(Api: string, apiMethod: string)  {
    const response = await fetch("http://localhost:5180/api/createApi", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ name: Api }),
    });

    console.log("status:", response.status);

    if (!response.ok) {
        const errorText = await response.text();
        throw new Error(`Save failed: ${response.status} ${errorText}`);
    }
}
