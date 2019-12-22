import request from './request'
export const baseApi = `/api`

const HTTP_METHOD = {
    get: 'get',
    post: 'post',
    delete: 'delete',
    put: 'put'
}

export const processHttp = (method, url, params, data = null, config = null) => {
    return request({
        method: method,
        url: url,
        params: params,
        data
    })
}

export const httpRequest = {
    get: (url, params) => processHttp(HTTP_METHOD.get, baseApi + url, params),
    post: (url, data) => processHttp(HTTP_METHOD.post, baseApi + url, '', data),
    put: (url, data) => processHttp(HTTP_METHOD.put, baseApi + url, '', data),
    delete: (url, params) => processHttp(HTTP_METHOD.delete, baseApi + url, params)
}

export default httpRequest