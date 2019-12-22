import { httpRequest } from "../httpRequest";

export function getProfile() {
    return httpRequest.get('/Values')
}

