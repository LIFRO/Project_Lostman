import type { Api, ApiFolder } from "../Model/TypeLibrary";

export type FetchItemsResponse = {
    catalogs: ApiFolder[]
    apis: Api[]
}

export async function FetchItems(parentId: number | null): Promise<FetchItemsResponse> {
    const query = parentId === null ? "" : `?id=${parentId}`;

    const response = await fetch(`http://localhost:5180/api/GetItemsUnderParent${query}`);
    if(!response.ok) {
        const errorText = await response.text();
        throw new Error(`Get failed: ${response.status} ${errorText}`);
    }

    const result = await response.json() as FetchItemsResponse;
    console.log(result);
    return result;

}
