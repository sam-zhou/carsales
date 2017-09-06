import { Component, OnInit } from '@angular/core';
import { VehicleDto, VehicleApi } from '../../api/index';

@Component({
    selector: 'vehicles',
    templateUrl: './vehicles.component.html'
})
export class VehiclesComponent implements OnInit {
    public vehicles: Array<VehicleDto> = [];
    public totalCount: number = 0;

    constructor(private vehicleService: VehicleApi) {

    }

    ngOnInit() {
        this.getVehicles();
    }

    public getVehicles() {
        this.vehicleService.getVehiclesAsync({
            take: 20,
            skip: 0,
        }).subscribe(result => {
            this.vehicles = result.results;
            this.totalCount = result.totalCount;
        });
    }
}
