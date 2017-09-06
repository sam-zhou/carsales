import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { VehicleDto, VehicleApi } from '../../../api/index';
import { LoadableComponent } from '../../shared/index';

@Component({
    selector: 'view-vehicle',
    templateUrl: './view-vehicle.component.html'
})
export class ViewVehicleComponent extends LoadableComponent implements OnInit {
    public vehicle: VehicleDto = undefined;
    public vehicleId: number = 0;

    constructor(private vehicleService: VehicleApi, private route: ActivatedRoute, private router: Router) {
        super(true);
    }

    ngOnInit() {
        this.vehicleId = +this.route.snapshot.paramMap.get('id');
        this.vehicleService.getVehicleAsync({ id: this.vehicleId }).subscribe(result => {
            this.vehicle = result;
        }, err => { }
            , () => {
                this.loading = false;
            });
    }

}
