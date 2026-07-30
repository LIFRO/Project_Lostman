export type httpMethod = "GET" | "POST" | "PUT" | "DELETE"

export type ApiFolder = {
    id: number
    name:string
    parentId: number | null
    childrenIds: string[]
}

export type Api = {
    id: number
    name:string
    parentId:number | null
    method: httpMethod
    url:string
}

export type ExplorerItemRequest = {
    id: number,
    api?: CreateApi[]
    catalogs?: CreateFolder[],
}

export type CreateApi = Omit<Api, 'id'>
export type CreateFolder = Omit<ApiFolder, 'id' | 'childrenIds'>

export type ApiType = ApiFolder | Api
