import { Injectable } from "@angular/core";
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { from, Observable, switchMap } from "rxjs";
import { AuthService } from "./auth.service";

@Injectable()
export class OktaAuthInterceptor implements HttpInterceptor {
    constructor(private authService: AuthService) {}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        // Converte a Promise em Observable
        return from(this.authService.getAccessToken()).pipe(
            switchMap(token => {
                // Se o token existir, clone a request e adicione o header de autorização
                if (token) {
                    const cloned = req.clone({
                        setHeaders: {
                            Authorization: `Bearer ${token}`
                        }
                    });
                    return next.handle(cloned);
                }
                
                // Se não houver token, apenas passe a request original
                return next.handle(req);
            })
        );
    }
}