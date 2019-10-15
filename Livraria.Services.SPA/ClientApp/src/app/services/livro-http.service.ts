import { Injectable, Inject } from '@angular/core';
import { Livro } from '../models/livro';
import { HttpBaseService } from './http-base.service';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class LivroHttpService extends HttpBaseService<Livro>{
    private readonly defaultUrl = 'livro'
    constructor(
        protected _httpClient: HttpClient,
        @Inject('BASE_URL') protected baseUrl: string
    ) {
        super(_httpClient, baseUrl)
        this.urlAction = {
            get: this.defaultUrl,
            post: this.defaultUrl,
            put: this.defaultUrl,
            delete: this.defaultUrl
        }
    }
    getAll() {
        return this.list({ url: 'livro/GetALL' })
    }
}
