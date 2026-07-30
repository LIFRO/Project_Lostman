import axios from "axios";
import type { httpMethod, ExplorerItemRequest } from "../Model/ApiTypes";

export async function SaveFolder(folder: string) {
    try {
        const response = await axios.post(
            "http://localhost:5180/api/createCatalog",
            { name: folder }, 
            { timeout: 5000 }
        );
        console.log("status:", response.status);
    } catch (error: unknown) {
        if (axios.isAxiosError(error) && error.response) {
            throw new Error(`Save failed: ${error.response.status} ${JSON.stringify(error.response.data)}`);
        }
        throw error;
    }
}

export async function SaveApi(apiName: string, apiMethod: httpMethod, apiUrl: string)  {
    try {
        const response = await axios.post("http://localhost:5180/api/createApi", {
            name: apiName,
            method: apiMethod,
            apiUrl: apiUrl
        },
        { timeout: 5000 }
        );
        console.log("status:", response.status);
    } catch (error: unknown) {
        if (axios.isAxiosError(error) && error.response) {
            throw new Error(`Save failed: ${error.response.status} ${JSON.stringify(error.response.data)}`);
        }
        throw error;
    }
}

export async function AddItemsUnderItemById(requestItem: ExplorerItemRequest){
    try { 
        console.log(JSON.stringify(requestItem))
        const response = await axios.patch("http://localhost:5180/api/AddItemUnderFolder",
            requestItem,
        { timeout: 5000}
        );
        console.log(response.data)
    }catch(error){
        console.log(error)
        
        throw(error);
    }
}
