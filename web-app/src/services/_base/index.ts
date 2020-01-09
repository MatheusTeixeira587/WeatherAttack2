import axios, { AxiosRequestConfig } from "axios"

export class BaseService {
    baseUrl: string;

    constructor(baseUrl: string) {
        this.baseUrl = process.env.REACT_APP_API_URL + baseUrl
    }

    async pagedGet(token = "", page = 0) {
        const response = await axios.get(`${this.baseUrl}/Page-${page}`, {
            headers: {
                Authorization: `Bearer ${token}`,
                "Content-type": "application/json"
            }
        })

        return response.data
    }

    async getById(id: number, token = "") {
        return axios
            .get(`${this.baseUrl}/${id}`, {
                headers: {
                    Authorization: `Bearer ${token}`,
                    "Content-type": "application/json"
                }
            })
            .then(result => result.data)
    }

    async rawGet(url: string, config: AxiosRequestConfig) {
        return axios.get(url, config).then(result => result.data)
    }

    async post(object: object, token = "") {
        if (!token) {
            return axios.post(this.baseUrl, object).then(result => result.data)
        }

        return axios.post(this.baseUrl, {
            headers: {
                Authorization: `Bearer ${token}`,
                "Content-type": "application/json"
            },
            object
        }).then(result => result.data)
    }

    async save(object: { id: number }, token = "") {

        const data = {
            headers: {
                Authorization: `Bearer ${token}`,
                "Content-type": "application/json"
            },
            object
        }

        const saveAction = object.id
            ? axios.put(this.baseUrl, token ? data : object)
            : axios.post(this.baseUrl, token ? data : object)

        return saveAction.then(result => result.data)
    }

    delete(id: number) {
        return axios.delete(`${this.baseUrl}/${id}`)
    }

    rawPut(url: string, object: object) {
        return axios.put(url, object).then(result => result.data)
    }

    put(object: object, token = "") {

        if (!token) {
            return axios.put(this.baseUrl, object).then(result => result.data)
        }

        return axios.put(this.baseUrl,
            object,
            {
                headers: {
                    Authorization: `Bearer ${token}`,
                    "Content-type": "application/json"
                },
            }
        ).then(result => result.data)
    }
}