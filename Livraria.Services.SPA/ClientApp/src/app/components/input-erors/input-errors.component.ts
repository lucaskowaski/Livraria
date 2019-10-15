import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'input-errors',
  templateUrl: './input-errors.component.html'
})
export class InputErrorsComponent implements OnInit {
  @Input() field: any;
  messages = {
    emailvalidator: 'Informe um email válido',
    cpfvalidator: 'Infome um CPF válido',
    required: 'Este campo é obrigatório',
    datevalidator: 'Informe uma data válida',
    greateragevalidator: 'O cliente precisa ter mais que 18 anos'
  }
  constructor() { }
  ngOnInit() {
  }
}
