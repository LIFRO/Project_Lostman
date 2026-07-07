import axios from "axios";
import type { Api, ApiFolder } from "../Model/TypeLibrary";

export type FetchItemsResponse = {
    catalogs: ApiFolder[]
    apis: Api[]
}

export async function FetchItemsById(parentId: number | null): Promise<FetchItemsResponse> {
    const query = parentId === null ? "" : `?id=${parentId}`;
    const url = `http://localhost:5180/api/GetItemsUnderParent${query}`;

    const response = await axios.get<FetchItemsResponse>(url);
    console.log(response.data);
    return response.data;
}

export async function FetchItems(): Promise<FetchItemsResponse> {
    const url = 'http://localhost:5100/api/GetItems'

    const response = await axios.get<FetchItemsResponse>(url);
    console.log(response.data);
    return response.data;
}
