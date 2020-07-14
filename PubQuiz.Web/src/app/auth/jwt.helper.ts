import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class JwtHelper {

    private readonly TOKEN_KEY = 'token';
    private readonly USER_KEY = 'auth_user';

    public constructor(
    ) {

    }
    public getToken() {
        return localStorage.getItem(this.TOKEN_KEY);
    }

    public setToken(token) {
        localStorage.setItem(this.TOKEN_KEY, token);
    }

    public setUser(user = {}) {
        localStorage.setItem(this.USER_KEY, JSON.stringify(user));
    }

    public getUser() {
        return JSON.parse(localStorage.getItem(this.USER_KEY));
    }

    public isLoggedIn() {
        const token = this.getToken();
        return token && token.length > 0;
    }

    public getFullToken() {
        return 'Bearer ' + this.getToken();
    }
}