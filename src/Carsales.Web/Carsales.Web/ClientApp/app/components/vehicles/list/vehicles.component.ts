import { Component, OnInit } from '@angular/core';
import { VehicleDto, VehicleApi } from '../../../api/index';
import { LoadableComponent } from '../../shared/index';
import { Router } from '@angular/router';

@Component({
    selector: 'vehicles',
    templateUrl: './vehicles.component.html'
})
export class VehiclesComponent extends LoadableComponent implements OnInit {
    public vehicles: Array<VehicleDto> = [];
    public totalCount: number = 0;

    constructor(private vehicleService: VehicleApi, private router: Router) {
        super(true);
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
        }, error => {

        }, () => {
            this.loading = false;
        });
    }

    public view(vehicle: VehicleDto) {
        this.router.navigate(['/vehicle/' + vehicle.id]);
    }

    public edit(vehicle: VehicleDto) {
        this.router.navigate(['/edit/' + vehicle.id]);
    }
}
