import axios from "axios";
import type { PatchApi } from "../Model/ApiTypes";
import type { FetchItemsResponse } from "./FetchItems";

export async function asyncSaveEditedApi(api: PatchApi) {
	const url: string = `http://localhost5180/api/SaveEditedApi`

	console.log(JSON.stringify(api));

	const response = await axios.patch<FetchItemsResponse>(url,
		api,
		{
			timeout: 5000
		});
	console.log(response.data);
	return response.data;
}
