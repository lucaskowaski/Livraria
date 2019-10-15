import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { LivrosComponent } from './pages/livros/livros.component';
import { CadastroLivroComponent } from './pages/cadastro-livro/cadastro-livro.component';
import { InputErrorsComponent } from './components/input-erors/input-errors.component';
import { NgxMaskModule } from 'ngx-mask';
import { ObjectKeysPipe } from './pipes/object-keys.pipe';
import { TypeNumberDirective } from './directive/TypeNumberDirective';


@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        InputErrorsComponent,
        LivrosComponent,
        CadastroLivroComponent,
        ObjectKeysPipe,
        TypeNumberDirective
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', component: LivrosComponent, pathMatch: 'full' },
            { path: 'livros', component: LivrosComponent },
            { path: 'cadastro-livro', component: CadastroLivroComponent },
        ]),
        NgxMaskModule.forRoot()
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
