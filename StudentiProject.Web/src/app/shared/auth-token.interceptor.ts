import {Injectable} from '@angular/core';
import {HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from '@angular/common/http';
import { Observable } from 'rxjs';
import { JwtHelper } from '../auth/jwt.helper';

/**
 * TokenInterceptor
 * @see https://angular.io/guide/http#intercepting-all-requests-or-responses
 */
@Injectable()
export class AuthTokenInterceptor implements HttpInterceptor {

    constructor(
        // private authService: LoginService,
        private jwt: JwtHelper
    ) {
    }

    // public getToken(): string {
    //     return localStorage.getItem('auth_app_token');
    // }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (this.jwt.isLoggedIn()) {
            const authRequest = request.clone({
                headers: request.headers.set('Authorization', this.jwt.getFullToken())
                                        .set('Content-Type', 'application/json')
                                        .set('Accept', 'application/json')
            });
            return next.handle(authRequest);
        }

        return next.handle(request);
    }

}