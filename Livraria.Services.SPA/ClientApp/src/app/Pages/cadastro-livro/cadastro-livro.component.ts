import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LivroHttpService } from '../../services/livro-http.service';
import { Livro } from '../../models/livro';
import { NgForm } from '@angular/forms';

@Component({
    selector: 'cadastro-livro-component',
    templateUrl: './cadastro-livro.component.html'
})
export class CadastroLivroComponent {
    public currentCount = 0;
    livro: Livro = {} as Livro;
    errorMessage = '';
    sucessMessage = '';
    constructor(
        private _activatedRoute: ActivatedRoute,
        private _router: Router,
        private _livroHttpService: LivroHttpService
    ) {

    }
    public incrementCounter() {
        this.currentCount++;
    }
    ngOnInit() {
        const id = this._activatedRoute.snapshot.paramMap.get('id');
        if (id) {
            this._livroHttpService.get(id).subscribe(l => {
                this.livro = l;
                console.log(this.livro);
            })
        }
    }
    save(form: NgForm) {
        if (!this.formIsValid(form)) {
            this.errorMessage = 'Todos os campos do formulário precisam ser válidos';
            return;
        }
        if (!this.livro.id) {
            this._livroHttpService.post(this.livro).subscribe(() => {
                this._router.navigate(['/livros']);
            }, (e) => {
                    console.log(e);
                this.errorMessage = 'Ocorreu um erro ao salvar o Livro';
            })
        } else {
            this._livroHttpService.put(this.livro).subscribe(() => {
                this.sucessMessage = 'As alterções foram salvas';
            }, (e) => {
                    console.log(e);
                this.errorMessage = 'Não foi possível salvar as alterações';
            })
        }
    }
    formIsValid(form: NgForm) {
        if (form.invalid) {
            Object.keys(form.controls).forEach(key => {
                form.controls[key].markAsTouched();
                form.controls[key].markAsDirty();
            })
            return false;
        } else return true;
    }
    cleanMessages() {
        this.errorMessage = '';
        this.sucessMessage = '';
    }
}
