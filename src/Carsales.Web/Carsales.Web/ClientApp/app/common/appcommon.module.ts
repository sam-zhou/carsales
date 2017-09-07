import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BusyStateComponent } from './busy-state/busy-state.component';
import { PaginationComponent } from './pagination/pagination.component';

@NgModule({
    imports: [CommonModule],
    declarations: [BusyStateComponent, PaginationComponent],
    providers: [],
    bootstrap: [],
    exports: [BusyStateComponent, PaginationComponent]
})
export class AppCommonModule { }