import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import * as api from "./index";

@NgModule({
    imports: [],
    declarations: [],
    providers: [api.VehicleApi],
    bootstrap: []
})
export class ApiModule { }