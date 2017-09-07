import { Component, OnInit } from '@angular/core';
import { VehicleDto, VehicleApi, GetVehiclesInput } from '../../../api/index';
import { LoadableComponent } from '../../shared/index';
import { Router, ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

@Component({
    selector: 'vehicles',
    templateUrl: './vehicles.component.html',
    styleUrls: ['./vehicles.component.scss'],
})
export class VehiclesComponent extends LoadableComponent implements OnInit {
    public vehicles: Array<VehicleDto> = [];
    public totalCount: number = 0;

    public itemsPerPage: number = 3;
    public page: number = 1;

    constructor(private vehicleService: VehicleApi, private router: Router, private route: ActivatedRoute, private location: Location) {
        super(true);
    }

    ngOnInit() {
        let page = this.route.snapshot.queryParams['page'];
        if (page) {
            this.page = +page;
        }
        this.getVehicles();
    }

    get getVehichleInput(): GetVehiclesInput {
        return {
            take: this.itemsPerPage,
            skip: (this.page - 1) * this.itemsPerPage
        };
    }

    public getVehicles(resetPage: boolean = false) {
        if (resetPage) {
            this.page = 1;
        }

        if (this.page != 1) {
            this.location.go('/vehicles/list?page=' + this.page);
        } else {
            this.location.go('/vehicles/list');
        }

        this.loading = true;
        this.vehicleService.getVehiclesAsync(this.getVehichleInput)
         .subscribe(result => {
            this.vehicles = result.results;
            this.totalCount = result.totalCount;
            console.log(this.vehicles);
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

    public addCar() {
        this.router.navigate(['/edit/newcar']);
    }

    public addBike() {
        this.router.navigate(['/edit/newbike']);
    }
}
