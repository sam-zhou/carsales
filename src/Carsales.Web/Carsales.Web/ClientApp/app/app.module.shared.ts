import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ApiModule } from './api/api.module';
import { CommonModule } from './common/common.module';

import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { VehiclesComponent } from './components/vehicles/vehicles.component';
import { SearchComponent } from './components/search/search.component';

export const sharedConfig: NgModule = {
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        SearchComponent,
        VehiclesComponent
    ],
    imports: [
        RouterModule.forRoot([
            { path: '', redirectTo: 'search', pathMatch: 'full' },
            { path: 'vehicles', component: VehiclesComponent },
            { path: 'search', component: SearchComponent },
            { path: '**', redirectTo: 'search' }
        ]),
        ApiModule,
        CommonModule
    ]
};
