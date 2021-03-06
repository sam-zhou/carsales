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

export interface GetVehiclesInput {
    vehicleType?: GetVehiclesInput.VehicleTypeEnum;

    badgeType?: GetVehiclesInput.BadgeTypeEnum;

    filter?: string;

    take?: number;

    skip?: number;

    sort?: string;

    ascending?: boolean;

}
export namespace GetVehiclesInput {
    export enum VehicleTypeEnum {
        NUMBER_1 = <any> 1,
        NUMBER_2 = <any> 2
    }
    export enum BadgeTypeEnum {
        NUMBER_101 = <any> 101,
        NUMBER_102 = <any> 102,
        NUMBER_103 = <any> 103,
        NUMBER_201 = <any> 201,
        NUMBER_202 = <any> 202
    }
}
