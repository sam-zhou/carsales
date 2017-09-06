import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ApiModule } from './api/api.module';
import { AppCommonModule } from './common/appcommon.module';
import { ServicesModule } from './services/services.module';

import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { VehiclesComponent } from './components/vehicles/list/vehicles.component';
import { SearchComponent } from './components/search/search.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { EditVehicleComponent } from './components/vehicles/edit/edit-vehicle.component';
import { ViewVehicleComponent } from './components/vehicles/view/view-vehicle.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

export const sharedConfig: NgModule = {
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        SearchComponent,
        VehiclesComponent,
        NotFoundComponent,
        EditVehicleComponent,
        ViewVehicleComponent
    ],
    imports: [
        RouterModule.forRoot([
            { path: '', redirectTo: 'search', pathMatch: 'full' },
            { path: 'vehicles/list', component: VehiclesComponent },
            { path: 'edit/:id', component: EditVehicleComponent },
            { path: 'vehicle/:id', component: ViewVehicleComponent },
            { path: 'search', component: SearchComponent },
            { path: '**', component: NotFoundComponent }
        ]),
        ApiModule,
        AppCommonModule,
        ServicesModule,
        FormsModule,
        ReactiveFormsModule
    ]
};
