import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BusyStateComponent } from './busy-state/busy-state.component';

@NgModule({
    imports: [ CommonModule ],
    declarations: [BusyStateComponent],
    providers: [],
    bootstrap: [],
    exports: [BusyStateComponent]
})
export class AppCommonModule { }