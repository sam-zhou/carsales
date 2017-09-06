import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import 'rxjs/add/operator/switchMap';
import { VehicleDto, VehicleApi, MakeDto, ModelDto, BadgeDto } from '../../../api/index';
import { LoadableComponent } from '../../shared/index';

@Component({
    selector: 'edit-vehicle',
    templateUrl: './edit-vehicle.component.html'
})
export class EditVehicleComponent extends LoadableComponent implements OnInit {
    public makes: Array<MakeDto> = [];
    public makesLoading: boolean = false;

    public models: Array<ModelDto> = [];
    public badges: Array<BadgeDto> = [];

    public vehicle: VehicleDto = undefined;
    public vehicleId: number = 0;

    constructor(private vehicleService: VehicleApi, private route: ActivatedRoute, private router: Router) {
        super(true);
    }

    ngOnInit() {
        var id = this.route.snapshot.paramMap.get('id');
        if (id === 'newcar' || id === 'newbike') {
            this.vehicleId = 0;
            this.vehicle = {
                vehicleType: id ==='newcar'? 1: 2,
                id: 0,
                badge: {
                    model: {
                        make: {
                        }
                    }
                }
            }
            this.loading = false;
        } else {
            this.vehicleId = +this.route.snapshot.paramMap.get('id');

            if (this.vehicleId) {
                this.vehicleService.getVehicleAsync({ id: this.vehicleId })
                    .subscribe(result => {
                        this.vehicle = result;
                        this.loadModels(this.vehicle.badge.model.makeId);
                        this.loadBadges(this.vehicle.badge.modelId);
                    }, err => {
                    }, () => {
                        this.loading = false;
                    });
            }
        }

        

        this.makesLoading = true;
        this.vehicleService.getMakesAsync()
            .subscribe(result => {
                this.makes = result;
            }, err => {

            }, () => {
                this.makesLoading = false;
            });
    }

   loadModels(makeId: number) {
        this.vehicleService.getModelsAsync({
            makeId: makeId,
            vehicleType: 1
        }).subscribe(result => {
            this.models = result;
        }, err => {

        }, () => {
        });
    }


    loadBadges(modelId: number) {
        this.vehicleService.getBadgesAsync({
            modelId: modelId
        }).subscribe(result => {
            this.badges = result;
        }, err => {

        }, () => {
        });
    }

}
