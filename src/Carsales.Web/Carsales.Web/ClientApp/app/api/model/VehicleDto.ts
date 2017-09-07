/**
 * Carsales.Api
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */

import * as models from './models';

export interface VehicleDto {
    vehicleType?: VehicleDto.VehicleTypeEnum;

    badgeId?: number;

    badge?: models.BadgeDto;

    name?: string;

    make?: string;

    model?: string;

    badgeName?: string;

    description?: string;

    images?: Array<models.ImageDto>;

    price?: number;

    state?: VehicleDto.StateEnum;

    postcode?: string;

    surburb?: string;

    year?: number;

    odometer?: number;

    id?: number;

}
export namespace VehicleDto {
    export enum VehicleTypeEnum {
        NUMBER_1 = <any> 1,
        NUMBER_2 = <any> 2
    }
    export enum StateEnum {
        NUMBER_0 = <any> 0,
        NUMBER_1 = <any> 1,
        NUMBER_2 = <any> 2,
        NUMBER_3 = <any> 3,
        NUMBER_4 = <any> 4,
        NUMBER_5 = <any> 5,
        NUMBER_6 = <any> 6,
        NUMBER_7 = <any> 7,
        NUMBER_8 = <any> 8
    }
}
