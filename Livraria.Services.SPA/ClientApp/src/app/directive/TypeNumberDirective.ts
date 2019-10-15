import { Directive, SimpleChanges, OnChanges, HostListener } from '@angular/core';
import { NgModel } from '@angular/forms';

@Directive({ selector: '[typenumber]' })
export class TypeNumberDirective {
    constructor(private model: NgModel) { }
    @HostListener('keyup', ['$event'])
    keyup(event) {
        this.setNumber(event);
    }
    setNumber(event) {
        if (this.model.valid) {
            this.model.viewToModelUpdate(Number(event.target.value));
        }
    }
}
