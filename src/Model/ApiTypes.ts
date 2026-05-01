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
    method: "GET" | "POST" | "PUT" | "DELETE"
    url:string
}

export type ApiType = ApiFolder | Api
