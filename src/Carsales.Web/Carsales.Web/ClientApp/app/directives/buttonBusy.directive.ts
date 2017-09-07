import { Directive, ElementRef, Input, OnChanges, Renderer, SimpleChanges, SimpleChange } from '@angular/core';

export interface LocalChanges extends SimpleChanges {
    buttonBusy: SimpleChange
}


@Directive({ selector: '[buttonBusy]' })
export class ButtonBusyDirective implements OnChanges {
    @Input() public busyText: string;
    @Input() public buttonBusy: boolean;

    constructor(private el: ElementRef, private renderer: Renderer)
    {
        if (this.buttonBusy) {
            this.setBusy();
        } else {
            this.setNotBusy();
        }
    }

    ngOnChanges(changes: LocalChanges) {
        if (changes.buttonBusy)
        {
            if (changes.buttonBusy.currentValue) {
                this.setBusy();
            }
            else {
                this.setNotBusy();
            }
        }
    }

    private setBusy() {
        this.el.nativeElement.disabled = 'disabled';
    }

    private setNotBusy() {
        this.el.nativeElement.disabled = false;
    }
}