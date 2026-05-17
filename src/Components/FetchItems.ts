import axios from "axios";
import type { Api, ApiFolder } from "../Model/TypeLibrary";

export type FetchItemsResponse = {
    catalogs: ApiFolder[]
    apis: Api[]
}

export async function FetchItems(parentId: number | null): Promise<FetchItemsResponse> {
    const query = parentId === null ? "" : `?id=${parentId}`;
    const url = `http://localhost:5180/api/GetItemsUnderParent${query}`;

    const response = await axios.get<FetchItemsResponse>(url);
    console.log(response.data);
    return response.data;
}
