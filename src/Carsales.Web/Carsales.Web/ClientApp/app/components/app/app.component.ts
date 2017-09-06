import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { LoadableComponent } from '../shared/index';
@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss'],
    encapsulation: ViewEncapsulation.None
})
export class AppComponent extends LoadableComponent implements OnInit {
    constructor() {
        super(false);
    }

    ngOnInit() {
        
    }
}
