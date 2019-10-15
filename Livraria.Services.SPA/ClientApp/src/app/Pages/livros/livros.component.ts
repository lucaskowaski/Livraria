import { Component, Inject } from '@angular/core';
import { LivroHttpService } from '../../services/livro-http.service';
import { Observable } from 'rxjs';
import { Livro } from '../../models/livro';
import { Router } from '@angular/router';

@Component({
    selector: 'livros-component',
    templateUrl: './livros.component.html'
})
export class LivrosComponent {
    livros: Livro[] = []

    constructor(
        private _livroHttpService: LivroHttpService,
        private _router: Router,
    ) { }
    ngOnInit() {
        this.getAll();
    }
    getAll() {
        this._livroHttpService.getAll().subscribe(l => {
            this.livros = l;
        })
    }
    editar(livro: Livro) {
        this._router.navigate(['/cadastro-livro', { id: livro.id }]);
    }
    excluir(livro: Livro) {
        this._livroHttpService.delete(livro).subscribe(() => {
            const index = this.livros.findIndex(l => l.id === livro.id);
            this.livros.splice(index, 1);
        });
    }
}
