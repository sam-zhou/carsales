import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'busy-state',
    templateUrl: './busy-state.component.html',
    styleUrls: ['./busy-state.component.scss']
})
export class BusyStateComponent implements OnInit
{
    public message: string = 'Loading';

    ngOnInit() {

    }
}
