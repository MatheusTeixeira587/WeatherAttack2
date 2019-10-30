import axios from "axios"

export class BaseService {
    constructor(baseUrl) {
        this.baseUrl = process.env.REACT_APP_API_URL + baseUrl
    }

    get(query, token = "") {
        return axios
            .get(`${this.baseUrl}${token}`, query)
            .then(result => result.data)
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

    getById(id, token = "") {
        return axios
            .get(`${this.baseUrl}/${id}`, {
                headers: {
                    Authorization: `Bearer ${token}`,
                    "Content-type": "application/json"
                }
            })
            .then(result => result.data)
    }

    rawGet(url, query) {
        return axios.get(url, query).then(result => result.data)
    }

  post(object, token = "") {
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

  save(object, token = "") {

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

  delete(id) {
    return axios.delete(`${this.baseUrl}/${id}`)
  }

  rawPut(url, object) {
    return axios.put(url, object).then(result => result.data)
  }

  put(object, token = "") {

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